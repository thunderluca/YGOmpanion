using FileHelpers;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace YGOmpanion.Data.Helpers
{
    public static class CsvHelper
    {
        public static T[] ReadFile<T>(string fileName) where T : class
        {
            var cardData = new List<T>();

            using (var stream = typeof(Database).GetTypeInfo().Assembly.GetManifestResourceStream(fileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var engine = new FileHelperAsyncEngine<T>())
                    {
                        using (engine.BeginReadStream(reader))
                        {
                            foreach (var cardDataRow in engine)
                            {
                                cardData.Add(cardDataRow);
                            }
                        }
                    }
                }
            }

            return cardData.ToArray();
        }
    }
}
