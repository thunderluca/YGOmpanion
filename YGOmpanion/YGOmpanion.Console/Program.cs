namespace YGOmpanion.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting...");

            var localDataService = new Data.Services.LocalDataService();

            var task = localDataService.GetDataAsync(0, 6000);

            task.Wait();

            System.Console.WriteLine("Ready! Found " + task.Result.Count + " cards");

            System.Console.ReadKey();
        }
    }
}
