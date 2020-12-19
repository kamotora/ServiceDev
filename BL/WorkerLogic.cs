using lab1;

namespace BL
{
    public class WorkerLogic : AbstractLogic<DataSet1.WorkerRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new WorkerAccessor();
        }
    }
}