// <copyright file="ToolsComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Tools component
    /// </summary>
    public class ToolsComponent : BasePage, IRetailerComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href = '/Stores/Manage']")]
        [IDTFieldName("Manage Stores")]
        private IWebElement lnkManageStores;

        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href = '/Account/PersonalInfo']")]
        [IDTFieldName("Account Information")]
        private IWebElement lnkAccountInformation;

        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href = '/Agents/Manage']")]
        [IDTFieldName("Manage Agents")]
        private IWebElement lnkManageAgents;

        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href = '/Rates/RatesAccessNumbers']")]
        [IDTFieldName("Rates And Access Numbers")]
        private IWebElement lnkRatesAndAccessNumbers;

        /// <summary>
        /// Clicks an item inside the component.
        /// </summary>
        /// <param name="item">The item that will be clicked.</param>
        public void ClickOnItem(string item)
        {
            GetWebElementByFieldName(item).ClickElement();
        }
    }
}
