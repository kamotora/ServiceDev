using lab1;

namespace BL
{
    public class BrandLogic : AbstractLogic<DataSet1.BrandRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new BrandAccessor();
        }
    }
}