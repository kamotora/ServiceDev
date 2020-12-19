using lab1;

namespace BL
{
    public class ServiceLogic : AbstractLogic<DataSet1.ServiceRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new ServiceAccessor();
        }
    }
}