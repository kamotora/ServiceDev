namespace lab1
{
    public class CarAccessor : AbstractDataAccessor
    {
        public CarAccessor()
        {
            tableName = "Car";
            columnNames = new[] {"Name","ClientId", "ModelId"};
        }
    }
}