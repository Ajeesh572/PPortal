// <copyright file="TableRow.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents a Table row class.
    /// </summary>
    public class TableRow : ITableRow
    {
        private readonly IWebElement rowElement;

        /// <summary>
        /// Parent table.
        /// </summary>
        public ITable Parent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableRow"/> class.
        /// </summary>
        /// <param name="element">Table row element.</param>
        public TableRow(IWebElement element)
        {
            rowElement = element;
        }

        /// <inheritdoc />
        public IEnumerable<ITableCell> Cells
        {
            get { return rowElement.FindElements(By.CssSelector("td,th")).Select(td => new TableCell(td)); }
        }

        /// <inheritdoc />
        public ITableCell GetCell(string columnName)
        {
            var cellId = Parent.GetColumnId(columnName);
            if (!cellId.HasValue)
            {
                throw new Exception($"No column '{columnName}' found");
            }

            return GetCell(cellId.Value);
        }

        /// <inheritdoc />
        public ITableCell GetCell(int columnId)
        {
            return Cells.ElementAtOrDefault(columnId);
        }

        /// <inheritdoc />
        public IWebElement GetWebElement()
        {
            return rowElement;
        }
    }
}
