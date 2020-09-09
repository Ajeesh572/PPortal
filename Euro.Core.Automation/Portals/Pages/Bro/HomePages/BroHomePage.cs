// <copyright file="BossRevolutionOrganizerPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Bro.HomePages
{
    using System;
    using Core.Automation.Selenium;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Bro.Components;
    using Euro.Core.Automation.Portals.Pages.Common.HomePages;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class is to handle BossRevolutionOrganizerPage page.
    /// </summary>
    public class BroHomePage : BasePage, IHomePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "div[class*='header-'] a[href*='/Home/Index']")]
        public IWebElement LnkBossRevolutionOrganizerTitle;

        [IDTFindBy(How = How.CssSelector, Using = "a[href*='RetailerManagement/Index'][class*='btn']")]
        public IWebElement LnkRetailers;

        public LeftMenuComponent leftMenu;

        /// <summary>
        /// Initializes a new instance of the <see cref="BroHomePage"/> class.
        /// </summary>
        public BroHomePage()
        {
            this.leftMenu = new LeftMenuComponent();
        }

        /// <summary>
        /// Verifies BRO home page is displayed
        /// </summary>
        /// <returns>True or false in bool format.</returns>
        public bool IsHomePage()
        {
            return this.LnkBossRevolutionOrganizerTitle.Displayed;
        }

        /// <summary>
        /// Clicks on Retailers link
        /// </summary>
        public void ClickOnRetailersLink()
        {
            try
            {
                CommonActions.WaitUntilLocatorExists(Utils.GetByLocator("BossRevolutionOrganizerLocators", "AlertLoadingDisplayNone"));
                CommonActions.ClickElement(this.LnkRetailers);
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException("Boss Revolution Organizer Page was not loaded in the time expected.", e);
            }
        }
    }
}
