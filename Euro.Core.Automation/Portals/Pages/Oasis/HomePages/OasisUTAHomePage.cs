// <copyright file="OasisUTAHomePage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.HomePages
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Common.HomePages;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Handles the home page in OasisUTA portal.
    /// </summary>
    public class OasisUTAHomePage : BasePage, IHomePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/'] > img")]
        private IWebElement ImgOasis;

        /// <inheritdoc/>
        public bool IsHomePage()
        {
            return ImgOasis.IsElementDisplayed();
        }
    }
}
