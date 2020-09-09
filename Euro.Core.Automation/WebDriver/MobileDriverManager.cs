// <copyright file="MobileDriverManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

using Euro.Core.Automation.Utilities.Logger;
using System.Windows.Forms;

namespace Euro.Core.Automation.WebDriver
{
    /// <summary>
    /// Class to manage the mobile driver.
    /// </summary>
    public class MobileDriverManager : DriverManager
    {
        private static MobileDriverManager instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileDriverManager"/> class.
        /// </summary>
        private MobileDriverManager()
        {
            this.InitWebDriver();
        }

        /// <summary>
        /// Gets MobileDriverManager as singleton.
        /// </summary>
        public static MobileDriverManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MobileDriverManager();
                }

                return instance;
            }
        }

        /// <summary>
        /// Initialize the web driver.
        /// </summary>
        public new void InitWebDriver()
        {
            base.InitWebDriver();
        }
    }
}
