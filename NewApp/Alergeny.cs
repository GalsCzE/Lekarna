using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp
{
    public class Alergeny
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string alergen { get; set; }
    }
}
