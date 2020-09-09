// <copyright file="IDriver.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.WebDriver.WrapperFactory
{
    using OpenQA.Selenium;

    internal interface IDriver
    {
        /// <summary>
        /// Initialize the Selenium web driver.
        /// </summary>
        /// <returns>IWebDriver</returns>
        IWebDriver InitDriver();
    }
}
