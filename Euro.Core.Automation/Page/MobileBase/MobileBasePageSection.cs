// <copyright file="BasePageSection.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Page.Base
{
    using System.Collections.ObjectModel;
    using Euro.Core.Automation.Assert;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;

    /// <summary>
    /// Class represents Base page part realization.
    /// </summary>
    public abstract class MobileBasePageSection : IAssertableComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePageSection"/> class.
        /// </summary>
        protected MobileBasePageSection()
        {
            this.Driver = MobileDriverManager.Instance.GetWebDriver;
            IDTPageFactory.InitElements(this.Driver, this);
        }

        /// <summary>
        /// Gets or sets web element property.
        /// </summary>
        public AppiumWebElement WebElementImplementation { get; set; }

        /// <summary>Gets or sets driver.</summary>
        protected IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets a value indicating whether section is displayed.
        /// </summary>
        /// <returns>True if section is displayed, false otherwise</returns>
        public bool Displayed => WebElementImplementation.IsElementDisplayed();

        /// <inheritdoc />
        public bool IsElementDisplayed(string webElementName) =>
            FindElement(GetLocatorFromDictionary(webElementName)).IsElementDisplayed();

        /// <inheritdoc />
        public string GetText(string webElementName) =>
            FindElement(GetLocatorFromDictionary(webElementName)).Text.Replace("\n", " ").Replace("\r", string.Empty);

        /// <inheritdoc />
        public int GetQuantityOfElementsOnUi(string webElementName)
        {
            return FindElements(GetLocatorFromDictionary(webElementName)).Count;
        }

        /// <inheritdoc />
        public string GetAttributeValue(string element, string attributeName)
        {
            return FindElement(GetLocatorFromDictionary(element)).GetAttribute(attributeName);
        }

        /// <inheritdoc />
        public AppiumWebElement FindElement(By by) => WebElementImplementation.FindElement(@by);

        /// <inheritdoc />
        public ReadOnlyCollection<AppiumWebElement> FindElements(By by) => WebElementImplementation.FindElements(by);

        /// <summary>
        /// Fill data into provided field.
        /// </summary>
        /// <param name="webElementName">Web element name</param>
        /// <param name="dataToSend">Data to send to element</param>>
        public void SendKeys(string webElementName, string dataToSend) => FindElement(GetLocatorFromDictionary(webElementName)).SendKeys(dataToSend);

        /// <summary>
        /// Waits until page section is invisible.
        /// </summary>
        public void WaitUntilInvisible()
        {
            WebElementImplementation.WaitUntilElementIsInvisible();
        }

        /// <summary>
        /// Clicks on web element on section
        /// </summary>
        /// <param name="webElementName">Element name to click</param>
        public void Click(string webElementName) =>
            FindElement(GetLocatorFromDictionary(webElementName)).Click();

        /// <summary>
        /// Gets web element from dictionary by provided name. Need to override in child classes.
        /// </summary>
        /// <param name="webElementName">Name of the webElement</param>
        /// <returns>WebElement</returns>
        protected virtual By GetLocatorFromDictionary(string webElementName)
        {
            // if you would like to use this method, please override it in your page class;
            throw new System.NotImplementedException();
        }
    }
}
