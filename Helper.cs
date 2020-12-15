﻿using System.Collections.Generic;
 using System.Data;
 using System.Diagnostics;
 using System.Linq;

 namespace lab1
{
    internal static class Helper
    {
        public static void Console(params string[] mes) {
            foreach (string s in mes)
            {
                Debug.WriteLine(s ?? "null");
            }  
        }
        private static int spacesBetweenColumn = 10;
        public static void PrintDataSet(DataSet1 set, string nameTable)
        {
            DataTable dataTable = set.Tables[nameTable];
            // меняем столбцы местами, ставим на первоме место id
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                if (dataTable.Columns[i].Caption.Equals("id"))
                {
                    dataTable.Columns[i].SetOrdinal(0);
                    break;
                }
            }

            var sizeColumn = new List<int>();
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                sizeColumn.Add(0);
            }

            // Считаем макс. размеры строк
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataTableRow = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (sizeColumn[j] < dataTableRow[j].ToString().Length)
                        sizeColumn[j] = dataTableRow[j].ToString().Length;
                }
            }

            // печатаем разделение ==============
            var sum = sizeColumn.Sum(variable => variable + spacesBetweenColumn);

            for (var i = 0; i < sum; i++)
            {
                Debug.Write("=");
            }

            Debug.WriteLine("\nnameTable = " + nameTable);

            // выводим название строк
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                Debug.Write(dataTable.Columns[j].Caption.PadRight((int)sizeColumn[j] + spacesBetweenColumn));
            }

            Debug.WriteLine("");
            // выводим строки
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataTableRow = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    Debug.Write(dataTableRow[j].ToString().PadRight((int)sizeColumn[j] + spacesBetweenColumn));
                }

                Debug.WriteLine("");
            }

            // печатаем разделение ============== 
            for (int i = 0; i < sum; i++)
            {
                Debug.Write("=");
            }

            Debug.WriteLine("");
        }
    }

}

