// <copyright file="BaseComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Component
{
    using System;
    using System.Collections.Generic;
    using Euro.Core.Automation.Assert;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.Helpers.CssHelper;
    using Euro.Core.Automation.Utilities.Helpers.Reflection;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Abstract base component used for components
    /// </summary>
    public abstract partial class BaseMobleComponent 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseComponent"/> class.
        /// </summary>
        public BaseMobleComponent()
        {
            Driver = MobileDriverManager.Instance.GetWebDriver;
            Wait = MobileDriverManager.Instance.GetWebDriverWait;
            IDTPageFactory.InitElements(this.Driver, this);
        }

        /// <summary>
        /// Gets or sets driver.
        /// </summary>
        protected IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets driver.
        /// </summary>
        protected WebDriverWait Wait { get; set; }

        /// <summary>
        /// Find a Locator based on ResX file.
        /// GetByLocator("Name of Resx file", "Locator key", "Value 1", "Value 2", "Value #")
        /// </summary>
        /// <param name="resxfile">Name of Resx file</param>
        /// <param name="locatorKey">Key value to find a locator in Resx file</param>
        /// <param name="values">Parameters</param>
        /// <returns>By Locator</returns>
        public static By GetLocator(string resxfile, string locatorKey, params string[] values)
        {
            return Utils.GetByLocator(resxfile, locatorKey, values);
        }

        /// <summary>
        /// Fill field if value not null.
        /// </summary>
        /// <param name="value">Value for fill</param>
        /// <param name="fillMethod">Method which fill field</param>
        public void FillFieldIfNotNull(string value, Action<string> fillMethod)
        {
            if (value != null)
            {
                fillMethod(value);
            }
        }

        /// <summary>
        /// Gets value from input field.
        /// </summary>
        /// <param name="inputName">Field name from which we are getting value</param>
        /// <returns>Value of input field as a string</returns>>
        public string GetInputFieldValue(string inputName)
        {
            return GetWebElementByFieldName(inputName).GetAttribute("ng-reflect-model");
        }

        /// <summary>
        /// Gets quantity of elements from list with web elements using list name.
        /// </summary>
        /// <param name="webElementList">Name of the list with web elements</param>
        /// <returns>Quantity of elements in the list</returns>
        public int GetQuantityOfElementsOnUi(string webElementList)
        {
            return GetWebElementsByFieldName(webElementList).Count;
        }

        /// <summary>
        /// Will wait until the element is enabled
        /// </summary>
        /// <param name="buttonName">Name Of the element</param>
        public void WaitUntilButtonIsEnabled(string buttonName)
        {
            CommonActions.WaitUntilElementIsEnabled(GetWebElementByFieldName(buttonName));
        }

        /// <summary>
        /// Verifies that correct background color is shown for message.
        /// </summary>
        /// <param name="color">Expected background color</param>
        /// <param name="webElement">WebElement for which we want to check backgorund color</param>
        /// <returns>True if we see expectected color, false otherwise</returns>
        public bool IsBackGroundColor(string color, string webElement)
        {
            var correctBackGroundColor = false;
            IWebElement element;

            switch (color)
            {
                case "black":
                    var blackRgbaColor = "rgba(0, 0, 0, 1)";
                    element = GetWebElementByFieldName(webElement);
                    correctBackGroundColor = blackRgbaColor.Equals(element.GetBackgroundColor());
                    break;
                case "green":
                    var greenRgbaColor = "rgba(59, 177, 74, 1)";
                    element = GetWebElementByFieldName(webElement);
                    correctBackGroundColor = greenRgbaColor.Equals(element.GetBackgroundColor());
                    break;
            }

            return correctBackGroundColor;
        }

        /// <summary>
        /// Get WebElement by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="fieldName">Element name from attribute IDTFieldName</param>
        /// <returns>WebElement</returns>
        protected virtual IWebElement GetWebElementByFieldName(string fieldName)
        {
            return ReflectionHelper.GetFieldByFieldName<IWebElement>(this, fieldName, typeof(BaseComponent));
        }

        /// <summary>
        /// Get List of WebElements by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="fieldName">Element name from attribute IDTFieldName</param>
        /// <returns>WebElement</returns>
        protected virtual IList<IWebElement> GetWebElementsByFieldName(string fieldName)
        {
            return ReflectionHelper.GetFieldByFieldName<IList<IWebElement>>(this, fieldName, typeof(BaseComponent));
        }
    }
}
