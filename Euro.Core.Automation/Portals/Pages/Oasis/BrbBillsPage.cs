// <copyright file="BrbBillsPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis
{
    using System.Linq;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Handles web elements in BRB Bills page.
    /// </summary>
    public class BrbBillsPage : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "img[alt='Set Filter']")]
        private IWebElement BtnSetFilter;

        /// <summary>
        /// Clicks on BtnSetSetFilter.
        /// </summary>
        public void ClickOnSetFilterButton()
        {
            CommonActions.ClickElement(BtnSetFilter);
        }

        /// <summary>
        /// Verifies if specific data in invoice row is displayed.
        /// </summary>
        /// <param name="info">Is the data to search in the row</param>
        /// <returns>True if information in first element found inside invoice row is displayed</returns>
        public bool IsInfoDisplayedInFirstElementFound(string info)
        {
            IWebElement rowData = Driver.FindElements(By.XPath(string.Format("//td[contains(text(), '{0}')]", info))).First();
            return rowData.IsElementDisplayed();
        }

        /// <summary>
        /// Verifies if a link with invoice TNUM data is displayed.
        /// </summary>
        /// <param name="info">Is the TNUM to search in the row</param>
        /// <returns>True if invoice link is displayed</returns>
        public bool IsInvoiceLinkDisplayed(string info)
        {
            IWebElement lnkInvoiceCm = Driver.FindElement(By.XPath(string.Format("//a[@class = 'redtext' and contains(text(), '{0}')]", info)));
            return lnkInvoiceCm.IsElementDisplayed();
        }

        /// <summary>
        /// Gets the text data in a row.
        /// </summary>
        /// <param name="data">Is the data to search</param>
        /// <returns>Specific data in a row</returns>
        public string GetRowData (string data)
        {
            IWebElement rowData = Driver.FindElements(By.XPath(string.Format("//td[contains(text(), '{0}')]", data))).First();
            return rowData.Text.Trim();
        }
    }
}
