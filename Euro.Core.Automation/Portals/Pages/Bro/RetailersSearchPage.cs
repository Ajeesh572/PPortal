// <copyright file="RetailersSearchPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Bro
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using Euro.Core.Automation.Portals.Utils;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class is to handle Retailers SearchPage page.
    /// </summary>
    public class RetailersSearchPage : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "[id=txtSearchRetailer]")]
        public IWebElement TxtRetailerData;

        [IDTFindBy(How = How.CssSelector, Using = "[id=btnFindRetailer]")]
        public IWebElement BtnFindRetailer;

        [IDTFindBy(How = How.CssSelector, Using = "div.header-breadcrumbs > a")]
        public IWebElement LblPageTitle;

        [IDTFindBy(How = How.CssSelector, Using = "div[id='retailer-search-result-div']")]
        public IWebElement TblSearchResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetailersSearchPage"/> class.
        /// </summary>
        public RetailersSearchPage()
        {
            BroWaitHelper.LoadingBRO();
        }

        /// <summary>
        /// Sets the retailer data.
        /// </summary>
        /// <param name="value">Value to fill the retailer data textbox.</param>
        public void SetRetailerData(string value)
        {
            TxtRetailerData.WaitUntilElementIsDisplayed();
            CommonActions.SendKeys(TxtRetailerData, value);
        }

        /// <summary>
        /// Clicks on find retailer button.
        /// </summary>
        public void ClickOnBtnFindRetailer()
        {
            BtnFindRetailer.ClickElementByJavaScript();
        }

        /// <summary>
        /// Verifies that Table result is displayed on Retailers page.
        /// </summary>
        /// <returns>True, if table is displayed.</returns>
        public bool IsRetailerTableDisplayed()
        {
            return TblSearchResult.IsElementDisplayed();
        }

        /// <summary>
        /// Verifies searched value exist on table.
        /// </summary>
        /// <param name="searchValue">Search value as string.</param>
        /// /// <param name="searchCriteria">Search criteria as string.</param>
        /// <returns>True, if search value match with all elements on table.</returns>
        public bool IsSearchValueExistRetailerTable(string searchValue, string searchCriteria)
        {
            IList<IWebElement> columnWebElements = CommonActions.GetListWebElements(By.XPath($"//td[@aria-describedby='retailerGrid_{GetColumnNameSearchOfTableHeader(searchCriteria)}']"));

            if (columnWebElements.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var column in columnWebElements)
                {
                    if (!column.Text.Equals(searchValue))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Verifies that current url is equal to Retailers page's url.
        /// </summary>
        /// <returns>True if current url is Retailers page's url, false otherwise.</returns>
        public bool IsInRetailersPage()
        {
            return Driver.Url.Equals(LblPageTitle.GetAttribute("href"));
        }

        /// <summary>
        /// Gets Retailers page's title.
        /// </summary>
        /// <returns>Page title as string value.</returns>
        public string GetRetailersPageTitle()
        {
            return LblPageTitle.Text;
        }

        /// <summary>
        /// Gets column name search of table header value.
        /// </summary>
        /// <param name="columnName">Column name of table's header.</param>
        /// <returns>Column name as string.</returns>
        private string GetColumnNameSearchOfTableHeader(string columnName)
        {
            Dictionary<string, string> elementNames = new Dictionary<string, string>
            {
                { "Status", "Status" },
                { "Pin/Login", "Pin" },
                { "Account Type", "AccountType" },
                { "Distributor Id", "StoreId" },
                { "Phone", "Phone" },
                { "Master Distributor", "MasterDistributorName" },
                { "Sales Person", "SalesDistributorName" },
                { "Store Name", "StoreName" }
            };

            return elementNames[columnName];
        }
    }
}
