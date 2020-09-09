// <copyright file="RetailerVerticalTabComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the vertical Retailer Tab component
    /// </summary>
    public class RetailerVerticalTabComponent : BasePage
    {
        [IDTFindBy(How = How.XPath, Using = "//a[text() = 'HOME'] | //a[text() = 'Página de inicio']")]
        private IWebElement TabHome;

        [IDTFindBy(How = How.XPath, Using = "//a[text() = 'Products']  | //a[text() = 'Productos']")]
        private IWebElement TabProducts;

        [IDTFindBy(How = How.XPath, Using = "//a[text() = 'REPORTS'] | //a[text() = 'REPORTES']")]
        private IWebElement TabReports;

        [IDTFindBy(How = How.XPath, Using = "//a[text() = 'Br University'] | //a[text() = 'Universidad BR']")]
        private IWebElement TabBrUniversity;

        [IDTFindBy(How = How.XPath, Using = "//a[text() = 'TOOLS'] | //a[text() = 'HERRAMIENTAS']")]
        private IWebElement TabTools;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/Home/About']")]
        private IWebElement TabAbout;

        /// <summary>
        /// Clicks over an item inside the component
        /// </summary>
        /// <param name="tabOption"></param>
        public void ClickOnTapOption(string tabOption)
        {
            Dictionary<string, IWebElement> tabs = new Dictionary<string, IWebElement>
            {
                { "Home", TabHome },
                { "Products", TabProducts },
                { "Reports", TabReports },
                { "BR University", TabBrUniversity },
                { "Tools", TabTools },
                { "About", TabAbout }
            };

            tabs[tabOption].WaitUntilElementIsDisplayed();
            tabs[tabOption].Click();
        }
    }
}
