// <copyright file="DataTableHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.DataTableHelper
{
    using System.Collections.Generic;
    using System.Data;

    public class DataTableHelper
    {
        private DataTable table;

        public DataTableHelper(DataTable table)
        {
            this.table = table;
        }

        /// <summary>
        /// Gets Data column by column Name
        /// </summary>
        /// <param name="columnName">ColumnName</param>
        /// <returns>DataColumn</returns>
        public DataColumn GetDataColumn(string columnName)
        {
            DataColumn dataColumn = null;
            foreach (DataColumn column in table.Columns)
            {
                if (column.ToString().Equals(columnName))
                {
                    dataColumn = column;
                    break;
                }
            }

            return dataColumn;
        }

        /// <summary>
        /// Gets Datatable by required Columns
        /// </summary>
        /// <param name="columnNames">ColumnNames</param>
        /// <returns>DataTable with required Columns</returns>
        public DataTable GetDataTableWithOnlyExactColumns(List<string> columnNames)
        {
            foreach (string item in table.Columns)
            {
                if (!columnNames.Contains(item))
                {
                    table.Columns.Remove(item);
                }
            }

            table.AcceptChanges();
            return table;
        }
    }
}
