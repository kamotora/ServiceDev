namespace lab1
{
    public class TypeAccessor : AbstractDataAccessor
    {
        public TypeAccessor()
        {
            tableName = "TypeService";
            columnNames = new[] {"Name"};
        }
    }
}