// <copyright file="Table.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Table
{
    using System.Collections.Generic;
    using System.Linq;
    using Euro.Core.Automation.Utilities.Elements.Enums;
    using Interfaces;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents a Table class.
    /// </summary>
    public class Table : BaseTable, IGetWebElement
    {
        private readonly By rowLocator;
        private readonly IWebElement tableElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="element">Table element</param>
        public Table(IWebElement element, By rowLocator) : base(element)
        {
            tableElement = element;
            this.rowLocator = rowLocator;
        }

        public override IEnumerable<ITableRow> Rows
        {
            get
            {
                return
                    tableElement.FindElements(rowLocator)
                        .Select(tr => new TableRow(tr) { Parent = this });
            }
        }

        public CheckBox GetAsCheckbox(ITableRow row, string colName)
        {
            return GetAsCheckbox(row, GetColumnId(colName));
        }

        public CheckBox GetAsCheckbox(ITableRow row, int? colId)
        {
            var element = row.GetCell(colId.Value).GetWebElement().FindElement(By.CssSelector("input"));
            return element == null ? null : new CheckBox(element);
        }

        /// <inheritdoc />
        public IWebElement GetWebElement()
        {
            return tableElement;
        }

        /// <summary>
        /// Finds rows base on certain criterions.
        /// </summary>
        /// <param name="searchData">Search data.</param>
        /// <param name="columnId">Column id.</param>
        /// <returns>List of <see cref="ITableRow"/>></returns>
        public IEnumerable<ITableRow> FindRows(CheckBoxStateEnum searchData, int? columnId = null)
        {
            return Rows.Where(row =>
            (
                    columnId.HasValue
                        ? GetAsCheckbox(row, columnId).GetState() == searchData
                        : row.Cells.Any(cell => new CheckBox(cell.GetWebElement()).GetState() == searchData)));
        }

        /// <summary>
        /// Finds rows base on certain criterions.
        /// </summary>
        /// <param name="searchData">Search data.</param>
        /// <param name="columnName">Column name.</param>
        /// <returns>List of <see cref="ITableRow"/>></returns>
        public IEnumerable<ITableRow> FindRows(CheckBoxStateEnum searchData, string columnName = null)
        {
            return FindRows(searchData, GetColumnId(columnName));
        }

        /// <summary>
        /// Finds row base on certain criterions.
        /// </summary>
        /// <param name="searchData">Search data.</param>
        /// <param name="columnName">Column name.</param>
        /// <returns><see cref="ITableRow"/>></returns>
        public ITableRow FindRow(CheckBoxStateEnum searchData, string columnName = null)
        {
            return FindRow(searchData, GetColumnId(columnName));
        }

        /// <summary>
        /// Finds row base on certain criterions.
        /// </summary>
        /// <param name="searchData">Search data.</param>
        /// <param name="columnId">Column id.</param>
        /// <returns><see cref="ITableRow"/>></returns>
        public ITableRow FindRow(CheckBoxStateEnum searchData, int? columnId = null)
        {
            return FindRows(searchData, columnId).FirstOrDefault();
        }

        /// <summary>
        /// Get column title names from table header.
        /// </summary>
        /// <param name="cellTitleXpath">Table header cell xpath.</param>
        /// <param name="attribute">Attribute to get inner text if it is needed(if some columns are hidden)</param>
        /// <returns>Get title names from table header.</returns>
        public IEnumerable<string> GetColumnTitles(string cellTitleXpath = ".//tr//th", string attribute = "")
        {
            var tableTitleColumns = tableElement.FindElements(By.XPath(cellTitleXpath));

            if (string.IsNullOrEmpty(attribute))
            {
                return tableTitleColumns.Select(cell => cell.Text);
            }
            else
            {
                return tableTitleColumns.Select(cell => cell.GetAttribute(attribute));
            }
        }

        /// <summary>
        /// Init column title names from table header.
        /// Example var table = new Table(tableElement).InitTableTitles();
        /// </summary>
        /// <returns>Instance of table.</returns>
        public Table InitTableTitles()
        {
            ColumnTitles = GetColumnTitles();
            return this;
        }

        /// <summary>
        /// Gets all the info from the particular column that is hidden
        /// </summary>
        /// <param name="columnName">name of column.</param>
        /// <returns>the list of values from the particular column</returns>
        public IEnumerable<string> GetInfoFromHiddenColumn(string columnName)
        {
            var index = GetColumnId(columnName) + 1;
            IList<IWebElement> hiddenTableColumn = tableElement.FindElements(By.XPath($"//tbody//td[{index}]/span"));
            List<string> tableColumnValues = new List<string>();
            foreach (var columnCellValue in hiddenTableColumn)
            {
                tableColumnValues.Add(columnCellValue.GetAttribute("textContent"));
            }

            return tableColumnValues;
        }
    }
}
