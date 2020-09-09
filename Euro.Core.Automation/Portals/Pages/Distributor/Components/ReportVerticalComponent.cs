// <copyright file="ReportVerticalComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Distributor.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Report component from left menu
    /// </summary>
   public class ReportVerticalComponent : BasePage, IDistributorComponent
    {
        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'My Transactions'] | //span[text() = 'Mis Transacciones']")]
        [IDTFieldName("My Transactions")]
        private IWebElement lnkMyTransactions;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'COMMISSIONS'] | //span[text() = 'COMISIONES']")]
        [IDTFieldName("Commissions")]
        private IWebElement lnkCommissions;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'CREDIT BALANCE HISTORY'] | //span[text() = 'HISTORIA DE SALDO DE CRÉDITO']")]
        [IDTFieldName("Credit Balance History")]
        private IWebElement lnkCreditBalanceHistory;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'BILLING SUMMARY'] | //span[text() = 'Resumen de facturación']")]
        [IDTFieldName("Billing Summary")]
        private IWebElement lnkBillingSummary;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'SALES TEAM'] | //span[text() = 'EQUIPO DE VENTAS']")]
        [IDTFieldName("Sales Team")]
        private IWebElement lnkSalesTeam;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'TRENDING REPORT'] | //span[text() = 'INFORME DE TENDENCIA']")]
        [IDTFieldName("Trending Report")]
        private IWebElement lnkTrendingReport;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'REWARDS SUMMARY'] | //span[text() = 'RESUMEN DE REWARDS']")]
        [IDTFieldName("Rewards Summary")]
        private IWebElement lnkRewardsSummary;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'RETAILER REDEMPTION'] | //span[text() = 'REDENCIÓN DE MINORISTA']")]
        [IDTFieldName("Retailer Redemption")]
        private IWebElement lnkRetailerRedemption;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Money Transfer'] | //span[text() = 'Transferencia de dinero']")]
        [IDTFieldName("Money Transfer")]
        private IWebElement lnkMoneyTransfer;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Retailer Transactions'] | //span[text() = 'Transacciones del Minorista']")]
        [IDTFieldName("Retailer Transactions")]
        private IWebElement lnkRetailerTransactions;

        public void ClickOnItem(string item)
        {
            IsElementDisplayed(item);
            Click(item);
        }
    }
}