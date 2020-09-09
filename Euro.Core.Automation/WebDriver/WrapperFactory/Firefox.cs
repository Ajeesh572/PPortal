// <copyright file="Firefox.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.WebDriver.WrapperFactory
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    internal class Firefox : IDriver
    {
        private static IWebDriver Driver;

        /// <summary>
        /// Initialize Firefox driver
        /// </summary>
        /// <returns>IWebDriver</returns>
        public IWebDriver InitDriver()
        {
            string driverPath = AppDomain.CurrentDomain.BaseDirectory;
            System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", driverPath + "\\geckodriver.exe");
            Driver = new FirefoxDriver();
            return Driver;
        }
    }
}
