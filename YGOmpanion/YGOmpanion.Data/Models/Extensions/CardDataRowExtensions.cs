using System;
using System.Collections.Generic;
using System.Linq;

namespace YGOmpanion.Data.Models
{
    public static class CardDataRowExtensions
    {
        public static IEnumerable<CardDataRow> Contains(this IEnumerable<CardDataRow> source, string query)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.Where(cdr => cdr.CardName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
