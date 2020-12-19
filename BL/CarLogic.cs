using System.Collections.Generic;
using System.Data;
using lab1;

namespace BL
{
    public class CarLogic : AbstractJoinedLogic<DataSet1.CarRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new CarAccessor();
        }
        

        public ICollection<DataRow> FindAllByAnyParam(
            string name,
            string modelId,
            string clientId)
        {
            LogicFactory.ClientLogic.ThrowIfNotExist(clientId);
            LogicFactory.ModelLogic.ThrowIfNotExist(modelId);
            FindAll();
            string filter = "";
            filter = AddFilter("Name", name, filter);
            filter = AddFilter("ModelId", ParseIdOrNull(modelId), filter);
            filter = AddFilter("ClientId", ParseIdOrNull(clientId), filter);
            return Join(Filter(filter));
        }

        public ICollection<DataRow> Add(string name, long modelId, long clientId)
        {
            var car = CreateCarRow(name, modelId, clientId);
            car = Add(car);
            return Join(car.Id);
        }
        
        public ICollection<DataRow> Update(long id, string name, long modelId, long clientId)
        {
            var car = CreateCarRow(name, modelId, clientId);
            car = UpdateExisting(id, car);
            return Join(car.Id);
        }

        private DataSet1.CarRow CreateCarRow(string name, long modelId, long clientId)
        {
            // пародия на валидацию
            LogicFactory.ClientLogic.ThrowIfNotExist(clientId);
            LogicFactory.ModelLogic.ThrowIfNotExist(modelId);
            var car = NewRow();
            car.Name = name;
            car.ModelId = modelId;
            car.ClientId = clientId;
            return car;
        }

        /**
         * Вернуть дочерние сущности
         */
        public override ICollection<DataRow> GetParent(DataSet1.CarRow row)
        {
            var rows = LogicFactory.ModelLogic.Join(row.ModelId);
            rows.Add(LogicFactory.ClientLogic.FindByIdOrThrow(row.ClientId));
            return rows;
        }
    }
}