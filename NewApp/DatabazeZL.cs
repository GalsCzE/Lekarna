using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp
{
    public class DatabazeZL
    {
        private SQLiteAsyncConnection Database;

        public DatabazeZL(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<VazbaZL>().Wait();
        }
        // Query
        public Task<List<VazbaZL>> GetItemsAsync6()
        {
            return Database.Table<VazbaZL>().ToListAsync();
        }
        // Query using SQL query string
        public Task<List<VazbaZL>> GetItemsNotDoneAsync6()
        {
            return Database.QueryAsync<VazbaZL>("SELECT * FROM [VazbaZL] ");
        }


        public Task<int> SaveItemAsync6(VazbaZL item)
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

        public Task<List<VazbaZL>> DeleteItemAsync6(int item)
        {
            return Database.QueryAsync<VazbaZL>("DELETE FROM [VazbaZL] WHERE [ID] = " + item);
        }
    }
}
