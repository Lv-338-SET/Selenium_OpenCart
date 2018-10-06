using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Selenium_OpenCart.Tools
{
    static class OCDataBase
    {
        private static string DataPath = "Database=id7366104_set_database;Data Source=databases-auth.000webhost.com/index.php;User Id=id7366104_set_base;Password=viktor11";

        


        #region AtomicOperations

        public static string GenerateSelectQuery(string table, string condition="*", string where="") {
            MySqlConnection conn = new MySqlConnection(DataPath);

            string cmd = "SELECT " 
                + condition 
                + " FROM " 
                + table;
            
            if (where != "") {
                cmd += " WHERE ";
                cmd += where;
            }
            cmd += ";";

            conn.Open();

            MySqlDataReader reader;
            reader = new MySqlCommand(cmd, conn).
                ExecuteReader();
            return reader;
        }

        public static int generateInsertQuery(string table, string values, string condition = "") {
            MySqlConnection conn = new MySqlConnection(DataPath);

            string cmd = "INSERT INTO " 
                + table + " " 
                + condition 
                + " VALUES (" 
                + values + ");";

            conn.Open();

            return new MySqlCommand(cmd, conn)
                .ExecuteNonQuery();
        }

        #endregion

    }
}
