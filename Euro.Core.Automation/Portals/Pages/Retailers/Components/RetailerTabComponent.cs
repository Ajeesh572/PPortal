// <copyright file="TopMenuComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.Logger;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Retailer Tab component
    /// </summary>
    public class RetailerTabComponent : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href='#products']")]
        private IWebElement TabProducts;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='#reports']")]
        private IWebElement TabReports;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='#BR_University']")]
        private IWebElement TabBrUniversity;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='#tools']")]
        private IWebElement TabTools;

        [IDTFindBy(How = How.CssSelector, Using = "[class='blockUI blockMsg blockElement'] i[class*= 'fa-spinner']")]
        private IWebElement BlockMsg;

        [IDTFindBy(How = How.CssSelector, Using = "[class='blockUI blockOverlay']")]
        private IWebElement BlockUiOverlay;

        /// <summary>
        /// Clicks over an Item inside the component
        /// </summary>
        /// <param name="tabOption">Name of Tab</param>
        public void ClickOnTapOption(string tabOption)
        {
            BlockMsg.WaitUntilElementIsInvisible();
            BlockUiOverlay.WaitUntilElementIsInvisible();
            CommonActions.ClickElement(GetWebElementFromDictionaryDownMenu(tabOption));
        }

        /// <summary>
        /// Gets a webElement from a dictionary.
        /// </summary>
        /// <param name="webElementName">WebElement name in the dictionary.</param>
        /// <returns>WebElement</returns>
        public IWebElement GetWebElementFromDictionaryDownMenu(string webElementName)
        {
            Logging.Debug($" |||||||||||||| BEGIN -- BROWSER RESOLUTION  -- BEGIN ||||||||||||||");
            Logging.Debug($"The browser resolution  is: {WebDriverManager.Instance.GetResolution()}");
            Dictionary<string, IWebElement> webElementDictionary = new Dictionary<string, IWebElement>
            {
                 { "Products", TabProducts },
                { "Reports", TabReports },
                { "BR University", TabBrUniversity },
                { "Tools", TabTools }
            };
            Logging.Debug($" |||||||||||||| END -- BROWSER RESOLUTION  -- END ||||||||||||||");
            return webElementDictionary[webElementName];
        }
    }
}
