using System;
using System.Collections.Generic;
using System.Linq;
using lab1;
using NUnit.Framework;

namespace DATests
{
    [TestFixture]
    public class ServiceTest : BaseTest<DataSet1.ServiceRow>
    {
        [TestCase(584,"Кузовной ремонт" , 83, 20, 4, 1167.00)]
        public void GetAll(int count, String name, Int64 carId, Int64 workerId,Int64 typeId, Decimal amount)
        {
            var accessor = new ServiceAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var list = GetAllBaseTest(accessor, dataSet1, count);
            Assert.AreEqual(2, list[0].Id);
            CheckRow(list[0], name , carId, workerId, typeId, amount);
        }

        [TestCase(44, "Кузовной ремонт", 77, 10, 14, 2976.00)]
        public void FindByIdTest(Int64 id, String name, Int64 carId, Int64 workerId,Int64 typeId, Decimal amount)
        {
            var accessor = new ServiceAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var model = FindByIdBaseTest(accessor, dataSet1, id);
            CheckRow(model, name , carId, workerId, typeId, amount);
        }


        [TestCase(44, "Консультация")]
        public void UpdateNameTest(Int64 id, String newName)
        {
            var accessor = new ServiceAccessor();
            DataSet1 dataSet1 = new DataSet1();
            UpdateColumnBaseTest(accessor, dataSet1, id, "Name", newName);
        }


        [TestCase("Новая тестовая услуга", 77, 14, 12, 3526.00)]
        public void AddNewTypeServiceAndDeleteThemTest(String newName, Int64 carId, Int64 workerId,Int64 typeId, Decimal amount)
        {
            var workerAccessor = new WorkerAccessor();
            var typeAccessor = new TypeAccessor();
            var carAccessor = new CarAccessor();
            var serviceAccessor = new ServiceAccessor();
            DataSet1 dataSet1 = new DataSet1();

            // Проверим, что такой работник есть
            DoInTransaction(workerAccessor.Read, dataSet1);
            var workerRows = Select($"Id = '{workerId}'", dataSet1.Worker);
            Assert.AreEqual(1, workerRows.Count);

            // Проверим, что такой тип есть
            DoInTransaction(typeAccessor.Read, dataSet1);
            var typeRows = Select($"Id = '{typeId}'", dataSet1.TypeService);
            Assert.AreEqual(1, typeRows.Count);
            
            // Проверим, что такой авто есть
            DoInTransaction(typeAccessor.Read, dataSet1);
            var carRows = Select($"Id = '{carId}'", dataSet1.Car);
            Assert.AreEqual(1, typeRows.Count);
            
            // Читаем существующие, с таким именем не должно быть
            DoInTransaction(serviceAccessor.Read, dataSet1);
            var dataRows = Select(dataSet1, $"Name = '{newName}' and CarId = '{carId}'");
            Assert.AreEqual(0, dataRows.Count);
            // Добавим и проверим
            var newRow = dataSet1.Service.NewServiceRow();
            newRow.Name = newName;
            newRow.Amount = amount;
            newRow.Time = DateTime.Now;
            newRow.CarId = carId;
            newRow.TypeId = typeId;
            newRow.WorkerId = workerId;
            dataSet1.Service.Rows.Add(newRow);
            DoInTransaction(serviceAccessor.Update, dataSet1);
            dataSet1 = new DataSet1();
            DoInTransaction(serviceAccessor.Read, dataSet1);
            var list = Select(dataSet1, $"Name = '{newName}' and CarId = '{carId}'");
            Assert.AreEqual(1, list.Count);
            CheckRow(list.First(), newName, carId, workerId, typeId, amount);
            
            //Удаление
            list.First().Delete();
            DoInTransaction(serviceAccessor.Update, dataSet1);
            DoInTransaction(serviceAccessor.Read, dataSet1);
            dataRows = Select(dataSet1, $"Name = '{newName}' and CarId = '{carId}'");
            Assert.AreEqual(0, dataRows.Count);
        }

        [TestCase( 52, 2)]
        public void FindAllByCarId(Int64 carId, Int64 countModels)
        {
            DataSet1 dataSet1 = new DataSet1();
            FindAllByParentIdBaseTest(new ServiceAccessor(), new CarAccessor(), dataSet1.Car,
                dataSet1, "CarId", carId, countModels);
        }
        
        [TestCase( 11, 29)]
        public void FindAllByWorkerId(Int64 workerId, Int64 countModels)
        {
            DataSet1 dataSet1 = new DataSet1();
            FindAllByParentIdBaseTest(new ServiceAccessor(), new WorkerAccessor(), dataSet1.Worker,
                dataSet1, "WorkerId", workerId, countModels);
        }
                
        [TestCase( 5, 47)]
        public void FindAllByTypeId(Int64 typeId, Int64 countModels)
        {
            DataSet1 dataSet1 = new DataSet1();
            FindAllByParentIdBaseTest(new ServiceAccessor(), new TypeAccessor(), dataSet1.TypeService,
                dataSet1, "TypeId", typeId, countModels);
        }
        public void CheckRow(DataSet1.ServiceRow row, String name, Int64 carId, Int64 workerId,Int64 typeId, Decimal amount)
        {
            Assert.AreEqual(name, row.Name);
            Assert.AreEqual(carId, row.CarId);
            Assert.AreEqual(workerId, row.WorkerId);
            Assert.AreEqual(typeId, row.TypeId);
            Assert.AreEqual(0, amount.CompareTo(row.Amount));
        }
        
        public override List<DataSet1.ServiceRow> Select(DataSet1 dataSet1, String filter)
        {
            return Select(filter, dataSet1.Service);
        }
    }
}