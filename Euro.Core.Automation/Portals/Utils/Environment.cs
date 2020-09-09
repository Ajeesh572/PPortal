// <copyright file="Environment.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Utils
{
    using System;
    using System.Configuration;
    using Castle.Core.Internal;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Euro.Core.Automation.Utilities.Logger;
    using NUnit.Framework;

    /// <summary>
    /// This class is in charge to get the environment values from external files.
    /// </summary>
    public class Environment
    {
        private static Environment _instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="Environment"/> class.
        /// </summary>
        private Environment()
        {
            ExplicitWait = TimeSpan.FromMilliseconds(int.Parse(ConfigurationManager.AppSettings["ExplicitWait"]));
        }

        /// <summary>
        /// Gets the Retailer portal web url.
        /// </summary>
        public string RetailerUrl { get; private set; }

        /// <summary>
        /// Gets the Distributor portal web url.
        /// </summary>
        public string DistributorUrl { get; private set; }

        /// <summary>
        /// Gets the DTC portal web url.
        /// </summary>
        public string DTCUrl { get; private set; }

        /// <summary>
        /// Gets the DTCOneApp portal web url.
        /// </summary>
        public string DTCOneAppUrl { get; private set; }

        /// <summary>
        /// Gets the OasisUTA portal web url.
        /// </summary>
        public string OasisUTAUrl { get; private set; }

        /// <summary>
        /// Gets a new instance of class if it doesn't exist yet.
        /// </summary>
        public static Environment Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Environment();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Gets the Retailer Login portal web url.
        /// </summary>
        /// <returns>Retail portal Login URL</returns>
        public string RetailerLoginUrl()
        {
            Logging.Debug("Trying to get Retailer portal URL'");
            RetailerUrl = EnvironmentManager.GetPortal("Retailer").Url;
            var loginUrl = RetailerUrl + "Account/Login";
            Logging.Debug($"Retailer portal LogIn URL is '{loginUrl}'");
            return loginUrl;
        }

        /// <summary>
        /// Gets the Retailer portal web url.
        /// </summary>
        /// <returns>Retail portal URL</returns>
        public string RetailerMainUrl()
        {
            RetailerUrl = EnvironmentManager.GetPortal("Retailer").Url;
            return RetailerUrl;
        }

        /// <summary>
        /// Gets the Distributor Login portal web url.
        /// </summary>
        /// <returns>Distributor portal URL</returns>
        public string DistributorLoginUrl()
        {
            DistributorUrl = EnvironmentManager.GetPortal("Distributor").Url;
            return DistributorUrl + "Account/Login";
        }

        /// <summary>
        /// Gets the Distributor Login portal web url.
        /// </summary>
        /// <returns>Distributor portal URL</returns>
        public string DistributorMainUrl()
        {
            DistributorUrl = EnvironmentManager.GetPortal("Distributor").Url;
            return DistributorUrl;
        }

        /// <summary>
        /// Gets the DTC Login portal web url.
        /// </summary>
        /// <returns>DTC portal URL</returns>
        public string DTCLoginUrl()
        {
            DTCUrl = EnvironmentManager.GetPortal("Dtc").Url;
            return DTCUrl + GetCultureInfo() + "/login.html";
        }

        /// <summary>
        /// Gets the DTC portal web url.
        /// </summary>
        /// <returns>DTC portal URL</returns>
        public string DTCMainUrl()
        {
            DTCUrl = EnvironmentManager.GetPortal("Dtc").Url;
            return DTCUrl + GetCultureInfo() + "/index.html";
        }

        /// <summary>
        /// Gets the Distributor Login portal web url.
        /// </summary>
        /// <returns>DTCOneApp portal URL</returns>
        public string DTCOneAppLoginUrl()
        {
            DTCOneAppUrl = EnvironmentManager.GetPortal("DtcOneApp").Url;
            return DTCOneAppUrl + "login?ReturnUrl=%2Fen-us%2Fmy-account&Recaptcha=0";
        }

        /// <summary>
        /// Gets the DTC OneApp portal web url.
        /// </summary>
        /// <returns>DTC OneApp portal URL</returns>
        public string DTCOneAppMainUrl()
        {
            DTCOneAppUrl = EnvironmentManager.GetPortal("DtcOneApp").Url;
            return DTCOneAppUrl + GetCultureInfo();
        }

        /// <summary>
        /// Gets the Bro portal web url.
        /// </summary>
        /// <returns>Bro portal web urlL</returns>
        public string BroAppMainUrl()
        {
            var userBro = EnvironmentManager.GetUser("Bro", "Bro");
            return string.Format(EnvironmentManager.GetPortal("Bro").Url, userBro.Name, userBro.Password);
        }

        /// <summary>
        /// Gets OasisUTA Login portal web URL.
        /// </summary>
        /// <returns>OasisUTA portal Login URL</returns>
        public string OasisUTALoginUrl()
        {
            return EnvironmentManager.GetPortal("OasisUTA").Url + "/login/index.cfm";
        }

        /// <summary>
        /// Gets OasisUTA portal web URL.
        /// </summary>
        /// <returns>OasisUTA portal URL</returns>
        public string OasisUTAMainUrl()
        {
            return EnvironmentManager.GetPortal("OasisUTA").Url + "/index.cfm";
        }

        /// <summary>
        /// Gets or sets the Expicit Wait for portal Web.
        /// </summary>
        public TimeSpan ExplicitWait { get; set; }

        /// <summary>
        /// Gets culture of the site
        /// </summary>
        /// <returns>Culture of the site</returns>
        private string GetCultureInfo()
        {
            var language = TestContext.Parameters.Get("Language");

            if (language.IsNullOrEmpty())
            {
                language = ConfigurationManager.AppSettings["Language"];
            }

            var culture = "spanish".Equals(language, StringComparison.InvariantCultureIgnoreCase) ? "es-us" : "en-us";
            return culture;
        }
    }
}
