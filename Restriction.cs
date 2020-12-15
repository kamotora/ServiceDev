// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using lab1;
//
// namespace Core
// {
//     class Restriction
//     {
//         Predicate<DataRow> predicate;
//         DataSet1 dataSet;
//         private Restriction(Predicate<DataRow> p, DataSet1 ds) {
//             predicate = p;
//             dataSet = ds;
//         }
//         public bool Validate(DataRow row) {
//             return predicate.Invoke(row);
//         }
//         public static List<Restriction> getRestrictions(DataSet1 ds, string tableName) {
//             List<Restriction> restrictions = new List<Restriction>();
//             switch (tableName.ToLower()) {
//                 case "books":
//                     fillBooksRestrictions(ds, restrictions);
//                     break;
//                 case "publishers":
//                     fillPublishersRestrictions(ds, restrictions);
//                     break;
//
//             }
//             return restrictions;
//         }
//
//         private static void fillPublishersRestrictions(DataSet1 ds, List<Restriction> restrictions)
//         {
//             List<string> forbiddenUrls = new List<string> { "www.mail.ru" };
//             restrictions.Add(new Restriction(row =>
//             {
//                 DataSet1.PublishersRow publishersRow = (DataSet1.PublishersRow)row;
//                 return !forbiddenUrls.Contains(publishersRow.url);
//             }, ds));
//         }
//
//         private static void fillBooksRestrictions(DataSet1 ds, List<Restriction> restrictions) {
//             int booksLimit = 2;
//             restrictions.Add(new Restriction(row => 
//             {
//                 DataSet1.BooksRow booksRow = (DataSet1.BooksRow) row;
//                 return ds.Books.AsEnumerable().Where(r => r.author_id == booksRow.author_id).Count() <= booksLimit;
//             }, ds));
//         }
//     }
// }