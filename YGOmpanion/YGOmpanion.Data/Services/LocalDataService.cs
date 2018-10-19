﻿using SQLite;
using System.Collections.Generic;
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
        }

        public Task<List<Card>> GetDataAsync(int page, int pageSize)
        {
            var offset = page > 1 ? (page - 1) * pageSize : 0;
            
            var sqliteQuery = BuildBaseSqlQuery()
                + "ORDER BY txt.name ASC "
                + "LIMIT " + pageSize + " OFFSET " + offset;

            return this.SQLiteConnection.QueryAsync<Card>(sqliteQuery);
        }

        public Task<List<Card>> SearchAsync(string query)
        {
            var sqliteQuery = BuildBaseSqlQuery()
                + "WHERE txt.name LIKE '%" + query + "%' "
                + "OR txt.description LIKE '%" + query + "%' "
                + "OR a.name LIKE '%" + query + "%' "
                + "OR r.name LIKE '%" + query + "%' "
                + "OR t.name LIKE '%" + query + "%'";

            return this.SQLiteConnection.QueryAsync<Card>(sqliteQuery);
        }

        public Task<int> UpdateImageUrlAsync(int id, string imageUrl)
        {
            var sqliteQuery = "UPDATE texts SET image = " + imageUrl + " WHERE id = " + id;

            return this.SQLiteConnection.ExecuteAsync(sqliteQuery);
        }

        private static string BuildBaseSqlQuery()
        {
            return "SELECT txt.id Id, txt.name Name, txt.description Description, d.setcode SetCode, t.id as TypeId"
                + ", t.name Type, d.atk Attack, d.def Defense, d.level Level, r.name Race, a.name Attribute, a.name Category, txt.image ImageUrl "
                + "FROM texts txt "
                + "INNER JOIN datas d ON d.id = txt.id "
                + "INNER JOIN attributes a ON d.attribute = a.id "
                + "INNER JOIN races r ON d.race = r.id "
                + "INNER JOIN types t ON d.type = t.id ";
        }
    }
}
