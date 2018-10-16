namespace YGOmpanion.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting...");

            var database = new Data.Database();

            System.Console.WriteLine("Ready! Found " + database.CardData.Count + " cards");

            System.Console.ReadKey();
        }
    }
}
