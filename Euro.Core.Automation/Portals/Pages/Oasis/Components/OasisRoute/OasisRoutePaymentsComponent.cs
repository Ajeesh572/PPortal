// <copyright file="OasisRoutePaymentsComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Oasis Route Payments component
    /// </summary>
    public class OasisRoutePaymentsComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteReceipt.cfm?payment_type=CASH&balanceinit=true']")]
        [IDTFieldName("CASH PAYMENT")]
        private IWebElement LnkCashPayment;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteReceipt.cfm?payment_type=NON-CASH&balanceinit=true']")]
        [IDTFieldName("CHECK PAYMENT")]
        private IWebElement LnkCheckPayment;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteDepositSlips.cfm']")]
        [IDTFieldName("DEPOSIT SLIPS")]
        private IWebElement LnkDepositSlips;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteDepositNew.cfm?init=true']")]
        [IDTFieldName("NEW DEPOSIT SLIP")]
        private IWebElement LnkNewDepositSlip;

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
