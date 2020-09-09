// <copyright file="ReportComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Distributor.Components
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
    public class ReportComponent : BasePage, IDistributorComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/DistributorTransactions']")]
        [IDTFieldName("My Transactions")]
        private IWebElement lnkMyTransactions;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/DistributorCommissions']")]
        [IDTFieldName("Commissions")]
        private IWebElement lnkCommissions;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/CreditBalance']")]
        [IDTFieldName("Credit Balance History")]
        private IWebElement lnkCreditBalanceHistory;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/DistributorBillingSummary']")]
        [IDTFieldName("Billing Summary")]
        private IWebElement lnkBillingSummary;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/SalesTeamReport']")]
        [IDTFieldName("Sales Team")]
        private IWebElement lnkSalesTeam;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/TrendingReport']")]
        [IDTFieldName("Trending Report")]
        private IWebElement lnkTrendingReport;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/RetailerRewardsSummary']")]
        [IDTFieldName("Rewards Summary")]
        private IWebElement lnkRewardsSummary;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/RetailerRedemptionReport']")]
        [IDTFieldName("Retailer Redemption")]
        private IWebElement lnkRetailerRedemption;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/MoneyTransferReport']")]
        [IDTFieldName("Money Transfer")]
        private IWebElement lnkMoneyTransfer;

        [IDTFindBy(How = How.CssSelector, Using = "#reports a[href = '/Reports/RetailerTransactions']")]
        [IDTFieldName("Retailer Transactions")]
        private IWebElement lnkRetailerTransactions;

        /// <summary>
        /// Clicks an item inside the component.
        /// </summary>
        /// <param name="item">The item that will be clicked.</param>
        public void ClickOnItem(string item)
        {
            IsElementDisplayed(item);
            Click(item);
        }
    }
}
