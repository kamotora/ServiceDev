using System.Data;
using System.Data.SqlClient;

namespace lab1
{
    public class ConnectionImpl : IConnection
    {
        private readonly IDbConnection _c;

        public ConnectionImpl(IDbConnection c)
        {
            _c = c;
        }

        public TransactionImpl BeginTransaction()
        {
            return new TransactionImpl(_c.BeginTransaction());
        }

        public void Close()
        {
            _c.Close();
        }

        public IDbConnection GetConnection()
        {
            return _c;
        }

        public void Open()
        {
            _c.Open();
        }
    }
}