// <copyright file="SalesComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Sales component
    /// </summary>
    public class SalesComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/Sales.cfm?init=true']")]
        [IDTFieldName("ORDER ENTRY")]
        private IWebElement LnkOrderEntry;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/SalesByScan.cfm?init=true']")]
        [IDTFieldName("SCAN ORDER ENTRY")]
        private IWebElement LnkScanOrderEntry;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/SalesPending.cfm']")]
        [IDTFieldName("PENDING SALES ORDER")]
        private IWebElement LnkPendingSalesOrder;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/Return.cfm?init=true']")]
        [IDTFieldName("RETURNS")]
        private IWebElement LnkReturns;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/rt_tp.cfm?init=true']")]
        [IDTFieldName("THIRD PARTY RETURN")]
        private IWebElement LnkThirdPartyReturn;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/ReturnsPending.cfm']")]
        [IDTFieldName("PENDING RETURNS")]
        private IWebElement LnkPendingReturns;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/misc_dtl.cfm?p_initialsetup=yes']")]
        [IDTFieldName("MISC INVOICES")]
        private IWebElement LnkMiscInvoices;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/PendingMisc.cfm']")]
        [IDTFieldName("PENDING MISC INVOICES")]
        private IWebElement LnkPendingMiscInvoices;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/price_list.cfm']")]
        [IDTFieldName("PRICE LIST MAINTENANCE")]
        private IWebElement LnkPriceListMaintenance;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/SpecialPrice.cfm?init=true']")]
        [IDTFieldName("SPECIAL PRICE DEALS")]
        private IWebElement LnkSpecialPriceDeals;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/PendingSalesPacking.cfm']")]
        [IDTFieldName("BACKPACK PRIOR SALES")]
        private IWebElement LnkBackpackPriorSales;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/utility/Routepending.cfm']")]
        [IDTFieldName("ROUTING MANAGEMENT")]
        private IWebElement LnkRoutingManagement;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/transaction/BRBBillConsole.cfm']")]
        [IDTFieldName("BRB BILLS")]
        private IWebElement LnkBrbBills;

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
