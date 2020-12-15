namespace lab1
{
    public class BrandAccessor : AbstractDataAccessor
    {
        public BrandAccessor()
        {
            tableName = "Brand";
            columnNames = new[] {"Name"};
        }
    }
}