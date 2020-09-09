// <copyright file="TopMenuComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class represent top menu element in Oasis portal with their respective operations.
    /// </summary>
    public class TopMenuComponent : BasePage
    {
        [IDTFindBy(How = How.XPath, Using = "//ul[@id='nav']//a[text()='Card Tracking']")]
        [IDTFieldName("CARD TRACKING")]
        private IWebElement TabCardTracking;

        [IDTFindBy(How = How.XPath, Using = "//ul[@id='nav']//a[text()='Sales']")]
        [IDTFieldName("SALES")]
        private IWebElement TabSales;

        [IDTFindBy(How = How.XPath, Using = "//ul[@id='nav']//a[text()='Activations']")]
        [IDTFieldName("ACTIVATIONS")]
        private IWebElement TabActivations;

        [IDTFindBy(How = How.XPath, Using = "//ul[@id='nav']//a[text()='Receipts']")]
        [IDTFieldName("RECEIPTS")]
        private IWebElement TabReceipts;

        [IDTFindBy(How = How.XPath, Using = "//ul[@id='nav']/li/a[text()='Reports']")]
        [IDTFieldName("REPORTS")]
        private IWebElement TabReports;

        [IDTFindBy(How = How.XPath, Using = "//ul[@id='nav']//a[text()='Admin']")]
        [IDTFieldName("ADMIN")]
        private IWebElement TabAdmin;

        [IDTFindBy(How = How.XPath, Using = "//ul[@id='nav']//a[text()='Switch Locations']")]
        [IDTFieldName("SWITCH LOCATIONS")]
        private IWebElement TabSwitchLocations;

        [IDTFindBy(How = How.XPath, Using = "//ul[@id='nav']//a[text()='Logout']")]
        [IDTFieldName("LOGOUT")]
        private IWebElement TabLogout;

        /// <summary>
        /// Clicks over an item inside the component
        /// </summary>
        /// <param name="tabOption">Name of Tab</param>
        public void ClickOnTapOption(string tabOption)
        {
            Click(tabOption);
        }
    }
}
