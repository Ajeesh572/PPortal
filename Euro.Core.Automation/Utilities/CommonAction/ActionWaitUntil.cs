// <copyright file="ActionWaitUntil.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.CommonAction
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using Castle.Core.Internal;
    using Euro.Core.Automation.Utilities.Logger;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Class that wait until common actions
    /// </summary>
    public static partial class CommonActions
    {
        /// <summary>
        /// Sleep interval in milliseconds
        /// </summary>
        public const int SleepIntervalInMillSeconds = 500;

        /// <summary>
        /// Waits until a web element is displayed.
        /// </summary>
        /// <param name="webElement">Is the web element that method will wait</param>
        public static void WaitUntilElementIsDisplayed(this IWebElement webElement)
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(webDriver => webElement.Displayed);
        }

        /// <summary>
        /// Waits until a web element is displayed.
        /// </summary>
        /// <param name="by">Is the web element that method will wait</param>
        public static void WaitUntilElementIsDisplayed(By by)
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(webDriver => WebDriverManager.Instance.GetWebDriver.FindElement(by).Displayed);
        }

        /// <summary>
        /// Waits until a title of the page is expected one.
        /// </summary>
        /// <param name="title">Title of the page that method will wait</param>
        public static void WaitUntilTitleIs(string title)
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(ExpectedConditions.TitleIs(title));
        }

        /// <summary>
        /// Waits until a web element is clickable.
        /// </summary>
        /// <param name="webElement">Is the web element that method will wait</param>
        public static void WaitUntilElementIsClickeable(this IWebElement webElement)
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        /// <summary>
        /// Waits web element to be invisible on the page.
        /// </summary>
        /// <param name="webElement"><see cref="IWebElement"/></param>
        /// <param name="waitingIntervalInMillSeconds">How long to wait until element gets invisible</param>
        public static void WaitUntilElementIsInvisible(this IWebElement webElement, int waitingIntervalInMillSeconds = 30000)
        {
            WaitUntilInvisible(webElement, null, waitingIntervalInMillSeconds);
        }

        /// <summary>
        /// Waits until a web element is invisible of DOM and takes style tag of layout into account.
        /// </summary>
        /// <param name="by"><see cref="By"/></param>
        /// <param name="waitingIntervalInMillSeconds">How long to wait until element gets invisible</param>
        public static void WaitUntilElementIsInvisible(By by, int waitingIntervalInMillSeconds = 30000)
        {
            WaitUntilInvisible(null, by, waitingIntervalInMillSeconds);
        }

        /// <summary>
        /// Waits until web element text not empty.
        /// </summary>
        /// <param name="webElement"><see cref="IWebElement"/></param>
        public static void WaitUntilWebElementTextNotEmpty(this IWebElement webElement)
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(webDriver => !webElement.Text.IsNullOrEmpty());
        }

        /// <summary>
        /// Waits until a web element is visible of DOM and takes style tag of layout into account.
        /// </summary>
        /// <param name="by"><see cref="By"/></param>
        public static void WaitUntilElementIsVisible(By by)
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        /// <summary>
        /// This method helps to wait until pass an specific time in seconds.
        /// </summary>
        /// <param name="seconds">seconds</param>
        public static void WaitUntil(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        /// <summary>
        /// This Method will wait until the element is Enabled
        /// </summary>
        /// <param name="webElement">webElement to be enabled</param>
        /// <param name="attribute">attribute which states that the element is enabled or not</param>
        public static void WaitUntilElementIsEnabled(IWebElement webElement, string attribute = "disabled")
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(
                waitElement => webElement.GetAttribute(attribute) == null);
        }

        /// <summary>
        /// This method helps to wait until element is invisible.
        /// </summary>
        /// <param name="webElement"><see cref="IWebElement"/></param>
        /// <param name="by"><see cref="By"/></param>
        /// <param name="waitingIntervalInMillSeconds">How long to wait until element gets invisible</param>
        private static void WaitUntilInvisible(IWebElement webElement, By by, int waitingIntervalInMillSeconds)
        {
            var watch = Stopwatch.StartNew();
            var currentTime = watch.ElapsedMilliseconds;
            var howLongToWaitInMillSeconds = currentTime + waitingIntervalInMillSeconds;
            try
            {
                while (currentTime < howLongToWaitInMillSeconds)
                {
                    if (webElement == null)
                    {
                        if (WebDriverManager.Instance.GetWebDriver.FindElement(by).Displayed)
                        {
                            Thread.Sleep(SleepIntervalInMillSeconds);
                            currentTime = watch.ElapsedMilliseconds;
                        }
                    }
                    else if (by == null)
                    {
                        if (webElement.Displayed)
                        {
                            Thread.Sleep(SleepIntervalInMillSeconds);
                            currentTime = watch.ElapsedMilliseconds;
                        }
                    }
                }

                var errorMessage = "The element is still visible on the page!";
                Logging.Error(errorMessage);
                throw new WebDriverException(errorMessage);
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is StaleElementReferenceException)
                {
                    // skip if element isn't found.
                }
            }
        }
    }
}
