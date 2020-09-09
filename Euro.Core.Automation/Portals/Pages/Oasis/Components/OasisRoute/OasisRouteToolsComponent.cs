// <copyright file="OasisRouteToolsComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Oasis Route Tools component
    /// </summary>
    public class OasisRouteToolsComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteActivations.cfm']")]
        [IDTFieldName("ACTIVATIONS")]
        private IWebElement LnkActivations;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteDeactivations.cfm']")]
        [IDTFieldName("DEACTIVATIONS")]
        private IWebElement LnkDeactivations;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteReconPending.cfm']")]
        [IDTFieldName("INVENTORY RECONCILIATION")]
        private IWebElement LnkInventoryReconciliation;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteReconIDTInv.cfm?init=true']")]
        [IDTFieldName("NEW RECONCILIATION(IDT)")]
        private IWebElement LnkNewReconciliationIDT;

        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/RouteReconNon-IDTInv.cfm?init=true']")]
        [IDTFieldName("NEW RECONCILIATION(NON-IDT)")]
        private IWebElement LnkNewReconciliationNonIDT;

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
