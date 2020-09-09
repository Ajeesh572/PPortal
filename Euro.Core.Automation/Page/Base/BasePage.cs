// <copyright file="BasePage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Page.Base
{
    using Euro.Core.Automation.Component;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;

    /// <summary>
    /// Abstract Base Page used for Page objects
    /// </summary>
    public abstract class BasePage : BaseComponent
    {
        /// <summary>
        /// Finds page part.
        /// </summary>
        /// <param name="by">Locator of an element</param>
        /// <returns>WebElement</returns>
        public static T FindPageSection<T>(By by)
            where T : BasePageSection, new()
        {
            var element = WebDriverManager.Instance.GetWebDriver.FindElement(by);
            var pageSection = new T
            {
                WebElementImplementation = element
            };

            return pageSection;
        }

        /// <summary>
        /// Wait until page loaded.
        /// Used for override in page if page has unique spinners or so on.
        /// </summary>
        public virtual void WaitUntilPageLoaded()
        {
        }

        /// <summary>
        /// Check that page open or not.
        /// </summary>
        /// <param name="fileLocator">File locator name</param>
        /// <param name="titleLocatorTemplate">Title locator template, example: //h2[contains(text(),'{0}')]</param>
        /// <param name="titleText">Title text</param>
        /// <returns>Bool state, true if page open, false if not.</returns>
        public bool IsPageOpened(string fileLocator, string titleLocatorTemplate, string titleText)
        {
            var translatedTextTitle = LanguageManager.Instance.TranslateTextIfNeed(titleText);
            var titleLocator = GetLocator(fileLocator, titleLocatorTemplate, translatedTextTitle);
            CommonActions.WaitUntilLocatorExists(titleLocator);
            CommonActions.WaitUntilElementIsDisplayed(CommonActions.GetWebElementBy(titleLocator));
            return CommonActions.IsElementDisplayed(titleLocator);
        }

        /// <summary>
        ///  Scroll on the top of page by java script.
        /// </summary>
        public void ScrollOnTheTopOfPage()
        {
            Driver.ExecuteJavaScript("window.scrollTo(0, 0);");
        }

        /// <summary>
        /// Wait until ajax will be load.
        /// </summary>
        public void WaitUntilAjaxInactive()
        {
            WebDriverUtils.WaitUntilAjaxInactive();
        }

        /// <summary>
        /// Verifies that valid page's title is displayed.
        /// </summary>
        /// <returns>True if valid page's title is displayed, false otherwise.</returns>
        /// <param name="expectedTitleOfThePage">Expected value of page title</param>
        public virtual bool IsValidPageTitleDisplayed(string expectedTitleOfThePage)
        {
            CommonActions.WaitUntilTitleIs(expectedTitleOfThePage);
            return Driver.Title.Equals(expectedTitleOfThePage);
        }

        /// <summary>
        /// Verifies that current openedUrl contains expected page url.
        /// </summary>
        /// <param name="openedUrl">Last part of Url as string value.</param>
        /// <returns>True if current openedUrl contains expected page url, false otherwise.</returns>
        public bool IsUrlContains(string openedUrl)
        {
            return Driver.Url.Contains(openedUrl);
        }

        /// <summary>
        /// Find window name by url.
        /// </summary>
        /// <param name="urlPart">Page url.</param>
        /// <returns>Window name by url or null if not find.</returns>
        public string GetWindowByUrl(string urlPart)
        {
            var currentWindow = Driver.CurrentWindowHandle;
            var windows = WebDriverUtils.GetCurrentWindows();
            foreach (var window in windows)
            {
                WebDriverUtils.SwitchToWindowByName(window);
                if (Driver.Url.Contains(urlPart))
                {
                    return window;
                }
            }

            WebDriverUtils.SwitchToWindowByName(currentWindow);
            return null;
        }
    }
}