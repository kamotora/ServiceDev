using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace lab1
{
    public interface IConnection
    {
        void Open();
        void Close();
        TransactionImpl BeginTransaction();
        IDbConnection GetConnection();
    }
}