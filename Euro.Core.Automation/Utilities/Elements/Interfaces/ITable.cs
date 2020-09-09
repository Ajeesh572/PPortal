// <copyright file="ITable.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a Table interface.
    /// </summary>
    public interface ITable : IGetWebElement
    {
        /// <summary>
        /// Gets column Id based on Column name.
        /// </summary>
        /// <param name="columnName">Column name.</param>
        /// <returns>Column id.</returns>
        int? GetColumnId(string columnName);

        /// <summary>
        /// Gets or sets gets Column Titles.
        /// </summary>
        IEnumerable<string> ColumnTitles { get; set; }

        /// <summary>
        /// Gets Column Rows.
        /// </summary>
        IEnumerable<ITableRow> Rows { get; }

        /// <summary>
        /// Finds rows base on certain criterions.
        /// </summary>
        /// <param name="searchString">Search data.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns>List of <see cref="ITableRow"/>></returns>
        IEnumerable<ITableRow> FindRows(string searchString = null, string columnName = null, bool equals = true);

        /// <summary>
        /// Finds rows base on certain criterions.
        /// </summary>
        /// <param name="searchString">Search data.</param>
        /// <param name="columnId">Column id.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns>List of <see cref="ITableRow"/>></returns>
        IEnumerable<ITableRow> FindRows(string searchString = null, int? columnId = null, bool equals = true);

        /// <summary>
        /// Finds row base on certain criterions.
        /// </summary>
        /// <param name="searchString">Search data.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns><see cref="ITableRow"/>></returns>
        ITableRow FindRow(string searchString = null, string columnName = null, bool equals = true);

        /// <summary>
        /// Finds row base on certain criterions.
        /// </summary>
        /// <param name="searchString">Search data.</param>
        /// <param name="columnId">Column id.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns><see cref="ITableRow"/>></returns>
        ITableRow FindRow(string searchString = null, int? columnId = null, bool equals = true);

        /// <summary>
        /// Finds rows base on certain criterions.
        /// </summary>
        /// <param name="searchData">Search data.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns>List of <see cref="ITableRow"/>></returns>
        IEnumerable<ITableRow> FindRows(IDictionary<string, string> searchData, bool equals = true);

        /// <summary>
        /// Finds rows base on certain criterions.
        /// </summary>
        /// <param name="searchData">Search data.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns>List of <see cref="ITableRow"/>></returns>
        IEnumerable<ITableRow> FindRows(IDictionary<int, string> searchData, bool equals = true);

        /// <summary>
        /// Finds row base on certain criterions.
        /// </summary>
        /// <param name="searchData">Search data.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns><see cref="ITableRow"/>></returns>
        ITableRow FindRow(IDictionary<string, string> searchData, bool equals = true);

        /// <summary>
        /// Finds row base on certain criterions.
        /// </summary>
        /// <param name="searchData">Search data.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns><see cref="ITableRow"/>></returns>
        ITableRow FindRow(IDictionary<int, string> searchData, bool equals = true);

        /// <summary>
        /// Check if record exists base on search criterions.
        /// </summary>
        /// <param name="searchString">Search data.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns>If record exists.</returns>
        bool IsRecordExist(string searchString, string columnName = null, bool equals = true);

        /// <summary>
        /// Check if record exists base on search criterions.
        /// </summary>
        /// <param name="searchString">Search data.</param>
        /// <param name="columnId">Column id.</param>
        /// <param name="equals">Should content be equal.</param>
        /// <returns>If record exists.</returns>
        bool IsRecordExist(string searchString, int? columnId = null, bool equals = true);

        /// <summary>
        /// Get column contents by column name.
        /// </summary>
        /// <param name="columnName">Column name.</param>
        /// <returns>List of strings.</returns>
        IEnumerable<string> GetColumnContents(string columnName);

        /// <summary>
        /// Get column contents by column id.
        /// </summary>
        /// <param name="columnId">Column id.</param>
        /// <returns>List of strings.</returns>
        IEnumerable<string> GetColumnContents(int columnId);
    }
}