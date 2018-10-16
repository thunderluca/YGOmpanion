using Newtonsoft.Json;

namespace YGOmpanion.Data.Models
{
    public class CardLocale
    {
        [JsonProperty("set_number")]
        public string SetNumber { get; set; }

        [JsonProperty("rarities")]
        public string[] Rarities { get; set; }

        [JsonProperty("date")]
        //[JsonConverter(typeof(CustomDateConverter))]
        public string Date { get; set; }
    }
}
