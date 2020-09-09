// <copyright file="WebDriverManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.WebDriver
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Windows.Forms;
    using OpenQA.Selenium;
    using Utilities.JsonManager;
    using Utilities.Logger;

    /// <summary>
    /// Class represented web driver manager
    /// </summary>
    public class WebDriverManager : DriverManager
    {
        private static WebDriverManager instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverManager"/> class.
        /// Constructor of WebDriverManager
        /// </summary>
        private WebDriverManager()
        {
            this.InitWebDriver();
        }

        /// <summary>
        /// Set WebDriver
        /// </summary>
        /// <param name="webDriver">New webDriver</param>
        public override void SetWebDriver(IWebDriver webDriver)
        {
            base.SetWebDriver(webDriver);
            Driver.Manage().Window.Size = GetResolution();
        }

        /// <summary>
        /// Gets get WebDriverManager as Singleton
        /// </summary>
        public static WebDriverManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebDriverManager();
                }

                return instance;
            }
        }

        /// <summary>
        /// Method to initialize Web Driver
        /// </summary>
        public new void InitWebDriver()
        {
            Logging.Debug($"Initializing WebDriver base...");
            var screen = Screen.PrimaryScreen.Bounds;
            Logging.Debug($"Screen size before selecting browser:{screen.Width}, {screen.Height}");
            base.InitWebDriver();
            //Driver.Manage().Window.Size = GetResolution();
            //var screenAfterSelectBrowser = Screen.PrimaryScreen.Bounds;
            //Logging.Debug($"Screen size after selecting browser:{screenAfterSelectBrowser.Width}, {screenAfterSelectBrowser.Height}");
            //Logging.Debug($"Before Maximize windows, page's size: {Driver.Manage().Window.Size}");
            //Logging.Debug($"After Maximize windows, page's size: {Driver.Manage().Window.Size}");
        }

        /// <summary>
        /// Gets size of the resolution for the browser.
        /// </summary>
        /// <returns>The size of the resolution for the browser.</returns>
        public Size GetResolution()
        {
            Logging.Debug($"Get size of the resolution for the browser.");
            string with = EnvironmentManager.GetWidthOfBrowser();
            string height = EnvironmentManager.GetHeightOfBrowser();
            int withValue = string.IsNullOrEmpty(with) ? 1920 : Convert.ToInt32(with);
            int heightValue = string.IsNullOrEmpty(height) ? 1080 : Convert.ToInt32(height);
            Logging.Debug($"Screen size of the browser obtained - Width: '{withValue}', Height: '{heightValue}'");
            return new Size(withValue, heightValue);
        }

        /// <summary>
        /// Get the code of the current window where the webDriver is running
        /// </summary>
        /// <returns>The string current window.</returns>
        public string GetCurrentWindow()
        {
            return Driver.CurrentWindowHandle;
        }

        /// <summary>
        /// Get the codes of all windows that were open using the webDriver
        /// </summary>
        /// <returns>String Get Current Windows</returns>
        public ReadOnlyCollection<string> GetCurrentWindows()
        {
            return Driver.WindowHandles;
        }

        /// <summary>
        /// Method to restart driver.
        /// </summary>
        public void RestartWebDriver()
        {
            try
            {
                Logging.Debug($"Restarting the current driver");
                QuitDriver();
            }
            finally
            {
                Logging.Debug($"Initialize new driver");
                InitWebDriver();
            }
        }
    }
}
