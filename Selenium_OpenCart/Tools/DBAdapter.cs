using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Selenium_OpenCart
{
    class DBAdapter
    {
        protected MySqlConnection conn;

        protected string DataPath = string.Format("Server=localhost; database={0}; UID=root; password=; SslMode = none", "shop");

        #region AtomicOperations
        
        /// <summary>
        /// Open connection for DB
        /// </summary>
        /// <returns>Object opened MySqlConnection</returns>
        public MySqlConnection OpenConnection()
        {
            this.conn = new MySqlConnection(DataPath);
            conn.Open();

            return conn;
        }

        /// <summary>
        /// Close opened connection
        /// </summary>
        /// <returns>Return 'true' if connection closed, 'false' if throwed exception</returns>
        public bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GenerateQueryMethods

        /// <summary>
        /// Generate select query and Execute reader. Need opened connection
        /// </summary>
        /// <param name="table">Name of table in DB</param>
        /// <param name="columns">Column to select. Defauld:'*'</param>
        /// <param name="where">Where columnss. Default: empty</param>
        /// <param name="join">Join query string. Default:empty. Use GetJoinedTableString() for generate</param>
        /// <returns></returns>
        public MySqlDataReader GetSelectReader(string table, string columns = "*", string where = "", string join = "")
        {
            string cmd = String.Format("SELECT {0} FROM {1}", columns, table);

            if (join != "")
            {
                cmd += join;
            }

            if (where != "")
            {
                cmd += String.Format(" WHERE {0}", where);
            }

            cmd = String.Format(cmd, ";");

            MySqlDataReader reader;
            reader = new MySqlCommand(cmd, this.conn).
                ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Generate join string
        /// </summary>
        /// <param name="table">Name of table for join</param>
        /// <param name="typeJoin">Type join. Ex: 'LEFT','RIGHT'</param>
        /// <param name="equalField">Name of column to join</param>
        /// <returns></returns>
        public string GetJoinedTableString(string table, string typeJoin, string equalField)
        {
            return String.Format(" {0} JOIN {1} USING({2}) ", typeJoin, table, equalField);
        }

        /// <summary>
        /// Generate insert string and execute insert query. Need opened connection
        /// </summary>
        /// <param name="table">Name of table in DB</param>
        /// <param name="values">Dictionary for column. Key - Name column. Value - value for insert</param>
        /// <param name="columns">List for column for insert. Default:empty. Example:'(column1,column2,column3)'</param>
        /// <returns>State execution</returns>
        public int ExecuteInsertQuery(string table, Dictionary<string, string> values, string columns = "")
        {
            string cmd = String.Format("INSERT INTO {0} {1} VALUES (", table, columns);

            foreach (var current in values)
            {
                switch (current.Key)
                {
                    case "string":
                        cmd += String.Format("'{0}', ", current.Value);
                        break;
                    case "int":
                        cmd += String.Format("{0}, ", current.Value);
                        break;
                }
            }
            cmd += String.Format(");");

            return new MySqlCommand(cmd, this.conn)
                .ExecuteNonQuery();

        }
        #endregion

    }
}
