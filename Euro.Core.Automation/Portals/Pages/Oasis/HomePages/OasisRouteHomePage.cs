// <copyright file="OasisRouteHomePage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.HomePages
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Common.HomePages;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.Elements.Table;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Handles the home page in Oasis Route portal
    /// </summary>
    public class OasisRouteHomePage : BasePage, IHomePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/'] > img")]
        private IWebElement ImgOasis;

        [IDTFindBy(How = How.CssSelector, Using = "table + table > tbody > tr + tr > td > fieldset > table")]
        private IWebElement customersTable;

        [IDTFindBy(How = How.CssSelector, Using = "table + table > tbody > tr + tr > td ~ td > table > tbody > tr:nth-child(1) table")]
        private IWebElement totalSalesTable;

        [IDTFindBy(How = How.CssSelector, Using = "table + table > tbody > tr + tr > td ~ td > table > tbody > tr:nth-child(2) table")]
        private IWebElement totalCollectionsTable;

        /// <inheritdoc/>
        public bool IsHomePage()
        {
            return ImgOasis.IsElementDisplayed();
        }

        /// <summary>
        /// Returns a Table object representing the customers table
        /// </summary>
        /// <returns>a Table object for the customers table</returns>
        public Table GetCustomersTable()
        {
            return new Table(customersTable, By.CssSelector("tbody > tr"))
            {
                ColumnTitles = new string[]
                {
                    "Customer", "Address", "City", "State",
                    "Zip", "Phone", "Consign Total", "Outstanding Balance",
                    "Balance As Of Date"
                }
            };
        }

        /// <summary>
        /// Returns a Table object representing the total sales table
        /// </summary>
        /// <returns>a Table object for the total sales table</returns>
        public Table GetTotalSalesTable()
        {
            return new Table(totalSalesTable, By.CssSelector("tbody > tr"))
            {
                ColumnTitles = new string[]
                {
                    "Date", "Amount"
                }
            };
        }

        /// <summary>
        /// Returns a Table object representing the total collections table
        /// </summary>
        /// <returns>a Table object for the total collections table</returns>
        public Table GetTotalCollectionsTable()
        {
            return new Table(totalCollectionsTable, By.CssSelector("tbody > tr"))
            {
                ColumnTitles = new string[]
                {
                    "Date", "Amount"
                }
            };
        }
    }
}
