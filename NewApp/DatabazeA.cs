using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp
{
    public class DatabazeA
    {
        private SQLiteAsyncConnection Database;

        public DatabazeA(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Alergeny>().Wait();
        }
        // Query
        public Task<List<Alergeny>> GetItemsAsync5()
        {
            return Database.Table<Alergeny>().ToListAsync();
        }
        // Query using SQL query string
        public Task<List<Alergeny>> GetItemsNotDoneAsync5()
        {
            return Database.QueryAsync<Alergeny>("SELECT * FROM [Alergeny] ");
        }


        public Task<int> SaveItemAsync5(Alergeny item)
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

        public Task<List<Alergeny>> DeleteItemAsync5(int item)
        {
            return Database.QueryAsync<Alergeny>("DELETE FROM [Alergeny] WHERE [ID] = " + item);
        }
    }
}
