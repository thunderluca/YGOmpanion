using System;
using System.IO;
using System.Linq;

namespace YGOmpanion.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting...");

            var finalDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "cards.db");

            var finalDecksDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "decks.db");

            if (!File.Exists(finalDbPath))
            {
                File.Copy("cards.db", finalDbPath);
            }

            var localDataService = new Data.Services.LocalDataService(finalDbPath, finalDecksDbPath);

            var cardImageService = new Services.CardImageService();

            //var processedIdsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "processedIds.txt");

            //var imageUrlsCsvFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "imageUrls.csv");

            //var ids = File.ReadAllLines(processedIdsFilePath).Where(l => !string.IsNullOrWhiteSpace(l)).Select(l => int.Parse(l)).ToArray();

            //var csvEngine = new FileHelperEngine<CardImageUrl>();

            //var txt = File.ReadAllText(imageUrlsCsvFilePath);

            //var cardsImagesUrls = csvEngine.ReadString(txt);

            System.Console.WriteLine("Ready!");

            var countTask = localDataService.GetCardsCountAsync();

            countTask.Wait();

            System.Console.WriteLine("Found " + countTask.Result + " cards");

            var task = localDataService.GetCardsAsync(0, countTask.Result);

            task.Wait();

            //foreach (var cardImageUrl in cardsImagesUrls)
            //{
            //    var updateTask = localDataService.UpdateCardImageUrlAsync(cardImageUrl.Id, cardImageUrl.Url);
            //    updateTask.Wait();
            //}

            var cards = task.Result.Where(c => string.IsNullOrWhiteSpace(c.ImageUrl)).ToList();

            System.Console.WriteLine("Found " + cards.Count + " cards to update");

            //var cardTuples = new List<Tuple<int, string>>();

            //for (var i = 0; i < cards.Count; i++)
            //{
            //    System.Console.WriteLine($"Processing {i + 1} of {cards.Count} cards");

            //    if (!string.IsNullOrWhiteSpace(cards[i].ImageUrl))
            //    {
            //        cardTuples.Add(Tuple.Create(cards[i].Id, cards[i].ImageUrl));
            //        continue;
            //    }

            //    var imageUrlTask = cardImageService.GetImageUrlAsync(cards[i].Name);

            //    imageUrlTask.Wait();

            //    cardTuples.Add(Tuple.Create(cards[i].Id, imageUrlTask.Result));

            //    var updateTask = localDataService.UpdateCardImageUrlAsync(cards[i].Id, imageUrlTask.Result);
            //    updateTask.Wait();

            //    System.Threading.Thread.Sleep(new Random(Environment.TickCount).Next(500, 2000));
            //}

            //var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "imageUrls_1.csv");

            //using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    using (var writer = new StreamWriter(fs))
            //    {
            //        foreach (var tuple in cardTuples)
            //        {
            //            writer.WriteLine(tuple.Item1 + ";" + tuple.Item2);
            //        }

            //        writer.Flush();
            //    }
            //}

            System.Console.WriteLine("Press any key to exit");

            System.Console.ReadKey();
        }
    }
}
