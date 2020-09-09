// <copyright file="DistributorHomePage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Distributor
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Common.HomePages;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class handles the Distributor Home Page.
    /// </summary>
    public class DistributorHomePage : BasePage, IHomePage
    {
        [IDTFindBy(How = How.CssSelector, Using = ".log-out")]
        private IWebElement btnLogOut;

        /// <summary>
        /// Verifys if to be in Home portal Web.
        /// </summary>
        /// <returns>True if to be in Home portal Web.</returns>
        public bool IsHomePage()
        {
            return btnLogOut.IsElementDisplayed();
        }
    }
}
