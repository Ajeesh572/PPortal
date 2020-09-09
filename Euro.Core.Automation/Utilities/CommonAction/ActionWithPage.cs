// <copyright file="ActionWithPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.CommonAction
{
    using OpenQA.Selenium;
    using WebDriver;

    /// <summary>
    /// Class that works with page actions
    /// </summary>
    public static partial class CommonActions
    {
        /// <summary>
        /// Opens a new tab with java script.
        /// </summary>
        public static void OpenNewTabWithJavaScript()
        {
            WebDriverUtils.GetJsExecutor().ExecuteScript("window.open()");
        }

        /// <summary>
        /// Scrolls the page horizontally and/or vertically
        /// </summary>
        /// <param name="xSpaces">Amount of spaces that page will scroll horizontally</param>
        /// <param name="ySpaces">Amount of spaces that page will scroll vertically</param>
        public static void ScrollPage(string xSpaces, string ySpaces)
        {
            IJavaScriptExecutor js = WebDriverManager.Instance.GetWebDriver as IJavaScriptExecutor;
            js.ExecuteScript("javascript:window.scrollBy( " + xSpaces + " , " + ySpaces + ")");
        }

        /// <summary>
        /// This method refresh current page
        /// </summary>
        public static void RefreshPage()
        {
            IWebDriver driver = WebDriverManager.Instance.GetWebDriver;
            driver.Navigate().Refresh();
        }

        /// <summary>
        /// Navigates back to previous page
        /// </summary>
        public static void NavigateBack()
        {
            WebDriverManager.Instance.GetWebDriver.Navigate().Back();
        }

        /// <summary>
        /// Gives the currentUrl in browser
        /// </summary>
        /// <returns>returns next open browser tab url</returns>
        public static string GetNextTabUrl()
        {
            IWebDriver driver = WebDriverManager.Instance.GetWebDriver;
            string tab = driver.WindowHandles[1];
            WebDriverUtils.SwitchToWindowByName(tab);
            return driver.Url;
        }
    }
}
