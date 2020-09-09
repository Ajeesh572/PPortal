// <copyright file="Chrome.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.WebDriver.WrapperFactory
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Utilities;
    using Utilities.Logger;

    public class Chrome : IDriver
    {
        private static IWebDriver Driver;

        /// <summary>
        /// Initialize Chrome driver
        /// </summary>
        /// <returns>IWebDriver</returns>
        public IWebDriver InitDriver()
        {
            ChromeOptions options = new ChromeOptions();
            return InitDriver(options);
        }

        public IWebDriver InitDriver(ChromeOptions options)
        {
            string driverPath = AppDomain.CurrentDomain.BaseDirectory;
            Logging.Debug($"************ {driverPath}");
            InitDefaultValuesForChromeOptions(options);
            Logging.Debug($"************ Before Init Chrome driver");
            Driver = new ChromeDriver(driverPath, options);
            Logging.Debug($"************ After Init Chrome driver");
            return Driver;
        }

        private void InitDefaultValuesForChromeOptions(ChromeOptions options)
        {
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-impl-side-painting");
            WebDriverUtils.CreateBrowserDowloadFolder();
            options.AddUserProfilePreference("download.default_directory", WebDriverUtils.GetBrowserDownloadFolder());
            options.AddUserProfilePreference("disable-popup-blocking", "true");
        }
    }
}
