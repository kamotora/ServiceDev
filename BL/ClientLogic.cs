using lab1;

namespace BL
{
    public class ClientLogic : AbstractLogic<DataSet1.ClientRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new ClientAccessor();
        }
    }
}