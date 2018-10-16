using Newtonsoft.Json;
using System;
using YGOmpanion.Data.Converters;

namespace YGOmpanion.Data.Models
{
    public class CardLocale
    {
        [JsonProperty("set_number")]
        public string SetNumber { get; set; }

        [JsonProperty("rarities")]
        public string[] Rarities { get; set; }

        [JsonProperty("date")]
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime Date { get; set; }
    }
}
