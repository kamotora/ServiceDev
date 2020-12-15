using System.Data;
using System.Linq;

namespace lab1
{
    public abstract class AbstractLogic
    {
        private AbstractDataAccessor _a;

        protected AbstractDataAccessor Accessor
        {
            get
            {
                if (_a == null)
                {
                    _a = ProvideWithAccessor();
                }

                return _a;
            }
        }

        protected IConnection Connection { get; }
        private DataSet1 _cache;

        public DataSet1 Cache
        {
            get
            {
                if (_cache == null)
                {
                    _cache = new DataSet1();
                }

                return _cache;
            }
        }

        protected abstract AbstractDataAccessor ProvideWithAccessor();

        public AbstractLogic(IConnection c)
        {
            Connection = c;
            // getting all records from db
            Connection.Open();

            ITransaction t = Connection.BeginTransaction();
            Accessor.Read(Connection, t, Cache);
            t.Commit();

            Connection.Close();
        }

        public DataSet1 GetRecordsDirectlyFromDb()
        {
            DataSet1 ds = new DataSet1();
            // getting all records from db
            Connection.Open();

            var t = Connection.BeginTransaction();
            Accessor.Read(Connection, t, ds);
            t.Commit();

            Connection.Close();
            return ds;
        }

        public DataRow NewRow()
        {
            return Cache.Tables[Accessor.TableName].NewRow();
        }

        public DataRow GetRecordById(int id)
        {
            return Cache.Tables[Accessor.TableName].Rows.Find(id);
        }

        public bool UpdateRecord(int id, DataRow row)
        {
            DataRow oldRow = GetRecordById(id);
            if (oldRow != null)
            {
                foreach (string columnName in Accessor.Columns)
                {
                    if (!row.IsNull(columnName))
                        oldRow[columnName] = row[columnName];
                }

                return true;
            }
            else return false;
        }

        public bool DeleteRecordById(int id)
        {
            DataRow toDelete = GetRecordById(id);
            toDelete?.Delete();
            return true;
        }

        public bool AddRecord(DataRow row)
        {
            // restriction for TableName
            // foreach (Restriction restriction in Restriction.getRestrictions(Cache, Accessor.TableName))
            // {
            //     if (!restriction.Validate(row))
            //         return false;
            // }
            Cache.Tables[Accessor.TableName].Rows.Add(row);
            //Cache.AcceptChanges();
            return true;
        }

        public int GetLastId()
        {
            return (int) Cache.Tables[Accessor.TableName].AsEnumerable().Max(r => r[Accessor.Id]);
        }

        public bool UpdateDbWithCache()
        {
            Connection.Open();
            var t = Connection.BeginTransaction();
            Accessor.Update(Connection, t, Cache);
            t.Commit();
            Connection.Close();
            Cache.AcceptChanges();
            return true;
        }

        public bool UpdateDbWithCache(DataSet1 cache)
        {
            Connection.Open();
            var t = Connection.BeginTransaction();
            Accessor.Update(Connection, t, cache);
            t.Commit();
            Connection.Close();
            //cache.AcceptChanges();
            return true;
        }
    }
}