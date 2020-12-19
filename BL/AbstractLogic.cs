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

        public List<T> FindAll()
        {
            ReadInTransaction();
            return Filter();
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
                    throw new SystemException($"Not found in table {Accessor.TableName} by id = {id}");
                return dataRow;
            }
            catch (Exception e)
            {
                throw new SystemException($"Error find in table {Accessor.TableName} by id = {id}", e);
            }
        }
        
        public void ThrowIfNotExist(long id)
        {
            ReadInTransaction();
            if(!GetTable().Rows.Contains(id))
                throw new SystemException($"ERROR! Not exists row in table {Accessor.TableName} by id = {id}");
        }
        
        public void ThrowIfNotExist(string id)
        {
            var idOrNull = ParseIdOrNull(id);
            if(idOrNull.HasValue && !GetTable().Rows.Contains(idOrNull.Value))
                throw new SystemException($"ERROR! Not exists row in table {Accessor.TableName} by id = {id}");
        }
        
        public T FindByLastId()
        {
            try
            {
                ReadInTransaction();
                return Filter(null, "Id DESC").First();
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
        
        protected internal T FindByIdIfIdNotNull(string id)
        {
            return !string.IsNullOrWhiteSpace(id) ? FindByIdOrThrow(long.Parse(id)) : null;
        }
        
        public bool DeleteById(long id)
        {
            FindByIdOrThrow(id).Delete();
            UpdateInTransaction();
            return true;
        }

        public T Add(T row)
        {
            GetTable().Rows.Add(row);
            UpdateInTransaction();
            return FindByLastId();
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

        public string AddFilter(string id, string value, string filter = "", string oper = "=")
        {
            if (!string.IsNullOrWhiteSpace(value)){
                if (!string.IsNullOrWhiteSpace(filter))
                    filter += " and ";
                filter += $"{id} {oper} '{value}'";
            }
            return filter;
        }
        
        public string AddFilter(string id, long? value = null, string filter = "", string oper = "=")
        {
            if (value != null){
                if (!string.IsNullOrWhiteSpace(filter))
                    filter += " and ";
                filter += $"{id} {oper} {value}";
            }
            return filter;
        }

        protected List<T> Filter(string filter = null, string sort = null)
        {
            return GetTable().Select(filter, sort).Select(row => (T) row).ToList();
        }
        
        protected List<DataRow> FilterNotCast(string filter = null, string sort = null)
        {
            return GetTable().Select(filter, sort).ToList();
        }

        public long? ParseIdOrNull(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
                return null;
            return long.Parse(id);
        }
    }
}