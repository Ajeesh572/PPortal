// <copyright file="OasisRouteReturnsComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Oasis Route Returns component
    /// </summary>
    public class OasisRouteReturnsComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteCardReturn.cfm?init=true']")]
        [IDTFieldName("CARD RETURN")]
        private IWebElement LnkCashPayment;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteItemReturn.cfm?init=true']")]
        [IDTFieldName("ITEM RETURN")]
        private IWebElement LnkCheckPayment;

        /// <inheritdoc />
        public void ClickOnItem(string item)
        {
            WaitUntilElementDisplayed(item);
            Click(item);
        }

        /// <inheritdoc />
        public void ClickOnSubItem(string item, string subitem)
        {
            // no submenus for this tab
        }
    }
}
