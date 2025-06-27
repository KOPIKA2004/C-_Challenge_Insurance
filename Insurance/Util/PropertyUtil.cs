using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Insurance.Util
{
    public class PropertyUtil
    {
        public static string GetPropertyString(string filePath)
        {
            string hostname = "", port = "", dbname = "", username = "", password = "";

            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                if (line.StartsWith("hostname=")) hostname = line.Substring("hostname=".Length).Trim();
                else if (line.StartsWith("port=")) port = line.Substring("port=".Length).Trim();
                else if (line.StartsWith("dbname=")) dbname = line.Substring("dbname=".Length).Trim();
                else if (line.StartsWith("username=")) username = line.Substring("username=".Length).Trim();
                else if (line.StartsWith("password=")) password = line.Substring("password=".Length).Trim();
            }

            return $"Data Source={hostname},{port};Initial Catalog={dbname};User ID={username};Password={password}";
        }
    }
}
