// <copyright file="ITableRow.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for a Table Row.
    /// </summary>
    public interface ITableRow : IGetWebElement
    {
        /// <summary>
        /// Get all cells.
        /// </summary>
        IEnumerable<ITableCell> Cells { get; }

        /// <summary>
        /// Get cell based on a column name.
        /// </summary>
        /// <param name="columnName">Column name.</param>
        /// <returns><see cref="ITableCell"/></returns>
        ITableCell GetCell(string columnName);

        /// <summary>
        /// Get cell based on a column index.
        /// </summary>
        /// <param name="columnId">Column index.</param>
        /// <returns><see cref="ITableCell"/></returns>
        ITableCell GetCell(int columnId);
    }
}