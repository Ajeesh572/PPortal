// <copyright file="Android.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.WebDriver.WrapperFactory
{
    using System.Configuration;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Manages the android instance.
    /// </summary>
    public class Android : MobileDriver
    {
        private static string Device = "device";
        private static string AppPackage = "appPackage";
        private static string AppActivity = "appActivity";

        /// <inheritdoc/>
        public override DesiredCapabilities SetCapability()
        {
            this.Capabilities.SetCapability(Device, ConfigurationManager.AppSettings["Browser"].ToString());
            this.Capabilities.SetCapability(AppPackage, ConfigurationManager.AppSettings["AppPackage"].ToString());
            this.Capabilities.SetCapability(AppActivity, ConfigurationManager.AppSettings["AppActivity"].ToString());
            return this.Capabilities;
        }
    }
}
