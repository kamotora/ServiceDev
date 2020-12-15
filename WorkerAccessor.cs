namespace lab1
{
    public class WorkerAccessor : AbstractDataAccessor
    {
        public WorkerAccessor()
        {
            tableName = "Worker";
            columnNames = new[] {"LastName","FirstName", "MiddleName", "Phone"};
        }
    }
}