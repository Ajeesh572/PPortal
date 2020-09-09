// <copyright file="ActionWithElement.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.CommonAction
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Logger;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using WebDriver;

    /// <summary>
    /// Class that handles all common actions in the framework
    /// </summary>
    public static partial class CommonActions
    {

        /// <summary>
        /// Execute jsa script in browser.
        /// </summary>
        /// <param name="script">Script for execute</param>
        /// <param name="args">Arguments for pass in script</param>
        public static T ExecuteScript<T>(string script, params object[] args)
        {
            return (T)WebDriverUtils.GetJsExecutor().ExecuteScript(script, args);
        }

        /// <summary>
        /// Send Keys to input field.
        /// </summary>
        /// <param name="element">TextBox WebElement</param>
        /// <param name="value">Value to send to WebElement</param>
        public static void SendKeys(this IWebElement element, string value)
        {
            WaitUntilElementIsDisplayed(element);
            element.Clear();
            element.SendKeys(value);
        }

        /// <summary>
        /// Send Keys to input field with use Action class.
        /// </summary>
        /// <param name="element">TextBox WebElement</param>
        /// <param name="value">Value to send to WebElement</param>
        /// <returns>Return TextBox WebElement.</returns>
        public static IWebElement ActionSendKeys(this IWebElement element, string value)
        {
            WaitUntilElementIsDisplayed(element);
            WebDriverUtils.GetActions().MoveToElement(element).Click().SendKeys(value).Perform();
            return element;
        }

        /// <summary>
        /// Get instance of Action class.
        /// </summary>
        /// <returns>Return instance of Action class.</returns>
        public static Actions GetActions() => WebDriverUtils.GetActions();

        /// <summary>
        /// Clicks on an element.
        /// </summary>
        /// <param name="element">WebElement</param>
        public static void ClickElement(this IWebElement element)
        {
            WaitUntilElementIsClickeable(element);
            element.Click();
        }

        /// <summary>
        /// Clicks on WebElement by JavaScript.
        /// </summary>
        /// <param name="element"><see cref="IWebElement"/></param>
        public static void ClickElementByJavaScript(this IWebElement element)
        {
            WebDriverUtils.GetJsExecutor().ExecuteScript("arguments[0].click()", element);
        }

        /// <summary>
        /// Clicks on Locator by JavaScript.
        /// </summary>
        /// <param name="by"><see cref="By"/></param>
        public static void ClickElementByJavaScript(By by)
        {
            WebDriverUtils.GetJsExecutor().ExecuteScript("arguments[0].click()", WaitUntilLocatorExists(by));
        }

        /// <summary>
        /// Clicks on WebElement by Locator.
        /// </summary>
        /// <param name="by"><see cref="By"/></param>
        public static void ClickElementByLocator(By by)
        {
            IWebDriver driver = WebDriverManager.Instance.GetWebDriver;

            IWebElement element = driver.FindElement(by);
            try
            {
                ClickElement(element);
            }
            catch (StaleElementReferenceException)
            {
                element = driver.FindElement(by);
                ClickElement(element);
            }
        }

        /// <summary>
        /// Selects a item about comboBox.
        /// </summary>
        /// <param name="element">ComboBox Web element</param>
        /// <param name="value">Value to Select in a ComboBox</param>
        public static void SelectComboBox(this IWebElement element, string value)
        {
            WaitUntilElementIsDisplayed(element);
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByText(value.Trim());
        }

        /// <summary>
        /// Selects an item via its option value.
        /// </summary>
        /// <param name="element">ComboBox Web element</param>
        /// <param name="value">Option value to Select in a ComboBox</param>
        public static void SelectComboBoxByOptionValue(this IWebElement element, string value)
        {
            WaitUntilElementIsDisplayed(element);
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByValue(value);
        }

        /// <summary>
        /// Selects a value from radioButton.
        /// </summary>
        /// <param name="webElement">Is the web element to select from radio button</param>
        public static void RadioButtonCheck(this IWebElement webElement)
        {
            WebDriverUtils.GetJsExecutor().ExecuteScript("arguments[0].checked = true;", webElement);
        }

        /// <summary>
        /// Deletes a specific attribute for a WebElement.
        /// </summary>
        /// <param name="attributeName">The attribute to remove.</param>
        /// <param name="webElement">The element from which the attribute will be removed.</param>
        public static void RemoveAttributeFromAnElement(string attributeName, IWebElement webElement)
        {
            WebDriverUtils.GetJsExecutor().ExecuteScript($"arguments[0].removeAttribute('{attributeName}')", webElement);
        }

        /// <summary>
        /// Verifies if WebElement is Displayed.
        /// </summary>
        /// <param name="webElement">Is the <see cref="IWebElement"/> that method will verify if it is displayed.</param>
        /// <returns>Is true if the <see cref="IWebElement"/> is displayed.</returns>
        public static bool IsElementDisplayed(this IWebElement webElement)
        {
            try
            {
                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies if a WebElement is Displayed.
        /// </summary>
        /// <param name="by">Is the <see cref="By"/> that method will verify if it is displayed.</param>
        /// <returns>Is true if the <see cref="IWebElement"/> is displayed.</returns>
        public static bool IsElementDisplayed(By by)
        {
            var isDisplayed = false;
            try
            {
                isDisplayed = WebDriverManager.Instance.GetWebDriver.FindElement(by).Displayed;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is StaleElementReferenceException)
                {
                    return false;
                }
            }

            return isDisplayed;
        }

        /// <summary>
        /// Gets a List of IWebElements based on By condition.
        /// </summary>
        /// <param name="findBy">By condition.</param>
        /// <returns>List of IWebElements.</returns>
        public static IList<IWebElement> GetListWebElements(By findBy)
        {
            IList<IWebElement> elements = WebDriverManager.Instance.GetWebDriver.FindElements(findBy);
            return elements;
        }

        /// <summary>
        /// Gets the first web element of IWebElements based on By condition.
        /// </summary>
        /// <param name="findBy">By condition.</param>
        /// <returns>First IWebElement.</returns>
        public static IWebElement GetFirstWebElementBy(By findBy)
        {
            IList<IWebElement> elements = WebDriverManager.Instance.GetWebDriver.FindElements(findBy);
            return elements.Count > 0 ? elements.First() : null;
        }

        /// <summary>
        /// Extension method gets the first web element of IWebElements based on By condition and ISearchContext.
        /// </summary>
        /// <param name="context">Search context.</param>
        /// <param name="findBy">By condition.</param>
        /// <returns>First IWebElement.</returns>
        public static IWebElement GetFirstWebElementBy(this ISearchContext context, By findBy)
        {
            IList<IWebElement> elements = context.FindElements(findBy);
            return elements.FirstOrDefault();
        }

        /// <summary>
        /// Gets a List of IWebElements based on IWebElement and By conditions.
        /// </summary>
        /// <param name="webElement">IWebElement to search the elements</param>
        /// <param name="findBy">By condition.</param>
        /// <returns>List of IWebElements.</returns>
        public static IList<IWebElement> GetListWebElements(this IWebElement webElement, By findBy)
        {
            IList<IWebElement> elements = webElement.FindElements(findBy);
            return elements;
        }

        /// <summary>
        /// Extension method gets the list of web element of IWebElements based on By condition and ISearchContext.
        /// </summary>
        /// <param name="context">Search context.</param>
        /// <param name="findBy">By condition.</param>
        /// <returns>List of IWebElements.</returns>
        public static IList<IWebElement> GetListWebElements(this ISearchContext context, By findBy)
        {
            IList<IWebElement> elements = context.FindElements(findBy);
            return elements;
        }

        /// <summary>
        /// Gets IWebElement of a list based on Text of the element.
        /// </summary>
        /// <param name="listElements">List of IWebElements</param>
        /// <param name="textValue">Text to search in the WebElement</param>
        /// <returns>IWebElement found</returns>
        public static IWebElement GetIWebElementByText(IList<IWebElement> listElements, string textValue)
        {
            return listElements.FirstOrDefault(element => element.Text.Trim().Equals(textValue));
        }

        /// <summary>
        /// Waits for a WebElement contains a specific value in the attribute
        /// </summary>
        /// <param name="webElement">WebElement to find.</param>
        /// <param name="attribute">Attribute to wait.</param>
        /// <param name="valueAttribute">Value of attribute.</param>
        public static void WaitUntilWebElementHasAttribute(IWebElement webElement, string attribute, string valueAttribute)
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(
                waitElement => webElement.GetAttribute(attribute).Contains(valueAttribute));
        }

        /// <summary>
        /// Waits until a locator exists on the DOM of a page.
        /// </summary>
        /// <param name="findBy"><see cref="By"/></param>
        /// <returns>IWebElement.</returns>
        public static IWebElement WaitUntilLocatorExists(By findBy)
        {
            return WebDriverManager.Instance.GetWebDriverWait.Until(ExpectedConditions.ElementExists(findBy));
        }

        /// <summary>
        /// Calculates the elapsed time until an element is displayed
        /// </summary>
        /// <param name="elementReference">element reference</param>
        /// <returns>The elapsed time as seconds</returns>
        public static double CalculateElapsedTimeUntilElementAppears(IWebElement elementReference)
        {
            Stopwatch elapsedTime = new Stopwatch();
            elapsedTime.Start();

            while (true)
            {
                if (IsElementDisplayed(elementReference))
                {
                    break;
                }
            }

            elapsedTime.Stop();

            return elapsedTime.Elapsed.TotalSeconds;
        }

        /// <summary>
        /// Moves the scroll bar till the element given.
        /// </summary>
        /// <param name="element">element reference</param>
        /// <param name="alignToTop">If true, the top of the element will be aligned to the top of the visible area of the scrollable ancestor, otherwise
        /// the bottom of the element will be aligned to the bottom of the visible area of the scrollable ancestor</param>
        public static void ScrollIntoView(IWebElement element, bool alignToTop)
        {
            string argument = $"arguments[0].scrollIntoView({alignToTop.ToString().ToLower()});";
            WebDriverUtils.GetJsExecutor().ExecuteScript(string.Format(argument), element);
        }

        /// <summary>
        /// Focus on web element.
        /// </summary>
        /// <param name="elementPage">The driver of page</param>
        /// <param name="element">element reference</param>
        public static void FocusOnWebElement(IWebDriver elementPage, IWebElement element)
        {
            Actions builder = new Actions(elementPage);
            builder.MoveToElement(element).Release(element).Perform();
        }

        /// <summary>
        /// Sets new value for element
        /// </summary>
        /// <param name="element">element reference</param>
        /// <param name="value">new value</param>
        public static void UpdateElementValueByJavaScript(IWebElement element, string value)
        {
            WebDriverUtils.GetJsExecutor().ExecuteScript("arguments[0].value=arguments[1]", element, value);
        }

        /// <summary>
        /// Verifies if the value of web element is equals as expected.
        /// </summary>
        /// <param name="element">element reference</param>
        /// <param name="valueExpected">value expected.</param>
        /// <returns>Is true if the value of<see cref="IWebElement"/> is equals as expected.</returns>
        public static bool IsValueOfWebElementEqualsAsExpected(IWebElement element, string valueExpected)
        {
            try
            {
                return WebDriverManager.Instance.GetWebDriverWait.Until(waitElement => element.GetAttribute("value").Equals(valueExpected));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets an element based on By condition.
        /// </summary>
        /// <param name="findBy">By condition.</param>
        /// <returns>IWebElement.</returns>
        public static IWebElement GetWebElementBy(By findBy)
        {
            try
            {
                return WebDriverManager.Instance.GetWebDriver.FindElement(findBy);
            }
            catch (NoSuchElementException error)
            {
                string errorMessage = $"The element is not found :{error}";
                Logging.Error(errorMessage);
                throw new NoSuchElementException(errorMessage);
            }
        }

        /// <summary>
        /// Gets Date time
        /// </summary>
        /// <param name="separator">Specify a character to place between Date Month year</param>
        /// <param name="date">Specify date</param>
        /// <returns>Date Time</returns>
        public static string GetDateTimeTextFormat(char separator, DateTime date)
        {
            Dictionary<int, string> months = new Dictionary<int, string>() {
                { 1, "Jan" },
                { 2, "Feb" },
                { 3, "Mar" },
                { 4, "Apr" },
                { 5, "May" },
                { 6, "Jun" },
                { 7, "Jul" },
                { 8, "Aug" },
                { 9, "Sep" },
                { 10, "Oct" },
                { 11, "Nov" },
                { 12, "Dec" }
            };
            string format = "{1}{6}{0}{6}{2} {3}:{4} {5}";
            string isT = date.Hour > 12 ? "PM" : "AM";  // am pm
            int dateIn12Hr = date.Hour > 12 ? (date.Hour - 12) : date.Hour; // 12/24 hour
            string createdDate = string.Format(
                format,
                months[date.Month],
                date.Day,
                date.Year.ToString().Substring(2, 2),
                dateIn12Hr,
                date.Minute,
                isT,
                separator);
            return createdDate;
        }

        /// <summary>
        /// Removes the escape sequences and empty spaces from string and returns the trimmed content.
        /// </summary>
        /// <param name="s">Text to sanitize</param>
        /// <returns>returns string</returns>
        public static string ToSanitizedString(string s)
        {
            var mystring = s.Split(new string[] { " ", ",", "\n", "\r", "/", "Details" }, StringSplitOptions.RemoveEmptyEntries);
            string result = string.Empty;
            foreach (var mstr in mystring)
            {
                var ss = mstr.Trim();
                if (!string.IsNullOrEmpty(ss))
                {
                    result = result + ss;
                }
            }

            result = Regex.Replace(result, @"\s+", "");
            return result;
        }

        /// <summary>
        /// Checks whether element exist on dom
        /// </summary>
        /// <param name="by"><see cref="By"/></param>>
        /// <returns>True if element exists on the dom, false otherwise</returns>
        public static bool IsLocatorExist(By by)
        {
            try
            {
                WebDriverManager.Instance.GetWebDriver.FindElement(by);
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is StaleElementReferenceException)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Verifies if all WebElements are Displayed.
        /// </summary>
        /// <param name="elements">the elements in the list that method will verify if it is displayed.</param>
        /// <returns>Is true if all elements in list are displayed.</returns>
        public static bool AreAllElementsDisplayed(this IList<IWebElement> elements)
        {

            var byElements = new ReadOnlyCollection<IWebElement>(elements);

            try
            {
                WebDriverManager.Instance.GetWebDriverWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(byElements));
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
    }
}
