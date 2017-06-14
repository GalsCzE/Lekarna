using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NewApp
{
   public class Zakaznik
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string login { get; set; }
        public string heslo { get; set; }
        public string opravneni { get; set; }
        public string alergie { get; set; }
        public int pohlavi { get; set; }
        public string lekek { get; set; }

        public Zakaznik()
        {
        }

        public override string ToString()
        {
            return jmeno + " " + prijmeni  + " ";
        }
    }
}
