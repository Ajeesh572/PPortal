// <copyright file="ReportComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using Euro.Core.Automation.Utilities.CommonAction;

    /// <summary>
    /// Class to handle the Report component
    /// </summary>
    public class ReportComponent : BasePage, IRetailerComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/Transactions']")]
        [IDTFieldName("Transaction History")]
        private IWebElement LnkTransactionHistory;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/BillPayReport']")]
        [IDTFieldName("Bill Pay Status Report")]
        private IWebElement LnkBillPayStatusReport;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/Billing']")]
        [IDTFieldName("Billing")]
        private IWebElement LnkBilling;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/RewardsStatement']")]
        [IDTFieldName("Rewards Statement")]
        private IWebElement LnkRewardsStatement;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/MoneyTransferV2']")]
        [IDTFieldName("Money Transfer Transactions")]
        private IWebElement LnkMoneyTransferTransactions;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/Commissions']")]
        [IDTFieldName("Commissions")]
        private IWebElement LnkCommissions;

        /// <summary>
        /// Clicks an item inside the component.
        /// </summary>
        /// <param name="item">The item that will be clicked.</param>
        public void ClickOnItem(string item)
        {
            GetWebElementByFieldName(item).ClickElement();
        }
    }
}
