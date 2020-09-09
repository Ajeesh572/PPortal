// <copyright file="BRUniversityComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Component;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the BRUniversity component
    /// </summary>
    public class BRUniversityComponent : BaseComponent, IRetailerComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "#BR_University a[href='/BrUniversity/PinlessPlans']")]
        private IWebElement lnkPinlessPlan;

        [IDTFindBy(How = How.CssSelector, Using = "#BR_University a[href='/BrUniversity/MobileRecharges']")]
        private IWebElement lnkMobileRecharges;

        [IDTFindBy(How = How.CssSelector, Using = "#BR_University a[href='/BrUniversity/CallMe']")]
        private IWebElement lnkCallMe;

        [IDTFindBy(How = How.CssSelector, Using = "#BR_University a[href='/BrUniversity/DomesticEGift']")]
        private IWebElement lnkDomesticEGift;

        [IDTFindBy(How = How.CssSelector, Using = "#BR_University a[href='/BrUniversity/MoneyTransfer']")]
        private IWebElement lnkMoneyTransfer;

        [IDTFindBy(How = How.CssSelector, Using = "#BR_University a[href='/BrUniversity/RetailerPortal3']")]
        private IWebElement lnkRetailerPortal3;

        [IDTFindBy(How = How.CssSelector, Using = ".fa-spinner")]
        private IWebElement imgWaitSpinner;

        [IDTFindBy(How = How.CssSelector, Using = "#BR_University a[href='/BrUniversity/InternationalEGift']")]
        private IWebElement lnkInternationslEGift;

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
            GetWebElementFromDictionaryProductsTab(item).WaitUntilElementIsDisplayed();
            CommonActions.ClickElement(GetWebElementFromDictionaryProductsTab(item));
        }

        /// <summary>
        /// Gets a webElement from a dictionary.
        /// </summary>
        /// <param name="webElementName">WebElement name in the dictionary.</param>
        /// <returns>WebElement</returns>
        public IWebElement GetWebElementFromDictionaryProductsTab(string webElementName)
        {
            Dictionary<string, IWebElement> webElementDictionary = new Dictionary<string, IWebElement>
            {
                { "Pinless Plans", lnkPinlessPlan },
                { "Mobile Recharges", lnkMobileRecharges },
                { "Call Me", lnkCallMe },
                { "Domestic E-Gift", lnkDomesticEGift },
                { "Money Transfer", lnkMoneyTransfer },
                { "Retailer Portal 3.0", lnkRetailerPortal3 },
                { "International E-Gift", lnkInternationslEGift}
            };
            return webElementDictionary[webElementName];
        }
    }
}
