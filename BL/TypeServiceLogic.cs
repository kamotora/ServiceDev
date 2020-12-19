using lab1;

namespace BL
{
    public class TypeServiceLogic : AbstractLogic<DataSet1.TypeServiceRow>
    {
        public DataSet1.TypeServiceRow Add(string name)
        {
            var row = CreateRow(name);
            return Add(row);
        }

        public DataSet1.TypeServiceRow Update(long id, string name)
        {
            var row = CreateRow(name);
            return UpdateExisting(id, row);
        }

        private DataSet1.TypeServiceRow CreateRow(string name)
        {
            var row = NewRow();
            row.Name = name;
            return row;
        }

        protected override AbstractDataAccessor CreateAccessor()
        {
            return new TypeAccessor();
        }
    }
}