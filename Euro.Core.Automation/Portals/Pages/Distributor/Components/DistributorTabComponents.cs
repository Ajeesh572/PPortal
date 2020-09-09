// <copyright file="DistributorTabComponents.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Distributor.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Distributor Tab component
    /// </summary>
    public class DistributorTabComponents : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href='#reports']")]
        [IDTFieldName("Reports")]
        private IWebElement tabReports;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='#br-university']")]
        [IDTFieldName("BR University")]
        private IWebElement tabBrUniversity;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='#tools']")]
        [IDTFieldName("Tools")]
        private IWebElement tabTools;

        [IDTFindBy(How = How.CssSelector, Using = "[class='blockUI blockMsg blockElement'] i[class*= 'fa-spinner']")]
        private IWebElement blockMsg;

        [IDTFindBy(How = How.CssSelector, Using = "[class='blockUI blockOverlay']")]
        private IWebElement blockUiOverlay;

        /// <summary>
        /// Clicks over an Item inside the component
        /// </summary>
        /// <param name="tabOption">Name of Tab</param>
        public void ClickOnTapOption(string tabOption)
        {
            blockMsg.WaitUntilElementIsInvisible();
            blockUiOverlay.WaitUntilElementIsInvisible();
            Click(tabOption);
        }
    }
}
