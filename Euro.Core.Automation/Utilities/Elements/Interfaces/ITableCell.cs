// <copyright file="ITableCell.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Interfaces
{
    using OpenQA.Selenium;

    /// <summary>
    /// Represents Table cell interface.
    /// </summary>
    public interface ITableCell : IGetWebElement
    {
        /// <summary>
        /// Gets property of a cell content.
        /// </summary>
        string Contents { get; }

        /// <summary>
        /// Clicks a cell.
        /// </summary>
        void Click();

        /// <summary>
        /// Find WebElement in cell by xpath.
        /// </summary>
        /// <param name="xpath">Xpath for find.</param>
        /// <returns>Finded element</returns>
        IWebElement FindWebElement(By xpath);

        /// <summary>
        /// Find Select element in cell by xpath.
        /// </summary>
        /// <param name="xpath">Xpath for find.</param>
        /// <returns>Get Select from cell</returns>
        Select GetAsSelect(By xpath = null);
    }
}