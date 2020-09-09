// <copyright file="DashboardPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Bro
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Utils;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class is to handle the Dashboard page.
    /// </summary>
    public class DashboardPage : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='/Distributor/Index']")]
        private IWebElement LnkDistributor;

        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='/RetailerManagement/Index']")]
        private IWebElement LnkRetailerManagement;

        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='CustomerManagement/Index']")]
        private IWebElement LnkCustomerManagement;

        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='/ProfileManagement/Index']")]
        private IWebElement LnkProfileManagement;

        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='/ProductManagement/Products']")]
        private IWebElement LnkProductManagement;

        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='/MoneyTransfer/Splash']")]
        private IWebElement LnkMoneyTransfer;

        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='/Changeset/Index']")]
        private IWebElement LnkCms;

        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='/ChannelManagement/Index']")]
        private IWebElement LnkConfiguration;

        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='/Report/Index']")]
        private IWebElement LnkReports;

        [IDTFindBy(How = How.CssSelector, Using = "div[class='box-info--container'] a[class*='icon-box'][href*='/About']")]
        private IWebElement LnkAbout;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardPage"/> class.
        /// </summary>
        public DashboardPage()
        {
            BroWaitHelper.LoadingBRO();
        }

        /// <summary>
        /// Clicks on option link choose.
        /// </summary>
        /// <param name="option">The option to choose.</param>
        public void ClickOnLknOption(string option)
        {
            Dictionary<string, IWebElement> dashboardOption = new Dictionary<string, IWebElement>
            {
                { "Distributors", LnkDistributor },
                { "Retailers", LnkRetailerManagement },
                { "Customers", LnkCustomerManagement },
                { "Profiles", LnkProfileManagement },
                { "Products", LnkProductManagement },
                { "Money Transfer", LnkMoneyTransfer },
                { "Cms", LnkCms },
                { "Configuration", LnkConfiguration },
                { "Reports", LnkReports },
                { "About", LnkAbout }
            };

            CommonActions.ClickElement(dashboardOption[option]);
        }
    }
}
