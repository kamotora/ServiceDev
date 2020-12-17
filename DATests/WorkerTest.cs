using System;
using System.Collections.Generic;
using System.Linq;
using lab1;
using NUnit.Framework;

namespace DATests
{
    [TestFixture]
    public class WorkerTest : BaseTest<DataSet1.WorkerRow>
    {
        [TestCase(20,"Королев", "Иван", "Ярославович", "79816654877")]
        public void GetAll(int count, String surname, String name, String middlename,String phone)
        {
            var accessor = new WorkerAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var list = GetAllBaseTest(accessor, dataSet1, count);
            Assert.AreEqual(1, list[0].Id);
            CheckRow(list[0],surname, name, middlename, phone);
        }

        [TestCase(12, "Иванов", "Алексей", "Егорович", "79682445712")]
        public void FindByIdTest(Int64 id, String surname, String name, String middlename,String phone)
        {
            var accessor = new WorkerAccessor();
            DataSet1 dataSet1 = new DataSet1();
            var model = FindByIdBaseTest(accessor, dataSet1, id);
            CheckRow(model,surname, name, middlename, phone);
        }


        [TestCase(16, "Григорий")]
        public void UpdateNameTest(Int64 id, String newName)
        {
            var accessor = new WorkerAccessor();
            DataSet1 dataSet1 = new DataSet1();
            UpdateColumnBaseTest(accessor, dataSet1, id, "FirstName", newName);
        }


        [TestCase("Репин", "Артём", "Сергеевич", "79999999999")]
        public void AddNewWorkerAndDeleteThemTest(String surname, String name, String middlename,String phone)
        {
            var workerAccessor = new WorkerAccessor();
            DataSet1 dataSet1 = new DataSet1();
            
            // Читаем существующие, с такими данными не должно быть
            DoInTransaction(workerAccessor.Read, dataSet1);
            var dataRows = Select(dataSet1, $"LastName = '{surname}' and Phone = '{phone}'");
            Assert.AreEqual(0, dataRows.Count);
            // Добавим и проверим
            var newRow = dataSet1.Worker.NewWorkerRow();
            newRow.LastName = surname;
            newRow.FirstName = name;
            newRow.MiddleName = middlename;
            newRow.Phone = phone;
            dataSet1.Worker.AddWorkerRow(newRow);
            DoInTransaction(workerAccessor.Update, dataSet1);
            dataSet1 = new DataSet1();
            DoInTransaction(workerAccessor.Read, dataSet1);
            var list = Select(dataSet1, $"LastName = '{surname}' and Phone = '{phone}'");
            Assert.AreEqual(1, list.Count);
            CheckRow(list.First(), surname, name, middlename, phone);
            
            //Удаление
            list.First().Delete();
            DoInTransaction(workerAccessor.Update, dataSet1);
            DoInTransaction(workerAccessor.Read, dataSet1);
            dataRows =  Select(dataSet1, $"LastName = '{surname}' and Phone = '{phone}'");
            Assert.AreEqual(0, dataRows.Count);
        }
       
        public void CheckRow(DataSet1.WorkerRow row, String surname, String name, String middlename,String phone)
        {
            StringAssert.AreEqualIgnoringCase(surname, row.LastName);
            StringAssert.AreEqualIgnoringCase(name, row.FirstName);
            StringAssert.AreEqualIgnoringCase(middlename, row.MiddleName);
            StringAssert.AreEqualIgnoringCase(phone, row.Phone);
        }
        
        public override List<DataSet1.WorkerRow> Select(DataSet1 dataSet1, String filter)
        {
            return Select(filter, dataSet1.Worker);
        }
    }
}