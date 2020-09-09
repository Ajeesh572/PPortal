// <copyright file="DriverFactory.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.WebDriver
{
    using Euro.Core.Automation.WebDriver.WrapperFactory;
    using OpenQA.Selenium;

    /// <summary>
    /// Returns the correct instance of the driver.
    /// </summary>
    internal class DriverFactory
    {
        private const string Firefox = "Firefox";
        private const string Chrome = "Chrome";
        private const string IExplorer = "IExplorer";
        private const string Edge = "Edge";
        private const string PhantomJS = "PhantomJS";
        private const string Android = "Android";
        private const string IOs = "IOs";

        /// <summary>
        /// Get the correct instance of IWebDriver according the name given by parameter.
        /// </summary>
        /// <param name="browser">The browser or mobile os.</param>
        /// <returns><see cref="IWebDriver"/>The instance of web driver.</returns>
        public static IWebDriver GetDriver(string browser)
        {
            switch (browser)
            {
                case Firefox: return new Firefox().InitDriver();
                case Chrome: return new Chrome().InitDriver();
                case IExplorer: return new IExplorer().InitDriver();
                case Edge: return new Edge().InitDriver();
                case Android: return new Android().InitDriver();
                case IOs: return new IOs().InitDriver();
                default: return null;
            }
        }
    }
}
