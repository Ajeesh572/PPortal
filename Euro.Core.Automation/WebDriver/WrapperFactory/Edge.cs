// <copyright file="Edge.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.WebDriver.WrapperFactory
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;

    /// <summary>
    /// This class represents the edge driver.
    /// </summary>
    internal class Edge : IDriver
    {
        private static IWebDriver Driver;

        /// <summary>
        /// Initialize Edge driver.
        /// </summary>
        /// <returns>IWebDriver</returns>
        public IWebDriver InitDriver()
        {
            string driverPath = AppDomain.CurrentDomain.BaseDirectory;
            System.Environment.SetEnvironmentVariable("webdriver.edge.driver", driverPath + "\\MicrosoftWebDriver.exe");
            Driver = new EdgeDriver();
            return Driver;
        }
    }
}
