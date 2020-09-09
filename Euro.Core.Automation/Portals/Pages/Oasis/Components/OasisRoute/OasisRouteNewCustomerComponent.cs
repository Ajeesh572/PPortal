// <copyright file="OasisRouteNewCustomerComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Oasis Route New Customer component
    /// </summary>
    public class OasisRouteNewCustomerComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#nav a[href='/debit/oasis/Route/NewCustomer.cfm?init=true']")]
        [IDTFieldName("REGISTRATION")]
        private IWebElement LnkRegistration;

        /// <inheritdoc />
        public void ClickOnItem(string item)
        {
            WaitUntilElementDisplayed(item);
            Click(item);
        }

        /// <inheritdoc />
        public void ClickOnSubItem(string item, string subitem)
        {
            // this menu has no submenus
        }
    }
}
