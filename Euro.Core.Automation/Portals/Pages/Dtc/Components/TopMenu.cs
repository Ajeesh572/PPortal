// <copyright file="TopMenu.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Dtc.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class TopMenu : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href = 'index.html']")]
        private IWebElement LnkHome;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = 'index.html#rates-block']")]
        private IWebElement LnkRates;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = 'index.html#coverage']")]
        private IWebElement LnkCoverage;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = 'http://store.bossrevolutionmobile.com/phones-2']")]
        private IWebElement LnkShop;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = 'register.html']")]
        private IWebElement LnkJoinUs;

        [IDTFindBy(How = How.Id, Using = "linkSignIn")]
        private IWebElement LnkSignIn;

        [IDTFindBy(How = How.Id, Using = "linkHelp")]
        private IWebElement LnkHelp;

        /// <summary>
        /// Clicks an option from the top menu.
        /// </summary>
        /// <param name="option">Is an option of the top menu</param>
        public void GoToTopOption(string option)
        {
            Dictionary<string, IWebElement> topMenuOptions = new Dictionary<string, IWebElement>
            {
                { "HOME", this.LnkHome },
                { "RATES", this.LnkRates },
                { "COVERAGE", this.LnkCoverage },
                { "SHOP", this.LnkShop },
                { "JOIN US", this.LnkJoinUs },
                { "HELP", this.LnkHelp },
                { "SIGNIN", this.LnkSignIn }
            };
            topMenuOptions[option].Click();
        }
    }
}
