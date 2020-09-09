// <copyright file="ActivationsComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Activations component
    /// </summary>
    public class ActivationsComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.XPath, Using = "(//a[@href='/debit/oasis/transaction/Activation.cfm?init=true'])[1]")]
        [IDTFieldName("ACTIVATION REQUEST ENTRY")]
        private IWebElement LnkActivationRequestEntry;

        [IDTFindBy(How = How.XPath, Using = "(//a[@href='/debit/oasis/transaction/Activation.cfm?init=true'])[2]")]
        [IDTFieldName("NEW ACTIVATION ENTRY")]
        private IWebElement LnkNewActivationEntry;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/ActivationsPending.cfm']")]
        [IDTFieldName("PENDING ACTIVATIONS")]
        private IWebElement LnkPendingActivations;

        [IDTFindBy(How = How.XPath, Using = "(//a[@href='/debit/oasis/transaction/Deactivation.cfm?init=true'])[1]")]
        [IDTFieldName("DEACTIVATION REQUEST ENTRY")]
        private IWebElement LnkDeactivationRequestEntry;

        [IDTFindBy(How = How.XPath, Using = "(//a[@href='/debit/oasis/transaction/Deactivation.cfm?init=true'])[2]")]
        [IDTFieldName("NEW DEACTIVATION ENTRY")]
        private IWebElement LnkNewDeactivationEntry;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/DeactivationsPending.cfm']")]
        [IDTFieldName("PENDING DEACTIVATIONS")]
        private IWebElement LnkPendingDeactivations;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/DeactExtract.cfm']")]
        [IDTFieldName("DEACTIVATION EXTRACT")]
        private IWebElement LnkDeactivationExtract;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/Order/PendingOrderConsole.cfm']")]
        [IDTFieldName("PENDING FUBB ORDERS")]
        private IWebElement LnkPendingFUBBOrders;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/DeadbeatPending.cfm']")]
        [IDTFieldName("PENDING DEADBEATS")]
        private IWebElement LnkPendingDeadbeats;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/ReactivationPending.cfm']")]
        [IDTFieldName("PENDING REACTIVATIONS")]
        private IWebElement LnkPendingReactivations;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/transaction/Deadbeat.cfm?init=true']")]
        [IDTFieldName("DEADBEAT REQUEST")]
        private IWebElement LnkDeadbeatRequest;

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
