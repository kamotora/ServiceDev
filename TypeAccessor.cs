namespace lab1
{
    public class TypeAccessor : AbstractDataAccessor
    {
        public TypeAccessor()
        {
            tableName = "Type";
            columnNames = new[] {"Name"};
        }
    }
}