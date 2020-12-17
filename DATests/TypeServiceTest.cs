using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using lab1;
using NUnit.Framework;

namespace DATests
{
    [TestFixture]
    public class TypeServiceTest : BaseTest<DataSet1.TypeServiceRow>
    {
        [Test]
        public void GetAll()
        {
            var typeAccessor = new TypeAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var list = GetAllBaseTest(typeAccessor, dataSet1, 14);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual("Замена масла ДВС", list[0].Name);
        }

        [TestCase(10)]
        public void FindByIdTest(Int64 id)
        {
            var typeAccessor = new TypeAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var brand = FindByIdBaseTest(typeAccessor, dataSet1, id);
            Assert.AreEqual("Покраска бампера", brand.Name);
        }


        [TestCase(5, "Замена глушителя")]
        public void UpdateNameTest(Int64 id, String newName)
        {
            var typeAccessor = new TypeAccessor();
            DataSet1 dataSet1 = new DataSet1();
            UpdateColumnBaseTest(typeAccessor, dataSet1, id, "Name", newName);
        }


        [TestCase("Диагностика")]
        public void AddNewTypeServiceAndDeleteThemTest(String newName)
        {
            var typeAccessor = new TypeAccessor();
            DataSet1 dataSet1 = new DataSet1();

            // Читаем существующие, с таким именем не должно быть
            DoInTransaction(typeAccessor.Read, dataSet1);
            var dataRows = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(0, dataRows.Count);
            // Добавим и проверим
            var newRow = dataSet1.TypeService.NewTypeServiceRow();
            newRow.Name = newName;
            dataSet1.TypeService.Rows.Add(newRow);
            DoInTransaction(typeAccessor.Update, dataSet1);
            dataSet1 = new DataSet1();
            DoInTransaction(typeAccessor.Read, dataSet1);
            var list = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(newName, list[0].Name);

            //Удаление
            list.First().Delete();
            DoInTransaction(typeAccessor.Update, dataSet1);
            DoInTransaction(typeAccessor.Read, dataSet1);
            dataRows = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(0, dataRows.Count);
        }
        
        public override List<DataSet1.TypeServiceRow> Select(DataSet1 dataSet1, String filter)
        {
            return Select(filter, dataSet1.TypeService);
        }
    }
}