using Insurance.DAO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Util
{
    public class DBConnection
    {
      
         private static SqlConnection connection;

            public static SqlConnection GetConnection()
            {
                if (connection == null || connection.State == System.Data.ConnectionState.Closed)
                {
                    string connectionString = PropertyUtil.GetPropertyString("db.properties");
                    connection = new SqlConnection(connectionString);
                }

                return connection;
            }


        }
    }
