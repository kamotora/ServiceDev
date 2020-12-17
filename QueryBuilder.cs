using System;

namespace lab1
{
    public class QueryBuilder
    {
        public string Query { get; private set; } = "";

        private static string Joined(params string[] strings) {
            return string.Join(", ", strings);
        }
        private static string[] Atted(params string[] strings) {
            string[] atted = new string[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                atted[i] = '@' + strings[i];        
            }
            return atted;
        }
        private static string[] Equaled(params string[] strings) {
            string[] equaled = new string[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                equaled[i] = strings[i] + "=@" + strings[i];
            }
            return equaled;
        }

        public QueryBuilder Select()
        {
            Select("*");
            return this;
        }
        public QueryBuilder Select(params string[] columns)
        {
            Query += "SELECT " + Joined(columns) + " ";
            return this;
        }
        public QueryBuilder From(string tableName) {
            Query += "FROM " + tableName + " ";
            return this;
        }
        public QueryBuilder Insert(string tableName, params string[] columns)
        {
            Query += "INSERT INTO " + 
                tableName + " (" + 
                Joined(columns) + ") VALUES (" + 
                Joined(Atted(columns)) + ")";
            return this;
        }
        public QueryBuilder Update(string tableName, params string[] columns)
        {
            Query += "UPDATE " +
                tableName + " SET " + Joined(Equaled(columns));
            
            Console.WriteLine(Query);
            return this;
        }
        public QueryBuilder Where(string column)
        {
            Query += " WHERE " + Equaled(column)[0];
            return this;
        }
        public QueryBuilder Delete()
        {
            Query += "DELETE ";
            return this;
        }
    }
}