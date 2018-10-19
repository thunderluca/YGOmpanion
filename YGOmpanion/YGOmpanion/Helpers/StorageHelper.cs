using System.IO;
using System.Linq;

namespace YGOmpanion.Helpers
{
    public static class StorageHelper
    {
        public static void CopyCardsDb(string databaseFilePath)
        {
            if (File.Exists(databaseFilePath))
            {
                File.Delete(databaseFilePath);
            }

            var assembly = typeof(Data.Services.IDataService).Assembly;

            var embeddedResourcesFileNames = assembly.GetManifestResourceNames();

            var embeddedResourceDb = embeddedResourcesFileNames.First(s => s.Contains("cards.db"));
            var embeddedResourceDbStream = assembly.GetManifestResourceStream(embeddedResourceDb);

            using (var reader = new BinaryReader(embeddedResourceDbStream))
            {
                using (var filestream = new FileStream(databaseFilePath, FileMode.Create))

                using (var writer = new BinaryWriter(filestream))
                {
                    var buffer = new byte[2048];
                    int len;
                    while ((len = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, len);
                    }
                }
            }
        }
    }
}
