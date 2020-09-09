// <copyright file="HomePageFactory.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Common.HomePages
{
    using System.ComponentModel;
    using Euro.Core.Automation.Portals.Pages.Bro.HomePages;
    using Euro.Core.Automation.Portals.Pages.Distributor;
    using Euro.Core.Automation.Portals.Pages.Oasis.HomePages;
    using Euro.Core.Automation.Portals.Pages.Retailers.HomePages;

    /// <summary>
    /// This class handles the HomePage build.
    /// </summary>
    public class HomePageFactory
    {
        /// <summary>
        /// Creates a new Home page according to the portal web.
        /// </summary>
        /// <param name="currentPortalWeb">Portal Web type.</param>
        /// <returns>The new Home page.</returns>
        public IHomePage CreateHomePage(PortalWeb portalWeb)
        {
            IHomePage homePage = null;
            switch (portalWeb)
            {
                case PortalWeb.Retailer:
                    {
                        homePage = new RetailerHomePage();
                        break;
                    }

                case PortalWeb.Distributor:
                    {
                        homePage = new DistributorHomePage();
                        break;
                    }

                case PortalWeb.Bro:
                    {
                        homePage = new BroHomePage();
                        break;
                    }

                case PortalWeb.Dtc:
                    {
                        //homePage = new DTCHomePage();
                        break;
                    }

                case PortalWeb.OasisUTA:
                    {
                        homePage = new OasisUTAHomePage();
                        break;
                    }

                default:
                    {
                        throw new InvalidEnumArgumentException("Unrecognized \"portalWeb\" portal value.");
                    }
            }

            return homePage;
        }
    }
}
