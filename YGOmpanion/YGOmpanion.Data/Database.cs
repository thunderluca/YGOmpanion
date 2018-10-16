using FileHelpers;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using YGOmpanion.Data.Models;

namespace YGOmpanion.Data
{
    public class Database
    {
        static string @namespace = nameof(YGOmpanion) + "." + nameof(YGOmpanion.Data);

        public readonly IReadOnlyList<CardDataRow> CardData;

        public Database()
        {
            this.CardData = ReadFile(@namespace + ".YGO_Cards_v2.csv");
        }

        private static CardDataRow[] ReadFile(string fileName)
        {
            var cardData = new List<CardDataRow>();

            using (var stream = typeof(Database).GetTypeInfo().Assembly.GetManifestResourceStream(@namespace + ".YGO_Cards_v2.csv"))
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var engine = new FileHelperAsyncEngine<CardDataRow>())
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
