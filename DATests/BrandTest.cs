using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using lab1;
using NUnit.Framework;

namespace DATests
{
    [TestFixture]
    public class BrandTest
    {
        [Test]
        public void GetAll()
        {
            var brandAccessor = new BrandAccessor();
            DataSet1 dataSet1 = new DataSet1();
            IConnection connection = null;
            ITransaction transaction = null;
            try
            {
                connection = ConnectionFactory.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();
                brandAccessor.Read(connection, transaction, dataSet1);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
            }
            finally
            {
                connection?.Close();
            }

            List<DataRow> list = dataSet1.Brand.Select().ToList();;
            list.Sort((x, y) => ((Int64)x["Id"]).CompareTo((Int64)y["Id"]));  //сортируем по ид
            
            Assert.IsNotEmpty(list);
            Assert.AreEqual(8, list.Count);
            Assert.AreEqual(1, (Int64)list[0][brandAccessor.Id]);
            Assert.AreEqual("Chevrolet", (String)(list[0]["Name"]));
        }
        
    }
    

}