using System;
using System.Collections.Generic;
using System.Data;
using lab1;

namespace BL
{
    public class ServiceLogic : AbstractJoinedLogic<DataSet1.ServiceRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new ServiceAccessor();
        }

        public ICollection<DataRow> Add(string name, decimal amount, long carId, long typeId, long workerId)
        {
            var serviceRow = CreateRow(name, amount, carId, typeId, workerId);
            serviceRow = Add(serviceRow);
            return Join(serviceRow.Id);
        }
        
        public ICollection<DataRow> Update(long id, string name, decimal amount, long carId, long typeId, long workerId)
        {
            var serviceRow = CreateRow(name, amount, carId, typeId, workerId);
            return Join(UpdateExisting(id, serviceRow).Id);
        }

        private DataSet1.ServiceRow CreateRow(string name, decimal amount, long carId, long typeId, long workerId)
        {
            LogicFactory.CarLogic.ThrowIfNotExist(carId);
            LogicFactory.TypeServiceLogic.ThrowIfNotExist(typeId);
            LogicFactory.WorkerLogic.ThrowIfNotExist(workerId);
            var serviceRow = NewRow();
            serviceRow.Name = name;
            serviceRow.CarId = carId;
            serviceRow.WorkerId = workerId;
            serviceRow.TypeId = typeId;
            serviceRow.Time = DateTime.Now;
            serviceRow.Amount = amount;
            return serviceRow;
        }

        public ICollection<DataRow> FindAllByAnyParam(string name, string carId, string typeId, string workerId)
        {
            // Валидация, т.к. позволяем ввести строку вместо числа
            LogicFactory.CarLogic.FindByIdIfIdNotNull(carId);
            LogicFactory.TypeServiceLogic.FindByIdIfIdNotNull(typeId);
            LogicFactory.WorkerLogic.FindByIdIfIdNotNull(workerId);
            FindAll();
            string filter = "";
            filter = AddFilter("Name", name, filter);
            filter = AddFilter("CarId", ParseIdOrNull(carId), filter);
            filter = AddFilter("TypeId", ParseIdOrNull(typeId), filter);
            filter = AddFilter("WorkerId", ParseIdOrNull(workerId), filter);
            return Join(Filter(filter));
        }

        /**
         * Вернуть дочерние сущности
         */
        public override ICollection<DataRow> GetParent(DataSet1.ServiceRow row)
        {
            var rows = LogicFactory.CarLogic.Join(row.CarId);
            rows.Add(LogicFactory.TypeServiceLogic.FindByIdOrThrow(row.TypeId));
            rows.Add(LogicFactory.WorkerLogic.FindByIdOrThrow(row.WorkerId));
            return rows;
        }
    }
}