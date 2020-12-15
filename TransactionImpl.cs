using System.Data;
using System.Data.SqlClient;

namespace lab1
{
    public class TransactionImpl : ITransaction
    {
        private readonly IDbTransaction _t;

        public TransactionImpl(IDbTransaction t) {
            _t = t;
        }
            
        public void Commit()
        {
            _t.Commit();
        }

        public void Rollback()
        {
            _t.Rollback();
        }

        public IDbTransaction GetTransaction()
        {
            return _t;
        }
    }
}