using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NewApp
{
    public class DatabazeS
    {
        private SQLiteAsyncConnection Database;

        public DatabazeS(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Slozky>().Wait();
        }
        // Query
        public Task<List<Slozky>> GetItemsAsync3()
        {
            return Database.Table<Slozky>().ToListAsync();
        }
        // Query using SQL query string
        public Task<List<Slozky>> GetItemsNotDoneAsync3()
        {
            return Database.QueryAsync<Slozky>("SELECT * FROM [Slozky] ");
        }


        public Task<int> SaveItemAsync3(Slozky item)
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

        public Task<List<Slozky>> DeleteItemAsync3(int item)
        {
            return Database.QueryAsync<Slozky>("DELETE FROM [Slozky] WHERE [ID] = " + item);
        }
    }
}
