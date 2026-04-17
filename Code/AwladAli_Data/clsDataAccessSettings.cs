using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AwladAli_Data
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString = $@"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AwladAli.db")};Version=3;";
    }
}
