using System;
using System.Collections.Generic;
using System.Linq;
using lab1;
using NUnit.Framework;

namespace DATests
{
    [TestFixture]
    public class BrandTest : BaseTest<DataSet1.BrandRow>
    {
        [Test]
        public void GetAll()
        {
            var brandAccessor = new BrandAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var list = GetAllBaseTest(brandAccessor, dataSet1, 8);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual("Chevrolet", list[0].Name);
        }

        [TestCase(10)]
        public void FindByIdTest(Int64 id)
        {
            var brandAccessor = new BrandAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var brand = FindByIdBaseTest(brandAccessor, dataSet1, id);
            Assert.AreEqual("Nissan", brand.Name);
        }


        [TestCase(10, "BMW")]
        public void UpdateNameTest(Int64 id, String newName)
        {
            var brandAccessor = new BrandAccessor();
            DataSet1 dataSet1 = new DataSet1();
            UpdateColumnBaseTest(brandAccessor, dataSet1, id, "Name", newName);
        }


        [TestCase("Cadillac")]
        public void AddNewBrandAndDeleteThemTest(String newName)
        {
            var brandAccessor = new BrandAccessor();
            DataSet1 dataSet1 = new DataSet1();

            // Читаем существующие, с таким именем не должно быть
            DoInTransaction(brandAccessor.Read, dataSet1);
            var dataRows = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(0, dataRows.Count);
            // Добавим и проверим
            var newBrandRow = dataSet1.Brand.NewBrandRow();
            newBrandRow.Name = newName;
            dataSet1.Brand.Rows.Add(newBrandRow);
            DoInTransaction(brandAccessor.Update, dataSet1);
            dataSet1 = new DataSet1();
            DoInTransaction(brandAccessor.Read, dataSet1);
            var list = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(newName, list[0].Name);

            //Удаление
            list.First().Delete();
            DoInTransaction(brandAccessor.Update, dataSet1);
            DoInTransaction(brandAccessor.Read, dataSet1);
            dataRows = Select(dataSet1, $"Name = '{newName}'");
            Assert.AreEqual(0, dataRows.Count);
        }

        public override List<DataSet1.BrandRow> Select(DataSet1 dataSet1, string filter)
        {
            return Select(filter, dataSet1.Brand);
        }
    }
}