// <copyright file="ProductVerticalComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the vertical Product component
    /// </summary>
    public class ProductVerticalComponent : BasePage, IRetailerComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/DBillPay/Index']")]
        private IWebElement LnkDomesticBillPay;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/ServiceAccount/Search']")]
        private IWebElement LnkBrAccount;

        /// <inherit>
        public void ClickOnItem(string item)
        {
            Dictionary<string, IWebElement> items = new Dictionary<string, IWebElement>
            {
                { "Domestic Bill Pay", LnkDomesticBillPay },
                { "Br Account", LnkBrAccount }
            };

            items[item].WaitUntilElementIsDisplayed();
            items[item].Click();
        }
    }
}
