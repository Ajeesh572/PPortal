// <copyright file="DateTimePicker.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities
{
    using System;
    using System.Globalization;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Utilities.Logger;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;

    /// <summary>
    /// Provides functions to Manage Date Selection
    /// </summary>
    public class DateTimePicker
    {
        private readonly IWebElement element;
        private readonly IWebDriver driver;
        private string id;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePicker"/> class.
        /// </summary>
        /// <param name="iD">DateTimePicker id value</param>
        public DateTimePicker(string iD)
        {
            this.driver = WebDriverManager.Instance.GetWebDriver;
            this.element = driver.FindElement(By.Id(iD));
            this.id = iD;
        }

        /// <summary>
        /// A method to convert 12h datetime to 24h server-side time
        /// </summary>
        /// <param name="date">Datetime</param>
        /// <returns>datetime as server string time</returns>
        public static string CreateServerTimeBMA(DateTime date)
        {
            var dt = date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            Logging.Debug("Server-side parsed time :: " + dt);
            return dt;
        }

        /// <summary>
        /// Sets Date In Calender Field
        /// </summary>
        /// <param name="date">Date</param>
        public void SetValueServerSideBMA(string date)
        {
            ExecuteScript(date);
        }

        /// <summary>
        /// Set date in the YYYY-MMM-DD HH:mm format (example: 2015-01-22 12:00)
        /// </summary>
        /// <param name="date">Datetime date</param>
        public void Set_YYYY_MM_DD_HH_MM_value(DateTime date)
        {
            var dt = date.ToString("yyyy-MM-dd hh:mm:ss", new DateTimeFormatInfo());
            Logging.Debug("Parsed datetime is :: " + dt);

            ExecuteScript(dt);
        }

        /// <summary>
        /// A method to clear datetime picker with help of keys
        /// </summary>
        public void ClearDateTimePickerWithKeys()
        {
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
        }

        /// <summary>
        /// Executes the javaScript code
        /// </summary>
        /// <param name="format">The Date Time Format</param>
        private void ExecuteScript(string format)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"$('#{this.id}').val('{format}').trigger('change')");
        }
    }
}
