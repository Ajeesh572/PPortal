// <copyright file="IOs.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.WebDriver.WrapperFactory
{
    using System.Configuration;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Manages the mobile ios instance.
    /// </summary>
    public class IOs : MobileDriver
    {
        private static string Platform = "platform";
        private static string Udid = "udid";
        private static string BundleId = "bundleId";
        private static string AutomationName = "automationName";

        /// <inheritdoc/>
        public override DesiredCapabilities SetCapability()
        {
            this.Capabilities.SetCapability(Platform, ConfigurationManager.AppSettings["Platform"].ToString());
            this.Capabilities.SetCapability(Udid, ConfigurationManager.AppSettings["Udid"].ToString());
            this.Capabilities.SetCapability(BundleId, ConfigurationManager.AppSettings["BundleId"].ToString());
            this.Capabilities.SetCapability(AutomationName, ConfigurationManager.AppSettings["AutomationName"].ToString());            
            return this.Capabilities;
        }
    }
}
