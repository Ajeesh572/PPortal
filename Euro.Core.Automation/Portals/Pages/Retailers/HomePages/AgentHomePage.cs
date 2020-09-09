// -------------------------------------------------------
// <copyright file="AgentHomePage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
// -------------------------------------------------------

namespace Euro.XGen.Main.UI.Pages.HomePages
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Common.HomePages;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Agent home page object.
    /// </summary>
    public class AgentHomePage : BasePage, IHomePage
    {
        [IDTFindBy(How = How.CssSelector, Using = ".log-out")]
        private IWebElement btnLogOut;

        /// <summary>
        /// Verify if to be in Home portal Web.
        /// </summary>
        /// <returns>True if to be in Home portal Web.</returns>
        public bool IsHomePage()
        {
            return this.btnLogOut.Displayed;
        }
    }
}
