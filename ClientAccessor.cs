namespace lab1
{
    public class ClientAccessor : AbstractDataAccessor
    {
        public ClientAccessor()
        {
            tableName = "Client";
            columnNames = new[] {"LastName","FirstName", "MiddleName", "Phone"};
        }
    }
}