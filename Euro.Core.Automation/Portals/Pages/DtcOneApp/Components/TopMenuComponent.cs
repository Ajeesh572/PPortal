// <copyright file="TopMenuComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.DtcOneApp.Components
{
    using System;
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.Logger;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Handles the Top Menu Componentes in DTC OneApp portal.
    /// </summary>
    public class TopMenuComponent : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "li[class = 'navbar--item hidden-xs'] a[href = '/en-us/login?ReturnUrl=%2Fen-us%2Fmy-account']")]
        private IWebElement LnkLogin;

        [IDTFindBy(How = How.CssSelector, Using = "li[class = 'navbar--item hidden-xs'] a[href = '/en-us/register?ReturnUrl=%2Fen-us%2Fmy-account']")]
        private IWebElement LnkJoin;

        [IDTFindBy(How = How.CssSelector, Using = "a[class = 'navbar--link pullin-space'][href = '/en-us/services']")]
        private IWebElement LnkServices;

        [IDTFindBy(How = How.CssSelector, Using = "a[class = 'navbar--link'][href = '/en-us/rates']")]
        private IWebElement LnkRates;

        [IDTFindBy(How = How.CssSelector, Using = "a[class = 'navbar--link'][href = '/en-us/apps']")]
        private IWebElement LnkMobileApp;

        [IDTFindBy(How = How.CssSelector, Using = "a[class = 'navbar--link pullin-space'][href = '/en-us/support']")]
        private IWebElement LnkSupport;

        [IDTFindBy(How = How.CssSelector, Using = "a[class = 'navbar--link'][href = '/en-us/brclub']")]
        private IWebElement LnkBrClub;

        [IDTFindBy(How = How.CssSelector, Using = "li[class = 'navbar--item dropdown'] a[class^= 'navbar--link'][href = '/en-us/my-account']")]
        private IWebElement LnkMyAccount;

        [IDTFindBy(How = How.CssSelector, Using = "a[class = 'navbar--link navmenu--link-btn'][href = '/en-us/logout']")]
        private IWebElement BtnSignOut;

        [IDTFindBy(How = How.CssSelector, Using = "[id='dropdownServices'] [class='btn btn-dropdown btn-xs']")]
        private IWebElement BtnServicesArrow;

        [IDTFindBy(How = How.CssSelector, Using = "[id='dropdownAccount'] [class='btn btn-dropdown btn-xs']")]
        private IWebElement BtnAccountArrow;

        // this locator appears with mobile resolution
        [IDTFindBy(How = How.CssSelector, Using = "[class='visible-xs'] [class='mobilenav-button mobilenav-button-top']")]
        private IWebElement BtnMenu;

        [IDTFindBy(How = How.CssSelector, Using = "a[class = 'navbar--link navbar--link-after'][href = '/en-us/logout']")]
        private IWebElement BtnSignOutLow;

        /// <summary>
        /// Clicks on an option in the top menu.
        /// </summary>
        /// <param name="option">Is an option of the top menu</param>
        public void GoToTopOption(string option)
        {
            Dictionary<string, IWebElement> topMenuOptions = new Dictionary<string, IWebElement>
            {
                { "LOGIN", this.LnkLogin },
                { "JOIN", this.LnkJoin },
                { "SERVICES", this.LnkServices },
                { "RATES", this.LnkRates },
                { "MOBILE APP", this.LnkMobileApp },
                { "SUPPORT", this.LnkSupport },
                { "BR CLUB", this.LnkBrClub },
                { "MY ACCOUNT", this.LnkMyAccount },
                { "SIGN OUT", this.BtnSignOut },
            };
            CommonActions.ClickElement(topMenuOptions[option.ToUpper()]);
        }

        /// <summary>
        /// Clicks on an arrow option in the top menu.
        /// </summary>
        /// <param name="option">Is an arrow option of the top menu</param>
        public void GoToSubOption(string option)
        {
            Dictionary<string, IWebElement> topMenuOptions = new Dictionary<string, IWebElement>
            {
                { "SERVICES", this.BtnServicesArrow },
                { "MY ACCOUNT", this.BtnAccountArrow }
            };
            CommonActions.ClickElement(topMenuOptions[option.ToUpper()]);
        }

        /// <summary>
        /// Clicks on Sign Out option in the top menu.
        /// </summary>
        public void GoToSignOutOption()
        {
                Logging.Debug($"Click on logout button");
                Action action = () =>
                {
                    // this webElement appears with mobile resolution
                    if (BtnMenu.Displayed)
                    {
                        CommonActions.ClickElement(BtnMenu);
                        CommonActions.ClickElement(BtnSignOutLow);
                    }
                    else
                    {
                        CommonActions.WaitUntilElementIsInvisible(By.CssSelector("[class='modal-backdrop fade in']"));
                        CommonActions.ClickElement(BtnSignOut);
                    }
                };
                Utils.HandleException(action, $"Error while trying to click logout button");
        }
    }
}
