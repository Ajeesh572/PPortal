// <copyright file="AppConfigUtils.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities
{
    using System.Configuration;

    /// <summary>
    /// This class contains methods for AppConfig file.
    /// </summary>
    public class AppConfigUtils
    {
        /// <summary>
        /// This method helps to change the value of the key in App config file.
        /// </summary>
        /// <param name="key">key that will be updated.</param>
        /// <param name="newValue">the new value of the key.</param>
        public static void ChangeValueOfAppConfigKey(string key, string newValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = newValue;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
