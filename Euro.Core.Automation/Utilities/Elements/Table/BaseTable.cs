// <copyright file="BaseTable.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Logger;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents a Table class.
    /// </summary>
    public class BaseTable : ITable
    {
        private readonly IWebElement tableElement;
        private IEnumerable<string> columnTitles;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTable"/> class.
        /// </summary>
        /// <param name="element">Table element.</param>
        public BaseTable(IWebElement element)
        {
            tableElement = element;
        }

        /// <inheritdoc />
        public int? GetColumnId(string columnName)
        {
            var titles = ColumnTitles;
            var titleIndex = titles.Contains(columnName) ? (int?)titles.ToList().IndexOf(columnName) : null;
            Logging.Debug($"Title Index for {columnName} Column is {titleIndex}");
            return titleIndex;
        }

        /// <inheritdoc />
        public IEnumerable<string> ColumnTitles
        {
            get => columnTitles;
            set
            {
                columnTitles = value;
                Logging.Debug("Present columns :: " + string.Join(", ", columnTitles));
            }
        }

        /// <inheritdoc />
        public virtual IEnumerable<ITableRow> Rows
        {
            get
            {
                return
                    tableElement.FindElements(By.CssSelector("tr"))
                        .Select(tr => new TableRow(tr) { Parent = this });
            }
        }

        /// <inheritdoc />
        public IEnumerable<ITableRow> FindRows(string searchString = null, string columnName = null, bool @equals = true)
        {
            return FindRows(searchString, GetColumnId(columnName), equals);
        }

        /// <inheritdoc />
        public IEnumerable<ITableRow> FindRows(string searchString = null, int? columnId = null, bool @equals = true)
        {
            return Rows.Where(row =>
                string.IsNullOrEmpty(searchString) ||
            (
                    (columnId.HasValue)
                        ? (equals
                            ? row.GetCell(columnId.Value).Contents.Equals(searchString)
                            : row.GetCell(columnId.Value).Contents.Contains(searchString))
                        : (equals
                            ? row.Cells.Any(cell => cell.Contents.Equals(searchString))
                            : row.Cells.Any(cell => cell.Contents.Contains(searchString)))));
        }

        /// <inheritdoc />
        public ITableRow FindRow(string searchString = null, string columnName = null, bool @equals = true)
        {
            return FindRow(searchString, GetColumnId(columnName), equals);
        }

        /// <inheritdoc />
        public ITableRow FindRow(string searchString = null, int? columnId = null, bool @equals = true)
        {
            return FindRows(searchString, columnId, equals).FirstOrDefault();
        }

        /// <inheritdoc />
        public IEnumerable<ITableRow> FindRows(IDictionary<string, string> searchData, bool @equals = true)
        {
            var dataWithColumnIds = searchData.ToDictionary(pair => GetColumnId(pair.Key) ?? -1, pair => pair.Value);
            if (dataWithColumnIds.ContainsKey(-1))
            {
                throw new Exception($"Column title for '{dataWithColumnIds[-1]}' is not found");
            }

            return FindRows(dataWithColumnIds, equals);
        }

        /// <inheritdoc />
        public IEnumerable<ITableRow> FindRows(IDictionary<int, string> searchData, bool @equals = true)
        {
            return
                Rows.Where(row =>
                    searchData.All(expectedData =>
                        equals
                            ? row.GetCell(expectedData.Key).Contents.Equals(expectedData.Value)
                            : row.GetCell(expectedData.Key).Contents.Contains(expectedData.Value)));
        }

        /// <inheritdoc />
        public ITableRow FindRow(IDictionary<string, string> searchData, bool @equals = true)
        {
            return FindRows(searchData, equals).FirstOrDefault();
        }

        /// <inheritdoc />
        public ITableRow FindRow(IDictionary<int, string> searchData, bool @equals = true)
        {
            return FindRows(searchData, equals).FirstOrDefault();
        }

        /// <inheritdoc />
        public bool IsRecordExist(string searchString, string columnName = null, bool @equals = true)
        {
            return IsRecordExist(searchString, GetColumnId(columnName), equals);
        }

        /// <inheritdoc />
        public bool IsRecordExist(string searchString, int? columnId = null, bool @equals = true)
        {
            return FindRows(searchString, columnId, equals).Any();
        }

        /// <inheritdoc />
        public IEnumerable<string> GetColumnContents(string columnName)
        {
            var id = GetColumnId(columnName);
            if (id == null)
            {
                throw new Exception($"No column '{columnName}' found");
            }

            return GetColumnContents(id.Value);
        }

        /// <inheritdoc />
        public IEnumerable<string> GetColumnContents(int columnId)
        {
            return Rows.Select(row => row.GetCell(columnId).Contents);
        }

        /// <inheritdoc />
        public IWebElement GetWebElement()
        {
            return tableElement;
        }
    }
}
