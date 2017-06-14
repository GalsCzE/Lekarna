using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NewApp
{
    public class Leky
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string nazev { get; set; }
        public string slozeni { get; set; }
        public string firma { get; set; }

        public Leky()
        {
        }

        public override string ToString()
        {
            return nazev + " ";
        }
    }
}
