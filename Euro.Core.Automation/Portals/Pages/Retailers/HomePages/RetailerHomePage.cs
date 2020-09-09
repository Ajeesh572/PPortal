// <copyright file="RetailerHomePage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.HomePages
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Common.HomePages;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class handles the Retailer Home Page.
    /// </summary>
    public class RetailerHomePage : BasePage, IHomePage
    {
        [IDTFindBy(How = How.Id, Using = "btn-pinless-search")]
        private IWebElement btnPinlessSearch;

        [IDTFindBy(How = How.Id, Using = "product-link")]
        private IWebElement lnkProduct;

        /// <summary>
        /// Verifys if to be in Home portal Web.
        /// </summary>
        /// <returns>True if to be in Home portal Web.</returns>
        public bool IsHomePage()
        {
            return lnkProduct.IsElementDisplayed();
        }
    }
}
