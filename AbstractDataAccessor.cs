using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace lab1
{
    public abstract class AbstractDataAccessor : IDataAccessor
    {
        protected string tableName;
        public string TableName => tableName;
        protected string[] columnNames;
        public string[] Columns => columnNames;
        protected string id = "Id";
        public string Id => id;
        
        private void bindParams(MySqlParameterCollection target, params string[] columns)
        {
            foreach (string column in columns)
            {
                target.Add(new SqlParameter
                {
                    SourceColumn = column,
                    ParameterName = '@' + column
                });
            }
        }


        public void Read(IConnection connection, ITransaction transaction, DataSet1 ds)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter
            {
                SelectCommand = new MySqlCommand(new QueryBuilder().Select().From(TableName).Query,
                    (MySqlConnection) connection.GetConnection(),
                    (MySqlTransaction) transaction.GetTransaction())
            };

            adapter.Fill(ds, TableName);
            Console.WriteLine("\nRead " + TableName);
            //Helper.PrintDataSet(ds, tableName());
        }


        public void Update(IConnection connection, ITransaction transaction, DataSet1 ds)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            // SELECT
            String sqlSelect = "SELECT * FROM " + TableName;
            adapter.SelectCommand =
                new MySqlCommand(sqlSelect, (MySqlConnection) connection.GetConnection(),
                    (MySqlTransaction) transaction.GetTransaction());
            
            // INSERT
            String sqlInsert = new QueryBuilder().Insert(TableName, Columns).Query;
            adapter.InsertCommand = new MySqlCommand(sqlInsert, (MySqlConnection) connection.GetConnection(),
                (MySqlTransaction) transaction.GetTransaction());
            bindParams(adapter.InsertCommand.Parameters, Columns);

            //UPDATE
            String sqlUpdate = new QueryBuilder().Update(TableName, Columns).Where(Id).Query;
            adapter.UpdateCommand = new MySqlCommand(sqlUpdate, (MySqlConnection) connection.GetConnection(),
                (MySqlTransaction) transaction.GetTransaction());
            bindParams(adapter.UpdateCommand.Parameters, Columns);
            bindParams(adapter.UpdateCommand.Parameters, Id);

            // DELETE
            String sqlDelete = new QueryBuilder().Delete().From(TableName).Where(Id).Query;
            adapter.DeleteCommand = new MySqlCommand(sqlDelete, (MySqlConnection) connection.GetConnection(),
                (MySqlTransaction) transaction.GetTransaction());
            bindParams(adapter.DeleteCommand.Parameters, Id);

            Helper.Console(sqlSelect, sqlInsert, sqlUpdate, sqlDelete);
            // Updating
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(adapter);
            adapter.Update(ds, TableName);
            Console.WriteLine("\nUpdate " + TableName);
            //Helper.PrintDataSet(ds, TableName);
        }
    }
}