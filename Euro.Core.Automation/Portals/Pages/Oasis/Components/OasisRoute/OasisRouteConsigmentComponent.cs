// <copyright file="OasisRouteConsigmentComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Oasis Route Consigment component
    /// </summary>
    public class OasisRouteConsigmentComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/ConsignCount.cfm?init=true']")]
        [IDTFieldName("STEP 1: COUNT")]
        private IWebElement LnkStep1Count;

        // sublinks for Step 1: Count
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/ConsignNewCount.cfm?init=true']")]
        [IDTFieldName("NEW COUNT (IDT)")]
        private IWebElement LnkNewCountIDT;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/ConsignNewCount.cfm?init=true&tp_flag=true']")]
        [IDTFieldName("NEW COUNT (NON-IDT)")]
        private IWebElement LnkNewCountNonIDT;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/ConsignReturn.cfm']")]
        [IDTFieldName("STEP 2: RETURN")]
        private IWebElement LnkStep2Return;

        // sublinks for Step 2: Return
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteCardReturn.cfm?init=true&consign=true']")]
        [IDTFieldName("NEW RETURN (IDT)")]
        private IWebElement LnkNewReturnIDT;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteItemReturn.cfm?init=true&consign=true&tp_flag=true']")]
        [IDTFieldName("NEW RETURN (NON-IDT)")]
        private IWebElement LnkNewReturnNonIDT;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/ConsignInventory.cfm?init=true']")]
        [IDTFieldName("STEP 3: INVENTORY")]
        private IWebElement LnkStep3Inventory;

        // sublinks for Step 3: Inventory
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteCardSale.cfm?init=true&consign=true']")]
        [IDTFieldName("NEW INVENTORY (IDT)")]
        private IWebElement LnkNewInventoryIDT;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteItemSale.cfm?init=true&consign=true&tp_flag=true']")]
        [IDTFieldName("NEW INVENTORY (NON-IDT)")]
        private IWebElement LnkNewInventoryNonIDT;

        [IDTFindBy(How = How.XPath, Using = "(//ul[@id='nav']/li/ul/li[normalize-space(text())='Reports'])[2]")]
        [IDTFieldName("REPORTS")]
        private IWebElement MenuReports;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RptDailyConsignment.cfm?init=true']")]
        [IDTFieldName("DAILY REPORT")]
        private IWebElement LnkDailyReport;

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
