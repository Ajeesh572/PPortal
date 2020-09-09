// <copyright file="LoginFactory.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Common.LoginPages
{
    using System.ComponentModel;
    using Euro.Core.Automation.Portals.Pages.Dtc.LoginPages;
    using Euro.Core.Automation.Portals.Pages.DtcOneApp.LoginPages;
    using Euro.Core.Automation.Portals.Pages.Oasis;

    /// <summary>
    /// This class handles the LoginPage build.
    /// </summary>
    public class LoginFactory
    {
        /// <summary>
        /// Creates a new Login page according to the portal web.
        /// </summary>
        /// <param name="portalWeb">Portal Web type.</param>
        /// <returns>The new Login page.</returns>
        public ILoginPage CreateLoginPage(PortalWeb portalWeb)
        {
            ILoginPage loginPage = null;
            switch (portalWeb)
            {
                case PortalWeb.Retailer:
                    {
                        loginPage = new OneAppLoginPage();
                        break;
                    }

                case PortalWeb.Distributor:
                    {
                        loginPage = new OneAppLoginPage();
                        break;
                    }

                case PortalWeb.Bro:
                    {
                        break;
                    }

                case PortalWeb.Dtc:
                    {
                        loginPage = new DTCLoginPage();
                        break;
                    }

                case PortalWeb.DtcOneApp:
                    {
                        loginPage = new DtcOneAppLoginPage();
                        break;
                    }

                case PortalWeb.OasisUTA:
                    {
                        loginPage = new OasisUTALoginPage();
                        break;
                    }

                default:
                    {
                        throw new InvalidEnumArgumentException("Unrecognized \"portalWeb\" portal value.");
                    }
            }

            return loginPage;
        }
    }
}
