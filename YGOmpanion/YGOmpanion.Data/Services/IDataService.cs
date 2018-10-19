using System.Collections.Generic;
using System.Threading.Tasks;
using YGOmpanion.Data.Models;

namespace YGOmpanion.Data.Services
{
    public interface IDataService
    {
        Task<List<Card>> GetDataAsync(int page, int pageSize);

        Task<List<Card>> SearchAsync(string query);

        Task<int> UpdateImageUrlAsync(int id, string imageUrl);
    }
}
