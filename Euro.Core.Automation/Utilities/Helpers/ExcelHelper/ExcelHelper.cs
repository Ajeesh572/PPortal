// <copyright file="ExcelHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.ExcelHelper
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using ExcelDataReader;

    /// <summary>
    /// Class that helps parsing an excel file
    /// </summary>
    public class ExcelHelper
    {
        private string excelFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelHelper"/> class.
        /// <param name="excelFile">location of Excel file</param>
        /// </summary>
        public ExcelHelper(string excelFile)
        {
            excelFilePath = excelFile;
        }

        /// <summary>
        /// takes the excel file and turns into a datatable
        /// </summary>
        /// <returns>the excel file in a datatable object</returns>
        public DataTable ExcelToDataTable()
        {
            FileStream stream = null;
            using (stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream);
                DataSet result = excelReader.AsDataSet();
                DataTable dataTable = result.Tables[0];

                int columnIndex = 0;
                int index = 0;
                foreach (DataColumn column in dataTable.Columns)
                {
                    column.ColumnName = dataTable.Rows[0][index + columnIndex].ToString();
                    index++;
                }

                dataTable.Rows[0].Delete();
                dataTable.AcceptChanges();
                stream.Close();
                return dataTable;
            }
        }

        /// <summary>
        /// Gets column values from DataTable
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="self">Column Name of Data Table</param>
        /// <returns>Column Values</returns>
        public IEnumerable<T> ColumnValues<T>(DataColumn self)
        {
            return self.Table.Select().Select(dr => (T)Convert.ChangeType(dr[self], typeof(T)));
        }
    }
}