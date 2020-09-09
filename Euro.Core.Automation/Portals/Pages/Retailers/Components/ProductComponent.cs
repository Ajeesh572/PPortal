// <copyright file="ProductComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Product component
    /// </summary>
    public class ProductComponent : BasePage, IRetailerComponent
    {
        [IDTFindBy(How = How.Id, Using = "PinNumber")]
        private IWebElement TxtPinNumber;

        [IDTFindBy(How = How.Id, Using = "btn-pinless-search")]
        private IWebElement BtnPinleesSearch;

        [IDTFindBy(How = How.CssSelector, Using = "#splashProducts a[href='/MoneyTransfer/NewTransaction']")]
        private IWebElement LnkMoneyTransfer;

        [IDTFindBy(How = How.CssSelector, Using = "#splashProducts a[href='/MoneyTransferOld/Index']")]
        private IWebElement LnkMoneyTransferV1;

        [IDTFindBy(How = How.CssSelector, Using = "#splashProducts a[href='/DBillPay/Index']")]
        private IWebElement LnkDomesticBillPay;

        [IDTFindBy(How = How.CssSelector, Using = "#splashProducts a[href='/MVNO/Index']")]
        private IWebElement LnkBrActivation;

        [IDTFindBy(How = How.CssSelector, Using = "#splashProducts a[href='/MoneyTransfer/PayAtStore']")]
        private IWebElement LnkPayAtStore;

        [IDTFindBy(How = How.CssSelector, Using = "#splashProducts a[href='/Imtu/MultiRealTimeRecharge']")]
        private IWebElement LnkInternationalMobileRecharges;

        [IDTFindBy(How = How.CssSelector, Using = "#splashProducts a[href='/Dgift/Index']")]
        private IWebElement LnkDomesticEgift;

        [IDTFindBy(How = How.CssSelector, Using = ".fa-spinner")]
        private IWebElement ImgWaitSpinner;

        [IDTFindBy(How = How.CssSelector, Using = "#splashProducts a[href='/Dmtu/RealTimeRecharge']")]
        private IWebElement LnkDomesticMobileRecharges;

        [IDTFindBy(How = How.CssSelector, Using = "#splashProducts a[href='/CallMe']")]
        private IWebElement LnkCallMe;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductComponent"/> class.
        /// </summary>
        public ProductComponent()
        {
            ImgWaitSpinner.WaitUntilElementIsInvisible();
        }

        /// <summary>
        /// Fills the Pin Number in TxtPinNumber TextBox.
        /// </summary>
        /// <param name="pinNumber">The Pin Number of Pinlees</param>
        public void FillSearchTxtPinNumber(string pinNumber)
        {
            CommonActions.SendKeys(TxtPinNumber, pinNumber);
        }

        /// <summary>
        /// Clicks on Pinless search button.
        /// </summary>
        public void ClickOnBtnPinlessSearch()
        {
            CommonActions.ClickElement(BtnPinleesSearch);
        }

        /// <summary>
        /// Click on an Item inside the component
        /// </summary>
        /// <param name="item">Menu item</param>
        public void ClickOnItem(string item)
        {
            GetWebElementFromDictionaryProductsTab(item).WaitUntilElementIsDisplayed();
            GetWebElementFromDictionaryProductsTab(item).ClickElementByJavaScript();
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
                { "Money Transfer", LnkMoneyTransfer },
                { "Pay At Store", LnkPayAtStore },
                { "Domestic Bill Pay", LnkDomesticBillPay },
                { "BR Mobile Activation", LnkBrActivation },
                { "International Mobile Recharges", LnkInternationalMobileRecharges },
                { "Domestic E-Gift", LnkDomesticEgift },
                { "Domestic Mobile Recharges", LnkDomesticMobileRecharges },
                { "Call Me", LnkCallMe },
                { "Money Transfer V1", LnkMoneyTransferV1 },
            };
            return webElementDictionary[webElementName];
        }
    }
}
