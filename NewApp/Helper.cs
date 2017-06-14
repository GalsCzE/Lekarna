using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;

namespace NewApp
{
    public class Helper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine("", filename);
        }
    }
}
