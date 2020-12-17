using System;
using System.Collections.Generic;
using System.Linq;
using lab1;
using NUnit.Framework;

namespace DATests
{
    [TestFixture]
    public class ModelTest : BaseTest<DataSet1.ModelRow>
    {
        [Test]
        public void GetAll()
        {
            var modelAccessor = new ModelAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var list = GetAllBaseTest(modelAccessor, dataSet1, 84);
            Assert.AreEqual(1, list[0].Id);
            CheckRow(list[0], "Aveo", 1);
        }

        [TestCase(55)]
        public void FindByIdTest(Int64 id)
        {
            var modelAccessor = new ModelAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var model = FindByIdBaseTest(modelAccessor, dataSet1, id);
            CheckRow(model, "Camry", 13);
        }


        [TestCase(55, "Caldina")]
        public void UpdateNameTest(Int64 id, String newName)
        {
            var modelAccessor = new ModelAccessor();
            DataSet1 dataSet1 = new DataSet1();
            UpdateColumnBaseTest(modelAccessor, dataSet1, id, "Name", newName);
        }


        [TestCase("Corolla Spacio", 13)]
        public void AddNewTypeServiceAndDeleteThemTest(String newName, Int64 brandId)
        {
            var modelAccessor = new ModelAccessor();
            var brandAccessor = new BrandAccessor();
            DataSet1 dataSet1 = new DataSet1();

            // Проверим, что такой бренд есть
            DoInTransaction(brandAccessor.Read, dataSet1);
            var brandRows = Select($"Id = '{brandId}'", dataSet1.Brand);
            Assert.AreEqual(1, brandRows.Count);
            Assert.AreEqual("Toyota", brandRows.First().Name);
            
            // Читаем существующие, с таким именем не должно быть
            DoInTransaction(modelAccessor.Read, dataSet1);
            var dataRows = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(0, dataRows.Count);
            // Добавим и проверим
            var newRow = dataSet1.Model.NewModelRow();
            newRow.Name = newName;
            newRow.BrandId = brandId;
            dataSet1.Model.Rows.Add(newRow);
            DoInTransaction(modelAccessor.Update, dataSet1);
            dataSet1 = new DataSet1();
            DoInTransaction(modelAccessor.Read, dataSet1);
            var list = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(newName, list[0].Name);

            //Удаление
            list.First().Delete();
            DoInTransaction(modelAccessor.Update, dataSet1);
            DoInTransaction(modelAccessor.Read, dataSet1);
            dataRows = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(0, dataRows.Count);
        }

        [TestCase( 16, 11)]
        public void FindAllByBrandId(Int64 brandId, Int64 countModels)
        {
            var modelAccessor = new ModelAccessor();
            var brandAccessor = new BrandAccessor();
            DataSet1 dataSet1 = new DataSet1();
            FindAllByParentIdBaseTest(modelAccessor, brandAccessor,dataSet1.Brand,
                dataSet1, "BrandId", brandId, countModels);
        }

        public void CheckRow(DataSet1.ModelRow row, String nameModel, Int64 brandId)
        {
            Assert.AreEqual(nameModel, row.Name);
            Assert.AreEqual(brandId, row.BrandId);
        }
        
        public override List<DataSet1.ModelRow> Select(DataSet1 dataSet1, String filter)
        {
            var brandRows = Select(null, dataSet1.Brand);
            return Select(filter, dataSet1.Model);
        }
    }
}