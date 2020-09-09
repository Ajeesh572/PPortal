// <copyright file="ManageProductsPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Bro.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.Elements;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class is to handle the manage products page.
    /// </summary>
    public class ManageProductsPage : BasePage
    {
        [IDTFindBy(How = How.Id, Using = "gs_ProductTypeName")]
        private IWebElement LstProductType;

        /// <summary>
        /// Selects an option from Product type.
        /// </summary>
        /// <param name="option">The option to choose.</param>
        public void SelectOptionFromProductType(string option)
        {
            option = option.ToUpper().Replace(" ", string.Empty);
            this.LstProductType.SelectComboBox(option);
        }

        /// <summary>
        /// Creates a list of all product types, by the element's value attribute
        /// </summary>
        /// <returns>list of product types VALUE attribute</returns>
        public IEnumerable<string> GetProductTypeOptionsByValue()
        {
            return new Select(LstProductType).GetPossibleValuesByAttribute();
        }

        /// <summary>
        /// Creates a list of all product types, by the element's text
        /// </summary>
        /// <returns>list of product types text content</returns>
        public IEnumerable<string> GetProductTypeOptionsByText()
        {
            return new Select(LstProductType).GetPossibleValues();
        }

        /// <summary>
        /// Edits allowed for current retailer option.
        /// </summary>
        /// <param name="productName">The productName to edit.</param>
        public void EditAllowedForCurrentRetailerOption(string productName)
        {
            CommonActions.WaitUntilLocatorExists(Utils.GetByLocator("BossRevolutionOrganizerLocators", "AlertLoadingDisplayNone"));
            CommonActions.ClickElementByLocator(Utils.GetByLocator("ManageProductsLocators", "BtnEditSelectedProduct", productName));
        }

        /// <summary>
        /// Checks allowed for current Retailer option.
        /// </summary>
        /// <param name="productName">The product name value.</param>
        public void CheckAllowedForCurrentRetailerOption(string productName)
        {
            By locator = Utils.GetByLocator("ManageProductsLocators", "ChkIsAllowedForRetailer", productName);
            CommonActions.WaitUntilLocatorExists(locator);

            // TODO: method to create a Weblement using a locator
            if (!WebDriverManager.Instance.GetWebDriver.FindElement(locator).Selected)
            {
                WebDriverManager.Instance.GetWebDriver.FindElement(locator).ClickElementByJavaScript();
            }
        }

        /// <summary>
        /// Submits change for allowed for current retailer.
        /// </summary>
        /// <param name="productName">The product name value.</param>
        public void SubmitChangeForAllowedForCurrentRetailer(string productName)
        {
            CommonActions.ClickElementByLocator(Utils.GetByLocator("ManageProductsLocators", "BtnSubmit", productName));
        }

        /// <summary>
        /// Verifies if the allowed for Current Retailer option is selected.
        /// </summary>
        /// <param name="productName">The product name value.</param>
        /// <returns>True or False in bool format.</returns>
        public bool IsAllowedForCurrentRetailerOptionSelected(string productName)
        {
            By locator = Utils.GetByLocator("ManageProductsLocators", "ChkIsAllowedForRetailer", productName);
            return WebDriverManager.Instance.GetWebDriver.FindElement(locator).Selected;
        }
    }
}
