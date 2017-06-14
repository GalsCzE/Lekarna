using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace NewApp
{
    public class DatabazeL
    {
        private SQLiteAsyncConnection Database;

        public DatabazeL(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Leky>().Wait();
        }
        // Query
        public Task<List<Leky>> GetItemsAsync2()
        {
            return Database.Table<Leky>().ToListAsync();
        }
        // Query using SQL query string
        public Task<List<Leky>> GetItemsNotDoneAsync2()
        {
            return Database.QueryAsync<Leky>("SELECT * FROM [Leky] ");
        }


        public Task<int> SaveItemAsync2(Leky item)
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

        public async Task< List<Leky> > DeleteItemAsync2(int item)
        {
            return await Database.QueryAsync<Leky>("DELETE FROM [Leky] WHERE [ID] = " + item);
        }
    }
}
