// <copyright file="LoginHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Utils
{
    using System;
    using System.ComponentModel;
    using Euro.Core.Automation.Portals.Pages.Common;
    using Euro.Core.Automation.Portals.Pages.Common.HomePages;
    using Euro.Core.Automation.Portals.Pages.Common.LoginPages;
    using Euro.Core.Automation.Portals.Pages.Dtc.LoginPages;
    using Euro.Core.Automation.Portals.Pages.DtcOneApp.LoginPages;
    using Euro.Core.Automation.Portals.Pages.Oasis;
    using Euro.Core.Automation.Portals.Pages.Retailers.LoginPages;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.Helpers.Enums;
    using Euro.Core.Automation.Utilities.JsonManager;
    using OpenQA.Selenium;

    /// <summary>
    /// This class contains the methods that will be used to handle the login logic.
    /// </summary>
    public class OneAppLoginHelper
    {
        private static ILoginPage loginPage;

        /// <summary>
        /// Makes sure to go to the login page in case the current page does not have a LogOut button.
        /// </summary>
        /// <param name="currentPortalWeb">Is the portal were this method is trying to go</param>
        public static void GoToLoginPage(PortalWeb currentPortalWeb)
        {
            PortalPageTransporter pageTransporter = PortalPageTransporter.Instance;
            pageTransporter.NavigateToLoginPortalWeb(currentPortalWeb);
        }

        /// <summary>
        /// Logins to portal with given credentials.
        /// </summary>
        /// <param name="currentPortalWeb">The portal to login</param>
        /// <param name="currentUserType">The type of user for correct credentials</param>
        public static void LoginToWebWithCredentials(PortalWeb currentPortalWeb, UserType currentUserType)
        {
            PortalPageTransporter pageTransporter = PortalPageTransporter.Instance;

            if (currentPortalWeb != PortalWeb.Bro && currentPortalWeb != PortalWeb.Fireball && currentPortalWeb != PortalWeb.Unified)
            {
                // Navigate to login portal web
                pageTransporter.NavigateToLoginPortalWeb(currentPortalWeb);

                loginPage = GetLoginPageInstance(currentPortalWeb);
                if (loginPage.IsLoginPage())
                {
                    // Login in Portal Web.
                    loginPage.LoginAsUserType(currentUserType, currentPortalWeb);
                }
                else
                {
                    IHomePage homePage = new HomePageFactory().CreateHomePage(currentPortalWeb);
                    if (!homePage.IsHomePage())
                    {
                        pageTransporter.NavigateMainPortalWeb(currentPortalWeb);
                    }
                }

                return;
            }

            if (currentPortalWeb == PortalWeb.Unified)
            {
                BasicAuth(currentPortalWeb, currentUserType);
                pageTransporter.NavigateToURL((EnvironmentManager.GetPortal(currentPortalWeb.GetStringValue()).BaseUrl).ToString());
                CommonActions.WaitUntilElementIsDisplayed(By.CssSelector(".fa.fa-user"));
            }

            if (currentPortalWeb == PortalWeb.Bro)
            {
                BasicAuth(currentPortalWeb, currentUserType);

                // Navigates to Main page of Bro portal
                CommonActions.WaitUntilElementIsDisplayed(By.CssSelector("img[src = '/Content/Images/logo.png']"));
            }

            if (currentPortalWeb == PortalWeb.Fireball)
            {
                BasicAuth(currentPortalWeb, currentUserType);
                WebDriverUtils.WaitUntilAjaxInactive();
            }
        }

        /// <summary>
        /// Get loginPage instance.
        /// </summary>
        /// <param name="currentPortalWeb">The portal to login</param>
        /// <returns>Instance of loginPage</returns>
        public static ILoginPage GetLoginPageInstance(PortalWeb currentPortalWeb)
        {
            if (loginPage != null && GetRespectiveInstanceForPortal(currentPortalWeb) == loginPage.GetType())
            {
                return loginPage;
            }

            return new LoginFactory().CreateLoginPage(currentPortalWeb);
        }

        /// <summary>
        /// Gets respective type of instance for each portal.
        /// </summary>
        /// <param name="currentPortalWeb">The current portal (enum)</param>
        /// <returns>The respective type of instance for the current portal.</returns>
        public static Type GetRespectiveInstanceForPortal(PortalWeb currentPortalWeb)
        {
            switch (currentPortalWeb)
            {
                case PortalWeb.Retailer:
                    {
                        return typeof(RetailerLoginPage);
                    }

                case PortalWeb.Distributor:
                    {
                        return typeof(OneAppLoginPage);
                    }

                case PortalWeb.Dtc:
                    {
                        return typeof(DTCLoginPage);
                    }

                case PortalWeb.DtcOneApp:
                    {
                        return typeof(DtcOneAppLoginPage);
                    }

                case PortalWeb.OasisUTA:
                    {
                        return typeof(OasisUTALoginPage);
                    }

                default:
                    {
                        throw new InvalidEnumArgumentException("Unrecognized \"portalWeb\" portal value.");
                    }
            }
        }

        private static void BasicAuth(PortalWeb currentPortalWeb, UserType currentUserType)
        {
            PortalPageTransporter pageTransporter = PortalPageTransporter.Instance;
            var userBro = EnvironmentManager.GetUser(currentPortalWeb.GetStringValue(), currentUserType.ToString());
            var portal = string.Format(EnvironmentManager.GetPortal(currentPortalWeb.GetStringValue()).Url, userBro.Name, userBro.Password);
            pageTransporter.DeleteAllCookies();
            pageTransporter.NavigateToURL(portal);
        }
    }
}
