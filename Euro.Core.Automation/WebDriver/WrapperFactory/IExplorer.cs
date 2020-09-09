// <copyright file="IExplorer.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.WebDriver.WrapperFactory
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;

    /// <summary>
    /// This class represents the internet explorer driver.
    /// </summary>
    internal class IExplorer : IDriver
    {
        private static IWebDriver Driver;

        /// <summary>
        /// Initialize Internet Explorer driver.
        /// </summary>
        /// <returns>IWebDriver</returns>
        public IWebDriver InitDriver()
        {
            string driverPath = AppDomain.CurrentDomain.BaseDirectory;
            System.Environment.SetEnvironmentVariable("webdriver.ie.driver", driverPath + "\\IEDriverServer.exe");
            Driver = new InternetExplorerDriver();
            return Driver;
        }
    }
}
