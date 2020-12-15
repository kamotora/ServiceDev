using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace lab1
{
    public class ConnectionFactory
    {
        
        static string host = "127.0.0.1";  // Имя локального компьютера
        static string database = "db";  // Имя базы данных
        static string user = "user";       // Имя пользователя
        static string password = "evelyn"; // Пароль пользователя

        private static readonly string connectionString = "Server=" + host + "; Database=" + database + "; Uid=" + user + "; Pwd=" + password;

        
        private static ConnectionImpl _connection;

        public static IConnection GetConnection()
        {
            return _connection ?? (_connection = new ConnectionImpl(new MySqlConnection(connectionString)));
        }
    }
}