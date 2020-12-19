// using System;
// using BL;
// using NUnit.Framework;
//
// namespace DLTests
// {
//     /**
//      * Тесты crud класса AbstractLogic на примере BrandLogic
//      */
//     [TestFixture]
//     public class CrudLogicTest
//     {
//         private BrandLogic _brandLogic;
//
//         [SetUp]
//         public void Init()
//         {
//             _brandLogic = new BrandLogic();
//         }
//
//         [Test]
//         public void GetAllTest()
//         {
//             Assert.AreEqual(8, _brandLogic.FindAll().Count);
//         }
//
//         [TestCase(1)]
//         public void FindById(long id)
//         {
//             Assert.AreEqual(id, _brandLogic.FindByIdOrThrow(id).Id);
//         }
//
//         [TestCase(1, "updated")]
//         public void AddAndUpdateAndDeleteTest(int id, String updatedName)
//         {
//             var row = _brandLogic.NewRow();
//             row.Name = "test";
//             // foreach (var column in _brandLogic.Accessor.Columns)
//             // {
//             //     var value = row[column];
//             //     switch (value)
//             //     {
//             //         case String t1:
//             //             value = "test";
//             //             break;
//             //         case long t2:
//             //             value = 2;
//             //             break;
//             //         case DateTime t3:
//             //             value = DateTime.Now;
//             //             break;
//             //         default: throw new SystemException("error");
//             //     }
//             //     row[column] = value;
//             // }
//             _brandLogic.Add(row);
//             row = _brandLogic.FindByLastId();
//             var newId = row.Id;
//             Assert.AreEqual("test", row.Name);
//             row.Name = updatedName;
//             _brandLogic.UpdateExisting(row);
//             Assert.AreEqual(updatedName, row.Name);
//             _brandLogic.DeleteById(row.Id);
//             Assert.Throws(typeof(SystemException), () => _brandLogic.FindByIdOrThrow(newId));
//             Assert.AreEqual(1, newId);
//         }
//     }
// }