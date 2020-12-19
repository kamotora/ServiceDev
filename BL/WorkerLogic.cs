using System.Collections.Generic;
using lab1;

namespace BL
{
    public class WorkerLogic : AbstractLogic<DataSet1.WorkerRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new WorkerAccessor();
        }

        public DataSet1.WorkerRow Add(string lastName, string firstName, string middleName, string phone)
        {
            var row = CreateRow(lastName, firstName, middleName, phone);
            return Add(row);
        }

        public DataSet1.WorkerRow Update(long id, string lastName, string firstName, string middleName, string phone)
        {
            var row = CreateRow(lastName, firstName, middleName, phone);
            return UpdateExisting(id, row);
        }

        private DataSet1.WorkerRow CreateRow(string lastName, string firstName, string middleName, string phone)
        {
            var row = NewRow();
            row.FirstName = firstName;
            row.LastName = lastName;
            row.MiddleName = middleName;
            row.Phone = phone;
            return row;
        }

        public ICollection<DataSet1.WorkerRow> FindAllByAnyParam(
            string lastName,
            string firstName,
            string middleName,
            string phone)
        {
            FindAll();
            string filter = "";
            filter = AddFilter("LastName", lastName, filter);
            filter = AddFilter("FirstName", firstName, filter);
            filter = AddFilter("MiddleName", middleName, filter);
            filter = AddFilter("Phone", phone, filter);
            return Filter(filter);
        }
    }
}