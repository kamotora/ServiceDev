using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using lab1;

namespace BL
{
    public abstract class AbstractLogic<T> where T: DataRow
    {
        private AbstractDataAccessor _a;
        public AbstractDataAccessor Accessor => _a ?? (_a = CreateAccessor());
        
        private DataSet1 _cache;

        public DataSet1 Cache
        {
            get => _cache ?? (_cache = new DataSet1());
            set => _cache = value;
        }

        protected abstract AbstractDataAccessor CreateAccessor();

        public ICollection<T> FindAll()
        {
            ReadInTransaction();
            return GetTable().Select().Select(row => row as T).ToList();
        }

        protected TypedTableBase<T> GetTable()
        {
            return Cache.Tables[Accessor.TableName] as TypedTableBase<T>;
        }
        public T NewRow()
        {
            return GetTable().NewRow() as T;
        }
        
        public T FindByIdOrThrow(long id)
        {
            try
            {
                ReadInTransaction();
                var dataRow = GetTable().Rows.Find(id) as T;
                if(dataRow == null)
                    throw new SystemException($"Not foundin table {Accessor.TableName} by id = {id}");
                return dataRow;
            }
            catch (Exception e)
            {
                throw new SystemException($"Error find in table {Accessor.TableName} by id = {id}", e);
            }
        }
        
        public T FindByLastId()
        {
            try
            {
                ReadInTransaction();
                return GetTable().Select(null, "Id DESC").Select(row => (T) row).First();
            }
            catch (Exception e)
            {
                throw new SystemException($"Error find in table {Accessor.TableName} by last id", e);
            }
        }
        public T UpdateExisting(long id, T row)
        {
            var updatableRow = FindByIdOrThrow(id);
            foreach (var columnName in Accessor.Columns)
            {
                if (!row.IsNull(columnName))
                    updatableRow[columnName] = row[columnName];
            }
            UpdateInTransaction();
            // в updatableRow старые значения
            return FindByIdOrThrow(id);
        }
        
        public T UpdateExisting(T row)
        {
            UpdateInTransaction();
            return FindByIdOrThrow((long) row[Accessor.Id]);
        }
        
        public T Save(T row)
        {
            if (row.IsNull(Accessor.Id))
                return Add(row);
            return UpdateExisting(row);
        }
        
        public bool DeleteById(long id)
        {
            FindByIdOrThrow(id).Delete();
            UpdateInTransaction();
            return true;
        }

        public bool Delete(T row)
        {
            row.Delete();
            UpdateInTransaction();
            return true;
        }
        
        public T Add(T row)
        {
            GetTable().Rows.Add(row);
            UpdateInTransaction();
            return row;
        }

        protected void ReadInTransaction()
        {
            DoInTransaction(Accessor.Read, Cache);
        }


        public void UpdateInTransaction()
        {
            DoInTransaction(Accessor.Update, Cache);
            Cache.AcceptChanges(); //todo влияет на что либо?
        }

        public ICollection<String> GetColumnNames()
        {
            return Accessor.Columns.ToList();  
        }
        
        private void DoInTransaction(
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
                Console.Error.WriteLine(e.Message);
                throw;
            }
        }
    }
}