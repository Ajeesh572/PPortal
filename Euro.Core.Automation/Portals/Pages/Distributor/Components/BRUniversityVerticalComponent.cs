// <copyright file="BRUniversityVerticalComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Distributor.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the BR University component from left menu
    /// </summary>
    public class BRUniversityVerticalComponent : BasePage, IDistributorComponent
    {
        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'BR Mobile']")]
        [IDTFieldName("BR Mobile")]
        private IWebElement lnkBRMobile;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Pinless Plans'] | //span[text() = 'Planes de Pinless']")]
        [IDTFieldName("Pinnless Plans")]
        private IWebElement lnkPinlessPlans;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Tigo Plans'] | //span[text() = 'Planes de Tigo']")]
        [IDTFieldName("Tigo Plans")]
        private IWebElement lnkTigoPlans;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Mobile Recharges'] | //span[text() = 'Recargas Móviles']")]
        [IDTFieldName("Mobile Recharges")]
        private IWebElement lnkMobileRecharges;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'CALL ME']")]
        [IDTFieldName("Call Me")]
        private IWebElement lnkCallMe;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Domestic E-Gift'] | //span[text() = 'E-Gift Doméstico']")]
        [IDTFieldName("Domestic E-Gift")]
        private IWebElement lnkDomesticEGift;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'International E-Gift'] | //span[text() = 'E-Gift Internacional']")]
        [IDTFieldName("International E-Gift")]
        private IWebElement lnkInternationalEGift;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Bill Pay'] | //span[text() = 'Pago de Facturas']")]
        [IDTFieldName("Bill Pay")]
        private IWebElement lnkBillPay;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Money Transfer'] | //span[text() = 'Envío De Dinero']")]
        [IDTFieldName("Money Transfer")]
        private IWebElement lnkMoneyTransfer;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'BR Rewards']")]
        [IDTFieldName("BR Rewards")]
        private IWebElement lnkBRRewards;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'BR Club']")]
        [IDTFieldName("BR Club")]
        private IWebElement lnkBRClub;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Portal Security Features'] | //span[text() = 'Funciones de Seguridad']")]
        [IDTFieldName("Portal Security Features")]
        private IWebElement lnkPotalFeatures;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Brand Manual'] | //span[text() = 'Manual de Marca']")]
        [IDTFieldName("Brand Manual")]
        private IWebElement lnkBrandManual;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Distributor Portal 3.0']")]
        [IDTFieldName("Distributor Portal 3.0")]
        private IWebElement lnkDistributorPortal3;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Retailer Portal 3.0']")]
        [IDTFieldName("Retailer Portal 3.0")]
        private IWebElement lnkRetailerPortal3;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Boss Revolution App']")]
        [IDTFieldName("Boss Revolution App")]
        private IWebElement lnkBossRevolutionApp;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Compliance'] | //span[text() = 'Cumplimiento']")]
        [IDTFieldName("Compliance")]
        private IWebElement lnkCompliance;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'NRS POS']")]
        [IDTFieldName("NRS POS")]
        private IWebElement lnkNRSPOS;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'Kiosk']")]
        [IDTFieldName("Kiosk")]
        private IWebElement lnkKiosk;

        public void ClickOnItem(string item)
        {
            IsElementDisplayed(item);
            Click(item);
        }
    }
}
