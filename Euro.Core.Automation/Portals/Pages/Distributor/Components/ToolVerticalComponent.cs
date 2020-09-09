// <copyright file="ToolVerticalComponent.cs" company="Eurofins">
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
    /// Class to handle the Tool component from left menu
    /// </summary>
    public class ToolVerticalComponent : BasePage, IDistributorComponent
    {
        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'REGISTER RETAILER'] | //span[text() = 'REGISTRAR MINORISTA']")]
        [IDTFieldName("Register Retailer")]
        private IWebElement lnkRegisterRetailer;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'MANAGE RETAILERS'] | //span[text() = 'ADMINISTRAR LOS MINORISTAS']")]
        [IDTFieldName("Manage Retailer")]
        private IWebElement lnkManageRetailer;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'MANAGE SALESPEOPLE'] | //span[text() = 'ADMINISTRAR EL PERSONAL DE VENTAS']")]
        [IDTFieldName("Manage Retailer")]
        private IWebElement lnkSalesPeople;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'PRODUCT COMMISSIONS'] | //span[text() = 'COMISIONES DEL PRODUCTO']")]
        [IDTFieldName("Product Commissions")]
        private IWebElement lnkProductCommissions;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'UPDATE PERSONAL INFO'] | //span[text() = 'ACTUALIZAR INFORMACIÓN PERSONAL']")]
        [IDTFieldName("Update Personal Info")]
        private IWebElement lnkUpdatePersonalInfo;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'ORDER MARKETING MATERIALS'] | //span[text() = 'Pedir Materiales de Mercadeo']")]
        [IDTFieldName("Order Marketing Materials")]
        private IWebElement lnkOrderMarketingMaterials;

        [IDTFindBy(How = How.XPath, Using = "//span[text() = 'PURCHASE POINTS'] | //span[text() = 'COMPRAR PUNTOS']")]
        [IDTFieldName("Purchase Points")]
        private IWebElement lnkPurchasePoints;

        public void ClickOnItem(string item)
        {
            IsElementDisplayed(item);
            Click(item);
        }
    }
}
