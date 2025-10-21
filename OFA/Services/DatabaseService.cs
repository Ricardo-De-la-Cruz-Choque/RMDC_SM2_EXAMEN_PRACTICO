using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using OFA.Models;
using System;

namespace OFA.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<ShoppingItem>().Wait();
        }

        public Task<List<ShoppingItem>> GetItemsAsync()
            => _db.Table<ShoppingItem>().OrderBy(i => i.IsBought).ThenBy(i => i.Name).ToListAsync();

        public Task<ShoppingItem> GetItemAsync(int id)
            => _db.Table<ShoppingItem>().Where(i => i.Id == id).FirstOrDefaultAsync();

        public Task<int> AddItemAsync(ShoppingItem item)
            => _db.InsertAsync(item);

        public Task<int> UpdateItemAsync(ShoppingItem item)
            => _db.UpdateAsync(item);

        public Task<int> DeleteItemAsync(ShoppingItem item)
            => _db.DeleteAsync(item);

    }
}
