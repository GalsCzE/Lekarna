using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp
{
    public class DatabazeZA
    {
        private SQLiteAsyncConnection Database;

        public DatabazeZA(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<VazabaZA>().Wait();
        }
        // Query
        public Task<List<VazabaZA>> GetItemsAsync7()
        {
            return Database.Table<VazabaZA>().ToListAsync();
        }
        // Query using SQL query string
        public Task<List<VazabaZA>> GetItemsNotDoneAsync7()
        {
            return Database.QueryAsync<VazabaZA>("SELECT * FROM [VazabaZA] ");
        }


        public Task<int> SaveItemAsync7(VazabaZA item)
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

        public Task<List<VazabaZA>> DeleteItemAsync7(int item)
        {
            return Database.QueryAsync<VazabaZA>("DELETE FROM [VazabaZA] WHERE [ID] = " + item);
        }
    }
}
