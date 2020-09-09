// <copyright file="ToolComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Distributor.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Tool component
    /// </summary>
    public class ToolComponent : BasePage, IDistributorComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href='/Retailers/Register']")]
        [IDTFieldName("Register Retailer")]
        private IWebElement lnkRegisterRetailers;

        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href='/Retailers/Manage']")]
        [IDTFieldName("Manage Retailers")]
        private IWebElement lnkManageRetailers;

        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href='/ManageProfiles/RetailerProfiles']")]
        [IDTFieldName("Manage Profiles")]
        private IWebElement lnkManageProfiles;

        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href='/SalesPeople/Index']")]
        [IDTFieldName("Manage Salespeople")]
        private IWebElement lnkManageSalepeople;

        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href='/Distributor/ProductCommissions']")]
        [IDTFieldName("Product Commissions")]
        private IWebElement lnkProductCommissions;

        [IDTFindBy(How = How.CssSelector, Using = "#tools a[href='/Account/GeneralInfo']")]
        [IDTFieldName("Update Personal Info")]
        private IWebElement lnkUpdatePersonalInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolComponent"/> class.
        /// </summary>
        public ToolComponent()
        {
            WaitUntilPageLoaded();
        }

        /// <summary>
        /// Click on an Item inside the component
        /// </summary>
        /// <param name="item">Menu item</param>
        public void ClickOnItem(string item)
        {
            IsElementDisplayed(item);
            Click(item);
        }
    }
}
