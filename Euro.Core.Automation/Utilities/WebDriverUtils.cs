// <copyright file="WebDriverUtils.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Castle.Core.Internal;
    using CommonAction;
    using Logger;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.Extensions;
    using OpenQA.Selenium.Support.UI;
    using WebDriver;

    /// <summary>
    /// This class contains methods related with webdriver actions.
    /// </summary>
    public static class WebDriverUtils
    {
        /// <summary>
        /// This method provides actions to perform over elements.
        /// </summary>
        /// <returns>Actions.</returns>
        public static Actions GetActions()
        {
            return new Actions(WebDriverManager.Instance.GetWebDriver);
        }

        /// <summary>
        /// This method provides js executor.
        /// </summary>
        /// <returns>Js executor.</returns>
        public static IJavaScriptExecutor GetJsExecutor() =>
            WebDriverManager.Instance.GetWebDriver as IJavaScriptExecutor;

        /// <summary>
        /// Gets the url when the driver is currently.
        /// </summary>
        /// <returns>the url.</returns>
        public static string GetUrl()
        {
            try
            {
                return WebDriverManager.Instance.GetWebDriver.Url;
            }
            catch (WebDriverException)
            {
                Logging.Error("Impossible to get url of current window");
                return string.Empty;
            }
        }

        /// <summary>
        /// Redirects the web driver to an specific url.
        /// </summary>
        /// <param name="url">the url.</param>
        public static void GoToUrl(string url)
        {
            WebDriverManager.Instance.GetWebDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// This method returns all the windows were open with webdriver.
        /// </summary>
        /// <returns>the collection of windows.</returns>
        public static ReadOnlyCollection<string> GetCurrentWindows()
        {
            return WebDriverManager.Instance.GetCurrentWindows();
        }

        /// <summary>
        /// Switches to Iframe web element searched by web element.
        /// </summary>
        /// <param name="frameWebElement">Frame Web element <see cref="IWebElement"/>.</param>
        public static void SwitchToFrame(IWebElement frameWebElement)
        {
            frameWebElement.WaitUntilElementIsDisplayed();
            WebDriverManager.Instance.GetWebDriver.SwitchTo().Frame(frameWebElement);
        }

        /// <summary>
        /// Switches to Window searched by window name.
        /// </summary>
        /// <param name="windowName">Window name as string value.</param>
        public static void SwitchToWindowByName(string windowName)
        {
            WebDriverManager.Instance.GetWebDriver.SwitchTo().Window(windowName);
        }

        /// <summary>
        /// Opens new tab and switch to it.
        /// </summary>
        public static void OpenNewTabAndSwitchToIt()
        {
            CommonActions.OpenNewTabWithJavaScript();
            SwitchToWindowByName(WebDriverManager.Instance.GetWebDriver.WindowHandles.Last());
        }

        /// <summary>
        /// Switches to last opened tab.
        /// </summary>
        public static void SwitchToLastTab()
        {
            SwitchToWindowByName(GetCurrentWindows().Last());
        }

        /// <summary>
        /// Closes tab and back to firt driver.
        /// </summary>
        public static void CloseTabAndBackToFirstDriver()
        {
            var tabs = WebDriverManager.Instance.GetWebDriver.WindowHandles;
            if (tabs.Count > 1)
            {
                WebDriverManager.Instance.GetWebDriver.Close();
                SwitchToWindowByName(tabs.First());
            }
        }

        /// <summary>
        /// Waits until the driver has a specific number of windows intances.
        /// </summary>
        /// <param name="instancesNumber">Is the number of instances to wait</param>
        /// <returns>A driver with a specific number of instances.</returns>
        public static IWebDriver LoadWindowsIntances(int instancesNumber)
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(waitWindow => WebDriverManager.Instance.GetWebDriver.WindowHandles.Count == instancesNumber);
            return WebDriverManager.Instance.GetWebDriver;
        }

        /// <summary>
        /// Gets the Browser Version used
        /// </summary>
        /// <returns>Version of Browser</returns>
        public static string GetBrowserVersion()
        {
            var capabilities = ((RemoteWebDriver)WebDriverManager.Instance.GetWebDriver).Capabilities;
            var browserVersion = capabilities.GetCapability("version").ToString();
            if (browserVersion.IsNullOrEmpty())
            {
                browserVersion = capabilities.GetCapability("browserVersion").ToString();
            }

            return browserVersion;
        }

        /// <summary>
        /// Gets the Name of Browser
        /// </summary>
        /// <returns>Name of Browser</returns>
        public static string GetBrowserName()
        {
            return ConfigurationManager.AppSettings["Browser"];
        }

        /// <summary>
        /// Switch to a Window by URL part and stay there.
        /// </summary>
        /// <param name="urlPart">A part of an URL.</param>
        public static void SwitchToExactWindowByUrlPartAndStay(string urlPart)
        {
            SwitchToExactWindowByUrlPart(urlPart, () => { }, 2);
        }

        /// <summary>
        /// Switch to a Window by URL part and close this tab.
        /// </summary>
        /// <param name="urlPart">A part of an URL.</param>
        public static void SwitchToExactWindowByUrlPartAndClose(string urlPart)
        {
            SwitchToExactWindowByUrlPart(urlPart, CloseTabAndBackToFirstDriver, 2);
        }

        /// <summary>
        /// Switch to a Window by checking URL part.
        /// </summary>
        /// <param name="urlPart">A part of an URL.</param>
        /// <param name="action">Action to be done when a Window is found</param>
        /// <param name="timeToWaitSeconds">Time to wait (Seconds)</param>
        private static void SwitchToExactWindowByUrlPart(string urlPart, Action action, int timeToWaitSeconds)
        {
            IList<string> windows = GetCurrentWindows();
            foreach (var window in windows)
            {
                SwitchToWindowByName(window);
                CommonActions.WaitUntil(timeToWaitSeconds);
                if (GetUrl().Contains(urlPart))
                {
                    action.Invoke();
                    break;
                }
            }
        }

        /// <summary>
        /// Gets the message of the Alert.
        /// </summary>
        /// <returns>the message of the alert.</returns>
        public static string GetAlertMessage()
        {
            var alert = WebDriverManager.Instance.GetWebDriver.SwitchTo().Alert();
            string message = alert.Text;
            alert.Accept();
            return message.Replace("\r\n", string.Empty);
        }

        /// <summary>
        /// Waits until ajax is inactive
        /// </summary>
        public static void WaitUntilAjaxInactive()
        {
            var scriptAjaxIsActive = "return (typeof($) === 'undefined') ? true : !$.active;";
            WebDriverManager.Instance.GetWebDriverWait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript(scriptAjaxIsActive));
        }

        /// <summary>
        /// Checks whether alert presented
        /// </summary>
        /// <returns>True if alert presented, false otherwise</returns>
        public static bool IsAlertPresent()
        {
            var alert = ExpectedConditions.AlertIsPresent().Invoke(WebDriverManager.Instance.GetWebDriver);
            return alert != null;
        }

        /// <summary>
        /// Accept alert if alert present.
        /// </summary>
        public static void AcceptAlertIfPresent()
        {
            if (IsAlertPresent())
            {
                WebDriverManager.Instance.GetWebDriver.SwitchTo().Alert().Accept();
            }
        }

        /// <summary>
        ///  Scroll on the top of page by java script.
        /// </summary>
        public static void ScrollOnTheTopOfPage()
        {
            WebDriverManager.Instance.GetWebDriver.ExecuteJavaScript("window.scrollTo(0, 0);");
        }

        /// <summary>
        /// Get folder for download files for browser.
        /// </summary>
        /// <returns>Folder path.</returns>
        public static string GetBrowserDownloadFolder()
        {
            const string folderName = "Downloads";
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(currentDirectory, folderName);
        }

        /// <summary>
        /// Create if need folder for download files for browser.
        /// </summary>
        public static void CreateBrowserDowloadFolder()
        {
            Directory.CreateDirectory(GetBrowserDownloadFolder());
        }
    }
}
