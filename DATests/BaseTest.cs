using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using lab1;
using NUnit.Framework;

namespace DATests
{
    [TestFixture]
    public abstract class BaseTest<T>  where T : DataRow
    {
        protected List<T> GetAllBaseTest(
            AbstractDataAccessor dataAccessor, 
            DataSet1 dataSet1,
            int expectedSize)
        {
            DoInTransaction(dataAccessor.Read, dataSet1);
            var dataRows = Select(dataSet1, null);
            dataRows.Sort((x, y) => ((Int64) x["Id"]).CompareTo((Int64) y["Id"]));
            Assert.IsNotEmpty(dataRows);
            Assert.AreEqual(expectedSize, dataRows.Count);
            return dataRows;
        }
        
        protected T FindByIdBaseTest(            
            AbstractDataAccessor dataAccessor, 
            DataSet1 dataSet1,
            Int64 id)
        {
            DoInTransaction(dataAccessor.Read, dataSet1);
            var list = Select(dataSet1, $"Id = {id}");
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(id, (Int64) list[0][dataAccessor.Id]);
            return list.First(); // Всё равно одна запись
        }
        
        protected void UpdateColumnBaseTest<R>(            
            AbstractDataAccessor dataAccessor, 
            DataSet1 dataSet1,
            Int64 idUpdatableRow,
            String columnName,
            R newColumnValue) where R : class
        {
            R oldValue = null;

            DoInTransaction(dataAccessor.Read, dataSet1);

            var dataRow = Select(dataSet1, $"Id = {idUpdatableRow}").First();
            oldValue = (R) dataRow[columnName];
            dataRow[columnName] = newColumnValue;
            DoInTransaction(dataAccessor.Update, dataSet1);
            DoInTransaction(dataAccessor.Read, dataSet1);
            var list = Select(dataSet1, $"Id = {idUpdatableRow}").ToList();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(idUpdatableRow, (Int64) list[0][dataAccessor.Id]);
            Assert.AreEqual(newColumnValue, (R) (list[0][columnName]));
            DoInTransaction(dataAccessor.Read, dataSet1);
            //Возврат обратно
            dataRow  = Select(dataSet1, $"Id = {idUpdatableRow}").First();
            dataRow[columnName] = oldValue;
            DoInTransaction(dataAccessor.Update, dataSet1);
            //todo можно чекнуть, что вернулось
            
        }

        protected List<T> FindAllByParentIdBaseTest <TR>(            
            AbstractDataAccessor dataAccessor, 
            AbstractDataAccessor dataParentAccessor,
            TypedTableBase<TR> parentTable,
            DataSet1 dataSet1,
            String parentIdName,
            Int64 parentId,
            Int64 expectedCount) where TR : DataRow
        {
       
            // Проверим, что такой дочерняя запись есть
            DoInTransaction(dataParentAccessor.Read, dataSet1);
            var brandRows = Select($"Id = '{parentId}'", parentTable);
            Assert.AreEqual(1, brandRows.Count);
            
            DoInTransaction(dataAccessor.Read, dataSet1);
            var rows = Select(dataSet1, $"{parentIdName} = {parentId}");
            
            Assert.AreEqual(expectedCount, rows.Count);
            return rows;
        }
        
        protected void DoInTransaction(
            Action<IConnection, ITransaction, DataSet1> sqlFunc,
            DataSet1 dataSet1
        )
        {
            IConnection connection = null;
            TransactionImpl transaction = null;
            try
            {
                connection = ConnectionFactory.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();
                sqlFunc.Invoke(connection, transaction, dataSet1);
                transaction.Commit();
                connection.Close();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                connection?.Close();
                throw new AssertionException(e.Message, e);
            }
        }

        public abstract List<T> Select(DataSet1 dataSet1, String filter);

        public static List<TR> Select<TR>(String filter, TypedTableBase<TR> table) where TR : DataRow
        {
            if(String.IsNullOrEmpty(filter))
                return table.Select().Select((x) => (TR) x).ToList();
            else 
                return table.Select(filter).Select((x) => (TR) x).ToList();
        }
    }
}