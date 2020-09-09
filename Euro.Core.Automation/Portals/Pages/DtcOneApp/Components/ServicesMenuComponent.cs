// <copyright file="SubTopMenuComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.DtcOneApp.Components
{
    using System;
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Services menu component
    /// </summary>
    public class ServicesMenuComponent : BasePage, IDtcOneAppComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href='/en-us/my-account/international-calling#focus']")]
        private IWebElement LnkIntenationalCalling;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href='/en-us/services/money-transfer']")]
        private IWebElement LnksInternationalMoneyTransfer;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href='/en-us/my-account/international-mobile-topup#focus']")]
        private IWebElement LnkInternationalMobileTopUp;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href='/en-us/services/egift']")]
        private IWebElement LnkEGift;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href='/en-us/my-account/domestic-mobile-topup#focus']")]
        private IWebElement LnkDomesticMobileTopUp;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href='/en-us/services/call-me']")]
        private IWebElement LnkCallMe;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href = '/en-us/services/international-egifts']")]
        private IWebElement LnkInternationalEGift;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href='/en-us/services/bill-pay']")]
        private IWebElement LnkBillPay;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href='/en-us/services/visa-virtual']")]
        private IWebElement LnkVisaVirtual;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href*='/my-account/international-calling/recharge']")]
        private IWebElement LnkAddFunds;

        [IDTFindBy(How = How.CssSelector, Using = "[id='servicesMenu-desktop'] [href*='/services/unlimited-international-calling-plan']")]
        private IWebElement LnkUnlimitedPlan;

        /// <summary>
        /// Clicks on an option in the Services menu.
        /// </summary>
        /// <param name="option">Is an option of the top menu</param>
        public void ClickOnItem(string option)
        {
            Dictionary<string, IWebElement> topSubMenuOptions = new Dictionary<string, IWebElement>
            {
                { "INTERNATIONAL CALLING", LnkIntenationalCalling },
                { "INTERNATIONAL MONEY TRANSFER", LnksInternationalMoneyTransfer },
                { "INTERNATIONAL MOBILE TOP UP", LnkInternationalMobileTopUp },
                { "EGIFT", LnkEGift },
                { "DOMESTIC MOBILE TOP UP", LnkDomesticMobileTopUp },
                { "CALL ME", LnkCallMe },
                { "INTERNATIONAL EGIFT", LnkInternationalEGift },
                { "BILL PAY", LnkBillPay },
                { "VISA VIRTUAL", LnkVisaVirtual },
                { "ADD FUNDS", LnkAddFunds },
                { "UNLIMITED PLAN", LnkUnlimitedPlan }
            };
            topSubMenuOptions[option.ToUpper()].Click();
        }
    }
}
