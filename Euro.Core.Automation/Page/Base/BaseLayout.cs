// <copyright file="BaseLayout.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Page.Base
{
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Abstract base layout used for page objects for mobile.
    /// </summary>
    public abstract class BaseLayout
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLayout"/> class.
        /// </summary>
        public BaseLayout()
        {
            this.Driver = WebDriver.MobileDriverManager.Instance.GetWebDriver;
            this.Wait = WebDriver.MobileDriverManager.Instance.GetWebDriverWait;
            IDTPageFactory.InitElements(this.Driver, this);
        }

        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        protected IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets the wait.
        /// </summary>
        protected WebDriverWait Wait { get; set; }
    }
}
