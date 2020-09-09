// <copyright file="ReportVerticalComponent.cs" company="Eurofins">
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
    /// Class to handle the vertical Report component.
    /// </summary>
    public class ReportVerticalComponent : BasePage, IRetailerComponent
    {
        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'TRANSACTION HISTORY'] | //span[text() = 'HISTORIAL DE TRANSACCIONES']")]
        private IWebElement LnkTransactionHistory;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'MONEY TRANSFER TRANSACTIONS'] | //span[text() = 'TRANSACCIONES DE ENVÍO DE DINERO']")]
        private IWebElement LnkMTTransactions;

        [IDTFindBy(How = How.XPath, Using = "//a[span[text() = 'RUNNING BALANCE REPORT'] | span[text() = 'REPORT DE SALDO EN EJECUCIÓN']]")]
        private IWebElement LnkRunningBalance;

        /// <inherit>
        public void ClickOnItem(string item)
        {
            Dictionary<string, IWebElement> items = new Dictionary<string, IWebElement>
            {
                { "Transaction History", LnkTransactionHistory },
                { "Money Transfer Transactions", LnkMTTransactions },
                { "Running Balance Report", LnkRunningBalance }
            };

            items[item].WaitUntilElementIsDisplayed();
            items[item].Click();
        }
    }
}
