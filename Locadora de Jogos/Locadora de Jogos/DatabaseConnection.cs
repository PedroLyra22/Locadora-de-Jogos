using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Locadora_de_Jogos
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        private MySqlConnection _connection;

        private DatabaseConnection()
        {
            string connectionString = "Server=localhost;Database=locadora_jogos;Uid=root;Pwd=;";
            _connection = new MySqlConnection(connectionString);
        }

        public static DatabaseConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnection();
            }
            return _instance;
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
