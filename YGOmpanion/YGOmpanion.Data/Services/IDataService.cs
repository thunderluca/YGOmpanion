using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YGOmpanion.Data.Models;

namespace YGOmpanion.Data.Services
{
    public interface IDataService
    {
        Task<List<Card>> GetCardsAsync(int page, int pageSize);

        Task<int> GetCardsCountAsync();

        Task<Card> GetCardAsync(int id);

        Task<List<Card>> SearchCardsAsync(string query);

        Task<List<Deck>> GetDecksAsync(string query);

        Task<Deck> GetDeckAsync(int id);

        Task<int> AddNewDeckAsync(Deck deck);

        Task<List<Tuple<Card, int>>> GetDeckCardsAsync(int id);

        Task<int> UpdateCardImageUrlAsync(int id, string imageUrl);
    }
}
