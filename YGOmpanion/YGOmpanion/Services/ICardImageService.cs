using System.Threading.Tasks;

namespace YGOmpanion.Services
{
    public interface ICardImageService
    {
        Task<string> GetImageUrlAsync(string query);
    }
}
