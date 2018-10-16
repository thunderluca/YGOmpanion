using System.Collections.Generic;
using YGOmpanion.Data.Helpers;
using YGOmpanion.Data.Models;

namespace YGOmpanion.Data
{
    public class Database
    {
        static string @namespace = nameof(YGOmpanion) + "." + nameof(YGOmpanion.Data);

        public readonly IReadOnlyList<CardDataRow> CardData;

        public Database()
        {
            this.CardData = CsvHelper.ReadFile<CardDataRow>(@namespace + ".YGO_Cards_v2.csv");
        }
    }
}
