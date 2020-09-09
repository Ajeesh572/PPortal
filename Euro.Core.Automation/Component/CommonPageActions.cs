// <copyright file="CommonPageActions.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Component
{
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.Helpers.StringHelper;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    /// <summary>
    /// Abstract partial base component to work with common page actions
    /// </summary>
    public abstract partial class BaseComponent
    {
        /// <summary>
        /// Click on <see cref = "IWebElement"/> by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="elementName">Element name from attribute IDTFieldName</param>
        public virtual void Click(string elementName)
        {
            GetWebElementByFieldName(elementName).WaitUntilElementIsDisplayed();
            CommonActions.ClickElement(GetWebElementByFieldName(elementName));
        }

        /// <summary>
        /// Click by js on <see cref = "IWebElement"/> by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="elementName">Element name from attribute IDTFieldName</param>
        public virtual void ClickByJavaScript(string elementName)
        {
            GetWebElementByFieldName(elementName).WaitUntilElementIsDisplayed();
            GetWebElementByFieldName(elementName).ClickElementByJavaScript();
        }

        /// <summary>
        /// Fill input by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="fieldName">Element name from attribute IDTFieldName</param>
        /// <param name="value">Value for fill</param>
        public virtual void FillInput(string fieldName, string value)
        {
            CommonActions.SendKeys(GetWebElementByFieldName(fieldName), value);
        }

        /// <summary>
        /// Get text from element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="elementName">Element name from attribute IDTFieldName</param>
        /// <returns>Element text</returns>
        public virtual string GetText(string elementName)
        {
            WaitUntilElementDisplayed(elementName);
            return GetWebElementByFieldName(elementName).Text.ReduceSpaces();
        }

        /// <summary>
        /// Get attribute value of element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="elementName">Element name from attribute IDTFieldName</param>
        /// <param name="attributeName">Attribute name</param>
        /// <returns>Attribute value</returns>
        public virtual string GetAttributeValue(string elementName, string attributeName = "value")
        {
            GetWebElementByFieldName(elementName).WaitUntilElementIsDisplayed();
            return GetWebElementByFieldName(elementName).GetAttribute(attributeName);
        }

        /// <summary>
        /// Get bool value (displayed or not) of element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="elementName">Element name from attribute IDTFieldName</param>
        /// <returns>Bool value</returns>
        public virtual bool IsElementDisplayed(string elementName)
        {
            return GetWebElementByFieldName(elementName).IsElementDisplayed();
        }

        /// <summary>
        /// Get bool value (enable or not) of element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="elementName">Element name from attribute IDTFieldName</param>
        /// <returns>Bool value</returns>
        public bool IsEnabled(string elementName)
        {
            return GetWebElementByFieldName(elementName).Enabled;
        }

        /// <summary>
        /// Wait until element displayed by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="elementName">Element name from attribute IDTFieldName</param>
        public virtual void WaitUntilElementDisplayed(string elementName)
        {
            GetWebElementByFieldName(elementName).WaitUntilElementIsDisplayed();
        }

        /// <summary>
        /// Wait until element is will be invisible by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="elementName">Element name from attribute IDTFieldName</param>
        public virtual void WaitUntilElementIsInvisible(string elementName)
        {
            GetWebElementByFieldName(elementName).WaitUntilElementIsInvisible();
        }

        /// <summary>
        /// Wait until element is will be Clickable by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="elementName">Element name from attribute IDTFieldName</param>
        public virtual void WaitUntilElementIsClickable(string elementName)
        {
            GetWebElementByFieldName(elementName).WaitUntilElementIsClickeable();
        }

        /// <summary>
        /// Hover over an element by IDTFieldName
        /// </summary>
        /// <param name="elementName">Name of element as specified by IDTFieldName attribute</param>
        public void HoverOverElement(string elementName)
        {
            IWebElement element = GetWebElementByFieldName(elementName);
            element.WaitUntilElementIsDisplayed();

            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        /// <summary>
        /// Wait until elements displayed by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="listName">List name from attribute IDTFieldName</param>
        /// /// <returns>Bool value</returns>
        public virtual bool AreAllElementsDisplayed(string listName)
        {
            return GetWebElementsByFieldName(listName).AreAllElementsDisplayed();
        }

        /// <summary>
        /// Delete value from the field
        /// </summary>
        /// <param name="fieldName">name in attribute IDTFieldName</param>
        public void ClearField(string fieldName)
        {
            GetWebElementByFieldName(fieldName).Clear();
        }

        /// <summary>
        /// Verifies that field has type: text.
        /// </summary>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>True if field has type: text, false otherwise.</returns>
        public bool IsTextField(string fieldName)
        {
            return GetWebElementByFieldName(fieldName).GetAttribute("type").Equals("text");
        }

        /// <summary>
        /// Clicks on link and switch to opened window.
        /// </summary>
        /// <param name="element">The element name.</param>
        public virtual void ClickOnElementAndSwitchToOpenedWindow(string element)
        {
            GetWebElementByFieldName(element).Click();
            string tab = Driver.WindowHandles[1];
            WebDriverUtils.SwitchToWindowByName(tab);
        }
    }
}
