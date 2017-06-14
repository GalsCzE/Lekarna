using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NewApp
{
    public class VazbaZL
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int zakaznikID { get; set; }
        public int lekID { get; set; }

        public VazbaZL()
        {
        }
    }
}
