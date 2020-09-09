// <copyright file="BRUniversityComponent.cs" company="Eurofins">
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
    /// Class to handle the BRUniversity component
    /// </summary>
    public class BRUniversityComponent : BasePage, IDistributorComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/BRMobile']")]
        [IDTFieldName("BR Mobile")]
        private IWebElement lnkBRMobile;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/PinlessPlans']")]
        [IDTFieldName("Pinless Plans")]
        private IWebElement lnkPinlessPlan;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/TigoPlans']")]
        [IDTFieldName("Tigo Plans")]
        private IWebElement lnkTigoPlans;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/MobileRecharges']")]
        [IDTFieldName("Mobile Recharges")]
        private IWebElement lnkMobileRecharges;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/CallMe']")]
        [IDTFieldName("Call Me")]
        private IWebElement lnkCallMe;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/DomesticEGift']")]
        [IDTFieldName("Domestic E-Gift")]
        private IWebElement lnkDomesticEGift;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/InternationalEGift']")]
        [IDTFieldName("International E-Gift")]
        private IWebElement lnkInternationslEGift;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/BillPay']")]
        [IDTFieldName("Bill Pay")]
        private IWebElement lnkBillPay;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/MoneyTransfer']")]
        [IDTFieldName("Money Transfer")]
        private IWebElement lnkMoneyTransfer;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/BRRewards']")]
        [IDTFieldName("BR Rewards")]
        private IWebElement lnkBRRewards;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/BRClub']")]
        [IDTFieldName("BR Club")]
        private IWebElement lnkBRClub;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/PortalSecurityFeatures']")]
        [IDTFieldName("Portal Security Features")]
        private IWebElement lnkPortalSecurityFeatures;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/BrandingGuidelines']")]
        [IDTFieldName("Brand Manual")]
        private IWebElement lnkBrandingGuidelines;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/DistributorPortal3']")]
        [IDTFieldName("Distributor Portal 3.0")]
        private IWebElement lnkDistributorPortal3;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/RetailerPortal3']")]
        [IDTFieldName("Retailer Portal 3.0")]
        private IWebElement lnkRetailerPortal3;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/BRApp']")]
        [IDTFieldName("Boss Revolution App")]
        private IWebElement lnkBRApp;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/Compliance']")]
        [IDTFieldName("Compliance")]
        private IWebElement lnkCompliance;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/POS']")]
        [IDTFieldName("NRS POS")]
        private IWebElement lnkPOS;

        [IDTFindBy(How = How.CssSelector, Using = "#br-university a[href='/BrUniversity/Kiosk']")]
        [IDTFieldName("Kiosk")]
        private IWebElement lnkKiosk;

        [IDTFindBy(How = How.CssSelector, Using = ".fa-spinner")]
        private IWebElement imgWaitSpinner;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRUniversityComponent"/> class.
        /// </summary>
        public BRUniversityComponent()
        {
            imgWaitSpinner.WaitUntilElementIsInvisible();
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
