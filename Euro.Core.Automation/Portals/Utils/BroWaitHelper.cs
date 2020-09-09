// <copyright file="BroWaitHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Utils
{
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.Logger;
    using OpenQA.Selenium;

    /// <summary>
    /// This class handles all common actions in portal Bro.
    /// </summary>
    public class BroWaitHelper
    {
        /// <summary>
        /// Waits until any bro portal completes to load(alert element displays/disappears and loading icon disappears).
        /// </summary>
        public static void LoadingBRO()
        {
            try
            {
                CommonActions.WaitUntilElementIsInvisible(By.XPath(".//*[@id='loading' and contains (@style, 'opacity')]"));
                CommonActions.WaitUntilElementIsInvisible(By.CssSelector("[class='ajax-loading'] span"));
            }
            catch (WebDriverTimeoutException error)
            {
                Logging.Debug($"Error while waiting to Load BRO page: {error}");
            }
        }
    }
}
