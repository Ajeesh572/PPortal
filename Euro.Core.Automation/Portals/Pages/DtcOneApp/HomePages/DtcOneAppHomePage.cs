// <copyright file="DtcOneAppHomePage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Portals.Pages.DtcOneApp.HomePages
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Common.HomePages;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Handles the home page in DTC OneApp portal
    /// </summary>
    public class DtcOneAppHomePage : BasePage, IHomePage
    {
        [IDTFindBy(How = How.CssSelector, Using = ".homepage_promo_inner [data-page='home_index']")]
        private IWebElement PnlHome;

        /// <inheritdoc/>
        public bool IsHomePage()
        {
            try
            {
                return PnlHome.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
