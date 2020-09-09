// <copyright file="OasisRouteSalesComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Oasis Route Sales component
    /// </summary>
    public class OasisRouteSalesComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteCardSale.cfm?init=true']")]
        [IDTFieldName("CARD SALE")]
        private IWebElement LnkCardSale;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteAllItemSale.cfm?init=true']")]
        [IDTFieldName("ITEM SALE (ALL)")]
        private IWebElement LnkItemSaleAll;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteItemSale.cfm?init=true&TP_flag=false']")]
        [IDTFieldName("ITEM SALE (IDT)")]
        private IWebElement LnkItemSaleIDT;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteItemSale.cfm?init=true&TP_flag=true']")]
        [IDTFieldName("ITEM SALE (NON-IDT)")]
        private IWebElement LnkItemSaleNonIDT;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/NewCustomerSale.cfm']")]
        [IDTFieldName("NEW CUSTOMER SALE (CARD)")]
        private IWebElement LnkNewCustomerSaleCard;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/NewCustomerSale.cfm?sale_type=ITEM&tp_flag=false']")]
        [IDTFieldName("NEW CUSTOMER SALE (IDT ITEM)")]
        private IWebElement LnkNewCustomerSaleIDTItem;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/NewCustomerSale.cfm?sale_type=ITEM&tp_flag=true']")]
        [IDTFieldName("NEW CUSTOMER SALE (NON-IDT ITEM)")]
        private IWebElement LnkNewCustomerSaleNonIDTItem;

        [IDTFindBy(How = How.XPath, Using = "(//ul[@id='nav']/li/ul/li[normalize-space(text())='Reports'])[1]")]
        [IDTFieldName("REPORTS")]
        private IWebElement MenuReports;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RptRoutePriceList.cfm']")]
        [IDTFieldName("PRICE LIST REPORT")]
        private IWebElement LnkPriceListReport;

        /// <inheritdoc />
        public void ClickOnItem(string item)
        {
            WaitUntilElementDisplayed(item);
            Click(item);
        }

        /// <inheritdoc />
        public void ClickOnSubItem(string item, string subitem)
        {
            WaitUntilElementDisplayed(item);
            HoverOverElement(item);
            WaitUntilElementDisplayed(subitem);
            Click(subitem);
        }
    }
}
