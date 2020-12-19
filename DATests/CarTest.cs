using System;
using System.Collections.Generic;
using System.Linq;
using lab1;
using NUnit.Framework;

namespace DATests
{
    [TestFixture]
    public class CarTest : BaseTest<DataSet1.CarRow>
    {
        [TestCase(150, 78, 40)]
        public void GetAll(int count, Int64 modelIdFirstRow, Int64 clientIdFirstRow)
        {
            var accessor = new CarAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var list = GetAllBaseTest(accessor, dataSet1, count);
            Assert.AreEqual(1, list[0].Id);
            CheckRow(list[0], "Автомобиль", modelIdFirstRow, clientIdFirstRow);
        }

        [TestCase(55, 47, 2)]
        public void FindByIdTest(Int64 id, Int64 modelId, Int64 clientId)
        {
            var carAccessor = new CarAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var model = FindByIdBaseTest(carAccessor, dataSet1, id);
            CheckRow(model, "Автомобиль", modelId, clientId);
        }


        [TestCase(55, "Машина")]
        public void UpdateNameTest(Int64 id, String newName)
        {
            DataSet1 dataSet1 = new DataSet1();
            UpdateColumnBaseTest(new CarAccessor(), dataSet1, id, "Name", newName);
        }


        [TestCase("Новая тачка", 15, 11)]
        public void AddNewCarAndDeleteThemTest(String newName, Int64 modelId, Int64 clientId)
        {
            var modelAccessor = new ModelAccessor();
            var clientAccessor = new ClientAccessor();
            var carAccessor = new CarAccessor();
            DataSet1 dataSet1 = new DataSet1();

            // Проверим, что такая модель есть
            DoInTransaction(modelAccessor.Read, dataSet1);
            var modelRows = Select($"Id = '{modelId}'", dataSet1.Model);
            Assert.AreEqual(1, modelRows.Count);

            // Проверим, что такой клиент есть
            DoInTransaction(clientAccessor.Read, dataSet1);
            var clientRows = Select($"Id = '{clientId}'", dataSet1.Model);
            Assert.AreEqual(1, clientRows.Count);
            
            // Читаем существующие, с такими параметрами быть не должно
            DoInTransaction(carAccessor.Read, dataSet1);
            var dataRows = Select(dataSet1,
                $"Name = '{newName}' and ModelId = '{modelId}' and ClientId = {clientId}");
            Assert.AreEqual(0, dataRows.Count);
            // Добавим и проверим
            var newRow = dataSet1.Car.NewCarRow();
            newRow.Name = newName;
            newRow.ModelId = modelId;
            newRow.ClientId = clientId;
            dataSet1.Car.AddCarRow(newRow);
            DoInTransaction(carAccessor.Update, dataSet1);
            dataSet1 = new DataSet1();
            DoInTransaction(carAccessor.Read, dataSet1);
            var list = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(1, list.Count);
            CheckRow(newRow, newName, modelId, clientId);
            
            //Удаление
            list.First().Delete();
            DoInTransaction(carAccessor.Update, dataSet1);
            DoInTransaction(carAccessor.Read, dataSet1);
            dataRows = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(0, dataRows.Count);
        }

        [TestCase( 2, 4)]
        public void FindAllByModelId(Int64 modelId, Int64 countModels)
        {
            DataSet1 dataSet1 = new DataSet1();
            FindAllByParentIdBaseTest(new CarAccessor(), new ModelAccessor(), dataSet1.Model,
                dataSet1, "ModelId", modelId, countModels);
        }
        
        [TestCase( 2, 2)]
        public void FindAllByClientId(Int64 clientId, Int64 countModels)
        {
            DataSet1 dataSet1 = new DataSet1();
            FindAllByParentIdBaseTest(new CarAccessor(), new ClientAccessor(), dataSet1.Client,
                dataSet1, "ClientId", clientId, countModels);
        }
        
        public void CheckRow(DataSet1.CarRow row, String nameModel, Int64 modelId, Int64 clientId)
        {
            Assert.AreEqual(nameModel, row.Name);
            Assert.AreEqual(modelId, row.ModelId);
            Assert.AreEqual(clientId, row.ClientId);
        }
        
        public override List<DataSet1.CarRow> Select(DataSet1 dataSet1, String filter)
        {
            return Select(filter, dataSet1.Car);
        }
    }
}