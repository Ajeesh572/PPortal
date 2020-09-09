// <copyright file="MyAccountMenuComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.DtcOneApp.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class handles My Account menu component.
    /// </summary>
    public class MyAccountMenuComponent : BasePage, IDtcOneAppComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href*='/my-account/recipients'][class*='submenulink']")]
        private IWebElement LnkMyRecipients;

        [IDTFindBy(How = How.CssSelector, Using = "a[href*='/my-account/payment-options'][class*='submenulink']")]
        private IWebElement LnkPaymentOptions;

        /// <summary>
        /// Clicks on an option in the Services menu.
        /// </summary>
        /// <param name="option">Is an option of the top menu</param>
        public void ClickOnItem(string option)
        {
            Dictionary<string, IWebElement> topSubMenuOptions = new Dictionary<string, IWebElement>
            {
                { "MY RECIPIENTS", LnkMyRecipients },
                { "PAYMENT OPTIONS", LnkPaymentOptions }
            };
            CommonActions.ClickElement(topSubMenuOptions[option.ToUpper()]);
        }
    }
}
