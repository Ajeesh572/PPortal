// <copyright file="DataBaseOperationHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.DataBaseHelper
{
    using System.Data;
    using System.Data.SqlClient;
    using Euro.Core.Automation.Utilities.DB;
    using Euro.Core.Automation.Utilities.Logger;

    /// <summary>
    /// Class that helps working with data base.
    /// </summary>
    public static class DataBaseOperationHelper
    {
        /// <summary>
        /// This method checks either value is presented or not in DB.
        /// </summary>
        /// <param name="dataBaseName">Name of data base</param>
        /// <param name="query">Query for getting value from DB</param>
        /// <param name="value">Value to search</param>
        /// <returns>True if value presented in DB</returns>
        public static bool IsValuePresentedInDb(DataBaseName dataBaseName, string query, string value)
        {
            var isValueExist = true;
            var dataTable = DBConnection.GetData(dataBaseName.ToString(), string.Format(query, value));
            try
            {
                if (dataTable.Rows.Count == 0)
                {
                    isValueExist = false;
                }
            }
            catch (SqlException e)
            {
                Logging.Error($"Something went wrong during getting data from database: {e.Message}");
            }

            return isValueExist;
        }

        /// <summary>
        /// Gets the value of a column from a table.
        /// </summary>
        /// /// <param name="table">the query result in format table.</param>
        /// <param name="columnName">the column name</param>
        /// <param name="row">the row number.</param>
        /// <returns>the value required.</returns>
        public static string GetColumnValue(this DataTable table, string columnName, int row = 0) => table.Rows[row][columnName].ToString();

        /// <summary>
        /// Gets value from Data base.
        /// </summary>
        /// <param name="query">Query for getting value from DB</param>
        /// <param name="columnName">Column name from which we should get value</param>
        /// <param name="parameterForQuery">Generic parameter which used in query</param>
        /// <returns>Column value by column name</returns>
        public static string GetColumnValueByColumnName(string query, string columnName, string parameterForQuery)
        {
            return GetColumnValue(DBConnection.GetData("OneApp", string.Format(query, parameterForQuery)), columnName, 0);
        }
    }
}
