// <copyright file="IGetWebElement.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Interfaces
{
    using OpenQA.Selenium;

    /// <summary>
    /// Gets internal WebElement;
    /// </summary>
    public interface IGetWebElement
    {
        /// <summary>
        /// Gets internal WebElement.
        /// </summary>
        /// <returns><see cref="IWebElement"/></returns>
        IWebElement GetWebElement();
    }
}