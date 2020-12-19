using lab1;

namespace BL
{
    public class BrandLogic : AbstractLogic<DataSet1.BrandRow>
    {
        private DataSet1.BrandRow CreateRow(string name)
        {
            var row = NewRow();
            row.Name = name;
            return row;
        }
        public DataSet1.BrandRow Add(string name)
        {

            return Add(CreateRow(name));
        }
        
        public DataSet1.BrandRow Update(long id, string name)
        {
            return UpdateExisting(id, CreateRow(name));
        }

        protected override AbstractDataAccessor CreateAccessor()
        {
            return new BrandAccessor();
        }
        
    }
}