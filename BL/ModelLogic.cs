using lab1;

namespace BL
{
    public class ModelLogic : AbstractLogic<DataSet1.ModelRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new ModelAccessor();
        }
    }
}