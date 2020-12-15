using System;
using System.IO;
using lab1;
using MySql.Data.MySqlClient;

namespace DATests
{
    class TableInit
    {
        private static string TruncateSql = "Truncate.sql";
        private static string InsertSql = "Insert.sql";
        
        public static void Init()
        {
            // Дропаем все таблицы
            IConnection connectionTruncate = null;
            ITransaction transactionTruncate = null;
            try
            {
                connectionTruncate = ConnectionFactory.GetConnection();
                connectionTruncate.Open();
                transactionTruncate = connectionTruncate.BeginTransaction();
                // string path = Path.Combine(@"C:\SQL", TruncateSql);
                String str = File.ReadAllText(TruncateSql);
                MySqlScript script = new MySqlScript((MySqlConnection) connectionTruncate.GetConnection(), str);
                script.Execute();
                transactionTruncate.Commit();
            }
            catch (Exception e)
            {
                transactionTruncate?.Rollback();
            }
            finally
            {
                connectionTruncate?.Close();
            }
            
            // Создаем базу заново
            IConnection connectionInsert = null;
            ITransaction transactionInsert = null;
            try
            {
                connectionInsert = ConnectionFactory.GetConnection();
                connectionInsert.Open();
                transactionInsert = connectionInsert.BeginTransaction();
                // string path = Path.Combine( @"C:\SQL", InsertSql);
                String str = File.ReadAllText(InsertSql);
                MySqlScript script = new MySqlScript((MySqlConnection) connectionInsert.GetConnection(), str);
                script.Execute();
                transactionInsert.Commit();
            }
            catch (Exception e)
            {
                transactionInsert?.Rollback();
            }
            finally
            {
                connectionInsert?.Close();
            }
        }  

    }
}