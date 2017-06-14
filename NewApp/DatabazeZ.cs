using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NewApp
{
    public class DatabazeZ
    {
        private SQLiteAsyncConnection Database;

        public DatabazeZ(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Zakaznik>().Wait();
        }
        // Query
        public Task<List<Zakaznik>> GetItemsAsync()
        {
            return Database.Table<Zakaznik>().ToListAsync();
        }
        // Query using SQL query string
        public Task<List<Zakaznik>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Zakaznik>("SELECT * FROM [Zakaznik] ");
        }


        public Task<int> SaveItemAsync(Zakaznik item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<List<Zakaznik>> DeleteItemAsync(int item)
        {
            return Database.QueryAsync<Zakaznik>("DELETE FROM [Zakaznik] WHERE [ID] = " + item);
        }
    }
}
