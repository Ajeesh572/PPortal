// <copyright file="GlobalHooks.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.OneApp.Test
{
    using Euro.Core.Automation.Portals.Utils;
    using Euro.Core.Automation.Utilities.Logger;
    using Euro.Core.Automation.WebDriver;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Hooks for global execution.
    /// </summary>
    [Binding]
    public class GlobalHooks
    {

        /// <summary>
        /// Closes web driver.
        /// </summary>
        [AfterTestRun(Order = 1)]
        public static void CloseWebDriver()
        {
            WebDriverManager.Instance.QuitDriver();
        }

        [AfterTestRun(Order = 0)]
        public static void CreateEnvironmentFile()
        {
            try
            {
                string project = TestContext.Parameters.Get("ipRestriction");
                project = project==("mt") ? "MoneyTransfer" : "project";
                ReadingAndWritingFiles.CreateEnvironmentFile(project.ToUpper());
            }
            catch
            {
                Logging.Debug($"Not found path to create environment file.");
            }
        }
    }
}