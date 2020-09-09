// <copyright file="OneAppHelpers.cs" company="IDT">
// Copyright (c) IDT. All rights reserved.
// </copyright>

namespace Euro.Viracor.Labalert.Main
{
    using System.Data;

    /// <summary>
    /// Helper class for all projects from OneApp.
    /// </summary>
    public class ViracorHelpers
    {
        /// <summary>
        /// Gets the value of a column from a table.
        /// </summary>
        /// <param name="row">the row number.</param>
        /// <param name="columnName">the column name</param>
        /// <param name="table">the query result in format table.</param>
        /// <returns>the value required.</returns>
        public static string GetColumnValue(int row, string columnName, DataTable table)
        {
            return table.Rows[row][columnName].ToString();
        }
    }
}
