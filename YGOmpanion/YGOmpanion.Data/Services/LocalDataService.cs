using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YGOmpanion.Data.Models;

namespace YGOmpanion.Data.Services
{
    public class LocalDataService : IDataService
    {
        private readonly SQLiteAsyncConnection SQLiteConnection;
        
        public LocalDataService(string databasePath)
        {
            this.SQLiteConnection = new SQLiteAsyncConnection(databasePath);

            this.CreateTables();
        }

        private async void CreateTables()
        {
            await this.SQLiteConnection.CreateTableAsync<Deck>();
            await this.SQLiteConnection.CreateTableAsync<DeckCard>();
        }

        public Task<List<Card>> GetCardsAsync(int page, int pageSize)
        {
            var offset = page > 1 ? (page - 1) * pageSize : 0;
            
            var sqliteQuery = BuildBaseCardSqlQuery()
                + "ORDER BY txt.name ASC "
                + "LIMIT " + pageSize + " OFFSET " + offset;

            return this.SQLiteConnection.QueryAsync<Card>(sqliteQuery);
        }

        public Task<int> GetCardsCountAsync()
        {
            var sqliteQuery = "SELECT count(*) FROM datas";

            return this.SQLiteConnection.ExecuteScalarAsync<int>(sqliteQuery);
        }

        public Task<List<Card>> SearchCardsAsync(string query)
        {
            var sqliteQuery = BuildBaseCardSqlQuery()
                + "WHERE txt.name LIKE '%" + query + "%' "
                + "OR txt.description LIKE '%" + query + "%' "
                + "OR a.name LIKE '%" + query + "%' "
                + "OR r.name LIKE '%" + query + "%' "
                + "OR t.name LIKE '%" + query + "%'";

            return this.SQLiteConnection.QueryAsync<Card>(sqliteQuery);
        }

        public Task<int> UpdateCardImageUrlAsync(int id, string imageUrl)
        {
            var sqliteQuery = "UPDATE texts SET image = '" + imageUrl + "' WHERE id = " + id;

            return this.SQLiteConnection.ExecuteAsync(sqliteQuery);
        }

        public Task<Card> GetCardAsync(int id)
        {
            var sqliteQuery = BuildBaseCardSqlQuery() + "WHERE txt.id = " + id;

            return this.SQLiteConnection.FindWithQueryAsync<Card>(sqliteQuery);
        }

        public Task<List<Deck>> GetDecksAsync(string query)
        {
            var linqQuery = this.SQLiteConnection.Table<Deck>();
            if (!string.IsNullOrWhiteSpace(query))
            {
                linqQuery = linqQuery.Where(d => d.Name.Contains(query) || d.Description.Contains(query));
            }

            return linqQuery.OrderByDescending(d => d.CreatedOn).ToListAsync();
        }

        public Task<Deck> GetDeckAsync(int id)
        {
            return this.SQLiteConnection.Table<Deck>().FirstOrDefaultAsync(d => d.Id == id);
        }

        public Task<int> AddNewDeckAsync(Deck deck)
        {
            return this.SQLiteConnection.InsertAsync(deck);
        }

        public async Task<List<Tuple<Card, int>>> GetDeckCardsAsync(int id)
        {
            var deckCards = await this.SQLiteConnection.Table<DeckCard>().Where(dc => dc.DeckId == id).ToListAsync();
            if (deckCards.Count == 0) return new List<Tuple<Card, int>>();

            var deckCardsIds = deckCards.Select(dc => dc.CardId).Distinct().OrderBy(i => i).ToArray();

            var sqliteQuery = BuildBaseCardSqlQuery() + "WHERE txt.id IN (" + string.Join(",", deckCardsIds) + ")";

            var cards = await this.SQLiteConnection.QueryAsync<Card>(sqliteQuery);
            if (cards.Count == 0) return new List<Tuple<Card, int>>();

            var cardsList = new List<Tuple<Card, int>>();

            foreach (var deckCard in deckCards)
            {
                var card = cards.FirstOrDefault(c => c.Id == deckCard.Id);
                if (card == null) continue;

                cardsList.Add(Tuple.Create(card, deckCard.Count));
            }

            return cardsList;
        }

        private static string BuildBaseCardSqlQuery()
        {
            return "SELECT txt.id Id, txt.name Name, txt.description Description, t.id as TypeId, t.name Type"
                + ", d.atk Attack, d.def Defense, d.level Level, r.name Race, a.name Attribute, a.name Category, txt.image ImageUrl "
                + "FROM texts txt "
                + "INNER JOIN datas d ON d.id = txt.id "
                + "INNER JOIN attributes a ON d.attribute = a.id "
                + "INNER JOIN races r ON d.race = r.id "
                + "INNER JOIN types t ON d.type = t.id ";
        }
    }
}
