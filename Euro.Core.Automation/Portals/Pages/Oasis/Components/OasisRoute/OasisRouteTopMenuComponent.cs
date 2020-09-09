// <copyright file="OasisRouteTopMenuComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class represent top menu element in Oasis route portal with their respective operations.
    /// </summary>
    public class OasisRouteTopMenuComponent : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/index.cfm']")]
        [IDTFieldName("HOME")]
        private IWebElement TabHome;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteSales.cfm?init=true']")]
        [IDTFieldName("SALES")]
        private IWebElement TabSales;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RoutePayments.cfm?init=true']")]
        [IDTFieldName("PAYMENTS")]
        private IWebElement TabPayments;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteReturns.cfm?init=true']")]
        [IDTFieldName("RETURNS")]
        private IWebElement TabReturns;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/Consignment.cfm?init=true']")]
        [IDTFieldName("CONSIGNMENT")]
        private IWebElement TabConsignment;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/NewCustomerConsole.cfm']")]
        [IDTFieldName("NEW CUSTOMER")]
        private IWebElement TabNewCustomer;

        [IDTFindBy(How = How.XPath, Using = "//ul[@id='nav']/li[normalize-space(text())='Tools']")]
        [IDTFieldName("TOOLS")]
        private IWebElement TabTools;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteAdmin.cfm?init=true']")]
        [IDTFieldName("ADMIN")]
        private IWebElement TabAdmin;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/logout.cfm']")]
        [IDTFieldName("LOGOUT")]
        private IWebElement TabLogout;

        /// <summary>
        /// Clicks over an item inside the component
        /// </summary>
        /// <param name="tabOption">Name of Tab</param>
        public void ClickOnTabOption(string tabOption)
        {
            Click(tabOption);
        }

        /// <summary>
        /// Hovers over one of the tabs
        /// </summary>
        /// <param name="tabOption">Name of tab</param>
        public void HoverOnTabOption(string tabOption)
        {
            HoverOnTabOption(tabOption);
        }
    }
}
