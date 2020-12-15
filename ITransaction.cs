using System.Data;
using System.Data.SqlClient;

namespace lab1
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
        IDbTransaction GetTransaction();
    }
}