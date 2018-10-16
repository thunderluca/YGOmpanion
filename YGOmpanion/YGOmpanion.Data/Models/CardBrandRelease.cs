using Newtonsoft.Json;
using System.Collections.Generic;

namespace YGOmpanion.Data.Models
{
    public class CardBrandRelease
    {
        [JsonProperty("OCG")]
        public Dictionary<string, Dictionary<string, CardLocale>> OCG { get; set; }

        [JsonProperty("TCG")]
        public Dictionary<string, Dictionary<string, CardLocale>> TCG { get; set; }
    }
}
