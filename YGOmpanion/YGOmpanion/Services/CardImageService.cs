using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace YGOmpanion.Services
{
    public class CardImageService : ICardImageService
    {
        private readonly HttpClient Client;

        public CardImageService()
        {
            this.Client = new HttpClient();
        }

        const string origin = "http://yugioh.wikia.com";

        static readonly string[] ExcludedPatterns = new[]
        {
            "^List of ",
            "^(Chapter|Episode) Card Galleries:",
            @" \((?!card).*\)$"
        };

        public async Task<string> GetImageUrlAsync(string cardName)
        {
            if (string.IsNullOrWhiteSpace(cardName)) return null;

            var url = origin + "/api.php?format=json&action=imageserving&wisTitle=" + WebUtility.UrlEncode(cardName);

            var requestTask = this.Client.GetAsync(new Uri(url));

            requestTask.Wait();

            if (!requestTask.Result.IsSuccessStatusCode) return null;

            var responseContent = await requestTask.Result.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(responseContent)) return null;

            var imageResponse = JsonConvert.DeserializeObject<ImageResponse>(responseContent);
            return imageResponse?.Image?.ImageServing;
        }

        class ImageResponse
        {
            [JsonProperty("image")]
            public Image Image { get; set; }
        }

        class Image
        {
            [JsonProperty("imageserving")]
            public string ImageServing { get; set; }
        }
    }
}
