using lab1;

namespace BL
{
    public class TypeServiceLogic : AbstractLogic<DataSet1.TypeServiceRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new TypeAccessor();
        }
    }
}