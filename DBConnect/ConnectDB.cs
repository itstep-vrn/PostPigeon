using System;
using MySql.Data.MySqlClient;

namespace DBConnect
{
    public class ConnectDB
    {
        #region Variable
        private readonly string host;
        private readonly string port;
        private readonly string username;
        private readonly string password;
        private readonly string database;
            
        private readonly string connString;

        private MySqlConnection db;
        #endregion

        #region Construct
        public ConnectDB()
        {
            host = "mysql60.hostland.ru";
            port = "3306";
            username = "host1323541_itstep";
            password = "269f43dc";
            database = "host1323541_postpigeon";
            connString = "Server=" + host 
                                   + ";Database=" + database 
                                   + ";port=" + port 
                                   + ";User Id=" + username 
                                   + ";password=" + password;
            
            db = new MySqlConnection(connString);
        }

        public ConnectDB(string host, string port, string username, string password, string database)
        {
            connString = "Server=" + host 
                                   + ";Database=" + database 
                                   + ";port=" + port 
                                   + ";User Id=" + username 
                                   + ";password=" + password;
            
            db = new MySqlConnection(connString);
        }
        #endregion

        public void OpenDB()
        {
            db.Open();
        }

        public MySqlDataReader SelectQuery(string sql)
        {
            var command = new MySqlCommand()
            {
                CommandText = sql,
                Connection = db
            };
            var result = command.ExecuteReader();
            return result;
        }

        public void CloseDB()
        {
            db.Close();
        }
    }
}
