using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NewApp
{
    public class VazbaLS
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int lekyID { get; set; }
        public int slozeniID { get; set; }

        public VazbaLS()
        {
        }
    }
}
