namespace lab1
{
    public class ModelAccessor : AbstractDataAccessor
    {
        public ModelAccessor()
        {
            tableName = "Model";
            columnNames = new[] {"Name", "BrandId"};
        }
    }
}