using System.Collections.Generic;
using lab1;

namespace BL
{
    public class ClientLogic : AbstractLogic<DataSet1.ClientRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new ClientAccessor();
        }

        public DataSet1.ClientRow Add(string lastName, string firstName, string middleName, string phone)
        {
            var row = CreateClientRow(lastName, firstName, middleName, phone);
            return Add(row);
        }
        
        public DataSet1.ClientRow Update(long id, string lastName, string firstName, string middleName, string phone)
        {
            var row = CreateClientRow(lastName, firstName, middleName, phone);
            return UpdateExisting(id, row);
        }

        private DataSet1.ClientRow CreateClientRow(string lastName, string firstName, string middleName, string phone)
        {
            var row = NewRow();
            row.FirstName = firstName;
            row.LastName = lastName;
            row.MiddleName = middleName;
            row.Phone = phone;
            return row;
        }

        public ICollection<DataSet1.ClientRow> FindAllByAnyParam(
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