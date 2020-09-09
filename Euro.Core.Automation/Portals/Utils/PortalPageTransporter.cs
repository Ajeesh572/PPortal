// <copyright file="PageTransporter.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Utils
{
    using System.ComponentModel;
    using Euro.Core.Automation.Portals.Pages.Common;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;

    /// <summary>
    /// This class handles the navigation of pages.
    /// </summary>
    public class PortalPageTransporter
    {
        private Environment Environment;
        private static PortalPageTransporter _instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortalPageTransporter"/> class.
        /// </summary>
        private PortalPageTransporter()
        {
            Environment = Environment.Instance;
        }

        /// <summary>
        /// Gets a new instance of class if it doesn't exist yet.
        /// </summary>
        public static PortalPageTransporter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PortalPageTransporter();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Navigates to a given url
        /// </summary>
        /// <param name="url">The url for to navigate in Portal Web</param>
        public void NavigateToURL(string url)
        {
            WebDriverManager.Instance.GetWebDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Method to delete all cookies
        /// </summary>
        public void DeleteAllCookies()
        {
            WebDriverManager.Instance.GetWebDriver.Manage().Cookies.DeleteAllCookies(); 
            WebDriverManager.Instance.GetWebDriver.Navigate().Refresh();     
        }

        /// <summary>
        /// Navigates to main page.
        /// </summary>
        /// <param name="portalWeb">Portal web for to do signin</param>
        public void NavigateMainPortalWeb(PortalWeb portalWeb)
        {
            switch (portalWeb)
            {
                case PortalWeb.Retailer:
                    {
                        NavigateToURL(Environment.RetailerMainUrl());
                        break;
                    }

                case PortalWeb.Distributor:
                    {
                        NavigateToURL(Environment.DistributorMainUrl());
                        break;
                    }

                case PortalWeb.Dtc:
                    {
                        NavigateToURL(Environment.DTCMainUrl());
                        break;
                    }

                case PortalWeb.DtcOneApp:
                    {
                        NavigateToURL(Environment.DTCOneAppMainUrl());
                        break;
                    }

                case PortalWeb.OasisUTA:
                    {
                        NavigateToURL(Environment.OasisUTAMainUrl());
                        break;
                    }

                default:
                    {
                        throw new InvalidEnumArgumentException("Unrecognized \"portalWeb\" portal value.");
                    }
            }
        }

        /// <summary>
        /// Navigates to login page.
        /// </summary>
        /// <param name="portalWeb">Portal web for to do signin</param>
        public void NavigateToLoginPortalWeb(PortalWeb portalWeb)
        {
            switch (portalWeb)
            {
                case PortalWeb.Retailer:
                    {
                        NavigateToURL(Environment.RetailerLoginUrl());
                        DeleteAllCookies();
                        break;
                    }

                case PortalWeb.Distributor:
                    {
                        NavigateToURL(Environment.DistributorLoginUrl());
                        DeleteAllCookies();
                        break;
                    }

                case PortalWeb.Dtc:
                    {
                        NavigateToURL(Environment.DTCLoginUrl());
                        break;
                    }

                case PortalWeb.DtcOneApp:
                    {
                        DeleteAllCookies();
                        NavigateToURL(Environment.DTCOneAppLoginUrl());
                        break;
                    }

                case PortalWeb.OasisUTA:
                    {
                        NavigateToURL(Environment.OasisUTALoginUrl());
                        break;
                    }

                default:
                    {
                        throw new InvalidEnumArgumentException("Unrecognized \"portalWeb\" portal value.");
                    }
            }
        }

        /// <summary>
        /// Gets the instance created for <see cref="Environment"/> class.
        /// </summary>
        /// <returns>An instance of <see cref="Environment"/> class</returns>
        public Environment GetEnviroment()
        {
            return Environment;
        }
    }
}
