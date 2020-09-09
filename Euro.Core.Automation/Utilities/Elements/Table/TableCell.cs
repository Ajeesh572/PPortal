// <copyright file="TableCell.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Table
{
    using Interfaces;
    using Logger;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents Cell class.
    /// </summary>
    public class TableCell : ITableCell
    {
        private readonly IWebElement cellElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableCell"/> class.
        /// </summary>
        /// <param name="element">Cell element.</param>
        public TableCell(IWebElement element)
        {
            cellElement = element;
        }

        /// <inheritdoc />
        public void Click()
        {
            Logging.Debug($"Clicking '{nameof(cellElement)}' cell");

            cellElement.Click();
        }

        /// <inheritdoc />
        public string Contents
        {
            get
            {
                var content = cellElement.Text;
                return content;
            }
        }

        /// <inheritdoc />
        public IWebElement GetWebElement()
        {
            return cellElement;
        }

        /// <inheritdoc />
        public IWebElement FindWebElement(By xpath)
        {
            return GetWebElement().FindElement(xpath);
        }

        /// <inheritdoc />
        public Select GetAsSelect(By xpath = null)
        {
            var element = FindWebElement(xpath ?? By.XPath(".//select"));
            return element == null ? null : new Select(element);
        }
    }
}
