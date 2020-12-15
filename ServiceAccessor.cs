namespace lab1
{
    public class ServiceAccessor : AbstractDataAccessor
    {
        public ServiceAccessor()
        {
            tableName = "Service";
            columnNames = new[] {"Name", "CarId", "WorkerId", "TypeId", "Amount", "Time"};
        }
    }
}