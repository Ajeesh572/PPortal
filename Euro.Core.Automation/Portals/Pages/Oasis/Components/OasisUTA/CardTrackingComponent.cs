// <copyright file="CardTrackingComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Card Tracking component
    /// </summary>
    public class CardTrackingComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/ListJobs.cfm']")]
        [IDTFieldName("JOBS")]
        private IWebElement LnkJobs;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/EnterCards.cfm']")]
        [IDTFieldName("INITIAL ENTRY")]
        private IWebElement LnkInitialEntry;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/xfer_pending.cfm']")]
        [IDTFieldName("TRANSFER REQUESTS")]
        private IWebElement LnkTransferRequests;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/pin_pending.cfm']")]
        [IDTFieldName("PIN REQUESTS")]
        private IWebElement LnkPinRequests;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/CardFinder.cfm']")]
        [IDTFieldName("CARD FINDER")]
        private IWebElement LnkCardFinder;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/GetCardBalanceCfx.cfm']")]
        [IDTFieldName("CARD BALANCE")]
        private IWebElement LnkCardBalance;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/CardImporter.cfm']")]
        [IDTFieldName("CARD IMPORTER")]
        private IWebElement LnkCardImporter;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/ChangeCardStatus.cfm']")]
        [IDTFieldName("CHANGE CARD STATUS")]
        private IWebElement LnkChangeCardStatus;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/GMInventoryLoad.cfm?init=true']")]
        [IDTFieldName("GM INVENTORY LOAD")]
        private IWebElement LnkGMInventoryLoad;

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
