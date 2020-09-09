// <copyright file="ReceiptsComponents.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Receipts component
    /// </summary>
    public class ReceiptsComponents : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href *= '/debit/oasis/receipt/ReceiptNewEdit.cfm']")]
        [IDTFieldName("RECEIPT ENTRY")]
        private IWebElement LnkReceiptEntry;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/receipt/ReceiptConsole.cfm']")]
        [IDTFieldName("RECEIPT CONSOLE")]
        private IWebElement LnkReceiptConsole;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/receipt/ReceiptFinder.cfm']")]
        [IDTFieldName("RECEIPT FINDER")]
        private IWebElement LnkReceiptFinder;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/receipt/UnRegulatedReceipt.cfm']")]
        [IDTFieldName("UNREGULATED RECEIPT")]
        private IWebElement LnkUnRegulatedReceipt;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/receipt/ReceiptReversal.cfm']")]
        [IDTFieldName("RECEIPT REVERSAL")]
        private IWebElement LnkReceiptReversal;

        [IDTFindBy(How = How.CssSelector, Using = "a[href *= '/debit/oasis/receipt/ReceiptCoverage.cfm")]
        [IDTFieldName("RECEIPT COVERAGE")]
        private IWebElement LnkReceiptCoverage;

        [IDTFindBy(How = How.CssSelector, Using = "a[href *= '/debit/oasis/receipt/DepositNewEdit.cfm']")]
        [IDTFieldName("DEPOSIT ENTRY")]
        private IWebElement LnkDepositEntry;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/receipt/carrier.cfm']")]
        [IDTFieldName("CARRIER ENTRY")]
        private IWebElement LnkCarrierEntry;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/receipt/8300FormsSetup.cfm']")]
        [IDTFieldName("8300 FORM")]
        private IWebElement Lnk8300Form;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/receipt/RptCashFlow.cfm']")]
        [IDTFieldName("REPORTS")]
        private IWebElement LnkReports;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/receipt/RegulatedReceipt.cfm")]
        [IDTFieldName("REGULATED RECEIPT")]
        private IWebElement LnkRegulatedReceipt;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/receipt/DepositConsoleSetup.cfm']")]
        [IDTFieldName("DEPOSIT CONSOLE")]
        private IWebElement LnkDepositConsole;

        /// <inheritdoc />
        public void ClickOnItem(string item)
        {
            Click(item);
        }

        /// <inheritdoc />
        public void ClickOnSubItem(string item, string subitem)
        {
            // no submenus for this tab
        }
    }
}
