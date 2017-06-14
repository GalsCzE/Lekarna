using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NewApp
{
    public class DatabazeLS
    {
        private SQLiteAsyncConnection Database;

        public DatabazeLS(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<VazbaLS>().Wait();
        }

        public Task<List<VazbaLS>> GetItemsAsync4()
        {
            return Database.Table<VazbaLS>().ToListAsync();
        }

        public Task<List<VazbaLS>> GetItemsNotDoneAsync4()
        {
            return Database.QueryAsync<VazbaLS>("SELECT * FROM [VazbaLS] ");
        }


        public Task<int> SaveItemAsync4(VazbaLS item)
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

        public Task<List<VazbaLS>> DeleteItemAsync4(int item)
        {
            return Database.QueryAsync<VazbaLS>("DELETE FROM [VazbaLS] WHERE [ID] = " + item);
        }
    }
}
