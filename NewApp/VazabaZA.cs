using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp
{
   public class VazabaZA
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int zakaznikID { get; set; }
        public int alergieID { get; set; }

        public VazabaZA()
        {
        }
    }
}
