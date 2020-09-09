// <copyright file="LeftMenuComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Bro.Components
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Utils;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class is to handle the left menu.
    /// </summary>
    public class LeftMenuComponent : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "[class='button-menu-mobile show-sidebar']")]
        private IWebElement MnsMenuDisplay;

        [IDTFindBy(How = How.CssSelector, Using = "a[class*='item'][href*='/Home/Index']")]
        private IWebElement LnkDashboard;

        [IDTFindBy(How = How.CssSelector, Using = "a[class*='item'][href*='/Distributor/Index']")]
        private IWebElement LnkDistributor;

        [IDTFindBy(How = How.CssSelector, Using = "a[class*='item'][href*='/RetailerManagement/Index']")]
        private IWebElement LnkRetailerManagement;

        [IDTFindBy(How = How.CssSelector, Using = "a[class*='item'][href*='/CustomerManagement/Index']")]
        private IWebElement LnkCustomerManagement;

        [IDTFindBy(How = How.CssSelector, Using = "a[class*='item'][href*='/ProfileManagement/Index']")]
        private IWebElement LnkProfileManagement;

        [IDTFindBy(How = How.CssSelector, Using = "a[class*='item'][href*='/ProductManagement/Products']")]
        private IWebElement LnkProductManagement;

        [IDTFindBy(How = How.CssSelector, Using = "a[class*='item'][href*='/MoneyTransfer/Splash']")]
        private IWebElement LnkMoneyTransfer;

        [IDTFindBy(How = How.CssSelector, Using = "a[class*='item'][href*='/Changeset/Index']")]
        private IWebElement LnkCms;

        [IDTFindBy(How = How.CssSelector, Using = "li[class*='first']>a[class*='item']")]
        private IWebElement LnkConfiguration;

        [IDTFindBy(How = How.CssSelector, Using = "a[class*='item'][href*='/Report/Index']")]
        private IWebElement LnkReports;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/GeneralInfo']")]
        private IWebElement MnsDistributorGeneralInfo;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/CreditWallet'")]
        private IWebElement MnsCreditWallet;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/CashWallet']")]
        private IWebElement MnsCashWallet;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/AccessControl']")]
        private IWebElement MnsAccessControl;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/ManageCertificate']")]
        private IWebElement MnsManageDistCertificate;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/ManageProducts']")]
        private IWebElement MnsDistributorManageProducts;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/Fees']")]
        private IWebElement MnsDistributorFees;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/Commissions']")]
        private IWebElement MnsDistributorCommissions;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/Adjustment']")]
        private IWebElement MnsDistributorAdjustment;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Distributor/DropIn']")]
        private IWebElement MnsDistributorOpenPortal;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/GeneralInfo']")]
        private IWebElement MnsRetailerGeneralInfo;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/ManageProducts']")]
        private IWebElement MnsRetailerManageProducts;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/RegulatedProducts']")]
        private IWebElement MnsRegulatedProducts;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/RetailerRewards']")]
        private IWebElement MnsRetailerRewards;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/Adjustment']")]
        private IWebElement MnsRetailerAdjustments;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/ManageIpsAndDevices']")]
        private IWebElement MnsMangeIpsAndDevices;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/ManageStores']")]
        private IWebElement MnsManageStores;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/ManageWallets']")]
        private IWebElement MnsManageWallets;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/ManageCertificate']")]
        private IWebElement MnsManageRetailerCertificate;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerMTOld/Index']")]
        private IWebElement MnsAgencyCodesV1;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/ChangeHistory']")]
        private IWebElement MnsChangeHistory;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RetailerManagement/DropIn']")]
        private IWebElement MnsRetailerOpenPortal;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href$='/CustomerManagement/CustomerMoneyTransferV1']")]
        private IWebElement MnsMoneyTransferV1;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href$='/CustomerManagement/CustomerMoneyTransfer']")]
        private IWebElement MnsMoneyTransfer;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/ProfileManagement/Distributors']")]
        private IWebElement MnsDistributorsReport;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/ProductManagement/Products']")]
        private IWebElement MnsProductList;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/ProductManagement/Fees']")]
        private IWebElement MnsProductFees;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/ProductManagement/Commissions']")]
        private IWebElement MnsProductCommissions;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/ProductManagement/ProductRewards']")]
        private IWebElement MnsProductRewards;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/MoneyTransfer/PricingGroup']")]
        private IWebElement MnsPricingGroup;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/MoneyTransfer/RateGroup']")]
        private IWebElement MnsRateGroup;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/MoneyTransfer/BuyRates']")]
        private IWebElement MnsBuyRates;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/MoneyTransfer/AgencyCode']")]
        private IWebElement MnsAgencyCodes;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/MoneyTransfer/AgencyMtGroup']")]
        private IWebElement MnsAgencyMtGroups;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/MoneyTransfer/HandlingRule/Index']")]
        private IWebElement MnsHandlingFeeRules;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/MoneyTransfer/HandlingRule/RetailerRules']")]
        private IWebElement MnsRetailerRules;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/MoneyTransfer/PayerDisplayGroup']")]
        private IWebElement MnsPayerDisplayGroup;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Changeset/Index']")]
        private IWebElement MnsChangesets;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Message/Index']")]
        private IWebElement MnsMessages;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Contest/Index']")]
        private IWebElement MnsContests;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Page/Index']")]
        private IWebElement MnsPagesAndZones;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Changeset/ZoneReport']")]
        private IWebElement MnsZoneReport;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/ChannelManagement/Index']")]
        private IWebElement MnsChannelAdministration;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RedisAdministration/Index']")]
        private IWebElement MnsRedisAdministration;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href='/redis-monitor']")]
        private IWebElement MnsRedisMonitor;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/RedisAdministration/PreviewSiteManagement']")]
        private IWebElement MnsPreviewSites;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Report/BankVerification']")]
        private IWebElement MnsBankVerification;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Report/AccessCodes']")]
        private IWebElement MnsAccessCodes;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Report/DistributorCertificates']")]
        private IWebElement MnsDistributorCertificates;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Report/LoginHistory']")]
        private IWebElement MnsLoginHistory;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='/Report/BillPay']")]
        private IWebElement MnsBillPay;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href*='RetailerManagement/BetaTesters']")]
        private IWebElement MnsBetaTesters;

        [IDTFindBy(How = How.CssSelector, Using = "a[class='menu-item'][href$='/CustomerManagement/CustomerMoneyTransferLite']")]
        private IWebElement MnsMoneyTransferLite;

        private Dictionary<string, MenuOption> MenuDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftMenuComponent"/> class.
        /// </summary>
        public LeftMenuComponent()
        {
            MenuDictionary = InitializeMenuDictionary();
        }

        /// <summary>
        /// Clicks an option from the left menu.
        /// </summary>
        /// <param name="option">Is an option of the top menu</param>
        public void GoToLeftOption(string option)
        {
            OpenLeftMenu();
            GetMenuItem(option).Element.ClickElementByJavaScript();
            BroWaitHelper.LoadingBRO();
        }

        /// <summary>
        /// Goes to Submenu in Bro Portal
        /// </summary>
        /// <param name="menu">The first menu</param>
        /// <param name="subMenu">Submenu of first menu</param>
        public void GoToSubMenuOption(string menu, string subMenu)
        {
            MenuOption menuItem = GetMenuItem(menu);

            OpenLeftMenu();
            Actions builder = new Actions(Driver);
            builder.MoveToElement(menuItem.Element).Perform();
            CommonActions.WaitUntilLocatorExists(By.CssSelector("div[id='loading'][style*='display: none']"));
            menuItem.GetSubMenuElement(subMenu).ClickElementByJavaScript();
            BroWaitHelper.LoadingBRO();
        }

        /// <summary>
        /// Opens the left Menu in Bro Portal.
        /// </summary>
        public void OpenLeftMenu()
        {
            BroWaitHelper.LoadingBRO();
            CommonActions.WaitUntilLocatorExists(By.CssSelector("[class='tooltips sidebar-is-closed']"));
            CommonActions.ClickElement(MnsMenuDisplay);
        }

        /// <summary>
        /// Verifies a menu option is displayed.
        /// </summary>
        /// <param name="option">Is an option of the top menu</param>
        /// <returns>True or false in bool format.</returns>
        public bool IsMenuOptionDisplayed(string option)
        {
            return GetMenuItem(option).Element.IsElementDisplayed();
        }

        /// <summary>
        /// Verifies a sub menu option is displayed.
        /// </summary>
        /// <param name="menuoption">Is an option of the top menu</param>
        /// <param name="subMenuoption">Is an option of the sub menu</param>
        /// <returns>True or false in bool format.</returns>
        public bool IsSubMenuOptionDisplayed(string menuoption, string subMenuOption)
        {
            // get menuOption dictionary
            var mainMenu = GetMenuItem(menuoption);

            // now check if submenu exists
            return mainMenu.GetSubMenuElement(subMenuOption).IsElementDisplayed();
        }

        /// <summary>
        /// Initializes the Distributors menu object
        /// </summary>
        /// <returns>Menu object representing distributors</returns>
        private MenuOption InitDistributorsMenu()
        {
            Dictionary<string, IWebElement> distributorsSubmenu = new Dictionary<string, IWebElement>()
            {
                { "GENERAL INFO", MnsDistributorGeneralInfo },
                { "CREDIT WALLET", MnsCreditWallet },
                { "CASH WALLET", MnsCashWallet },
                { "ACCESS CONTROL", MnsAccessControl },
                { "MANAGE CERTIFICATE", MnsManageDistCertificate },
                { "MANAGE PRODUCTS", MnsDistributorManageProducts },
                { "FEES", MnsDistributorFees },
                { "COMMISSIONS", MnsDistributorCommissions },
                { "ADJUSTMENTS", MnsDistributorAdjustment },
                { "OPEN PORTAL", MnsDistributorOpenPortal }
            };
            MenuOption distributors = new MenuOption("Distributors", LnkDistributor, distributorsSubmenu);

            return distributors;
        }

        /// <summary>
        /// Initializes the Retailers menu object
        /// </summary>
        /// <returns>Menu object representing retailers</returns>
        private MenuOption InitRetailersMenu()
        {
            Dictionary<string, IWebElement> retailersSubmenu = new Dictionary<string, IWebElement>()
            {
                { "GENERAL INFO", MnsRetailerGeneralInfo },
                { "MANAGE PRODUCTS", MnsRetailerManageProducts },
                { "REGULATED PRODUCTS", MnsRegulatedProducts },
                { "RETAILER REWARDS", MnsRetailerRewards },
                { "ADJUSTMENTS", MnsRetailerAdjustments },
                { "IPS AND DEVICES", MnsMangeIpsAndDevices },
                { "MANAGE STORES", MnsManageStores },
                { "MANAGE CERTIFICATE", MnsManageRetailerCertificate },
                { "AGENCY CODES V1", MnsAgencyCodesV1 },
                { "MANAGE WALLETS", MnsManageWallets },
                { "CHANGE HISTORY", MnsChangeHistory },
                { "OPEN PORTAL", MnsRetailerOpenPortal },
                { "BETA TESTERS", MnsBetaTesters }
            };
            MenuOption retailers = new MenuOption("Retailers", LnkRetailerManagement, retailersSubmenu);

            return retailers;
        }

        /// <summary>
        /// Initializes the Customers menu object
        /// </summary>
        /// <returns>Menu object representing customers</returns>
        private MenuOption InitCustomersMenu()
        {
            Dictionary<string, IWebElement> customersSubmenu = new Dictionary<string, IWebElement>()
            {
                { "MONEY TRANSFER V1", MnsMoneyTransferV1 },
                { "MONEY TRANSFER", MnsMoneyTransfer },
                { "MONEY TRANSFER LITE", MnsMoneyTransferLite }
            };
            MenuOption customers = new MenuOption("Customers", LnkCustomerManagement, customersSubmenu);

            return customers;
        }

        /// <summary>
        /// Initializes the Profiles menu object
        /// </summary>
        /// <returns>Menu object representing profiles</returns>
        private MenuOption InitProfilesMenu()
        {
            Dictionary<string, IWebElement> profilesSubmenu = new Dictionary<string, IWebElement>()
            {
                { "DISTRIBUTORS REPORT", MnsDistributorsReport }
            };
            MenuOption profiles = new MenuOption("Profiles", LnkProfileManagement, profilesSubmenu);

            return profiles;
        }

        /// <summary>
        /// Initializes the Products menu object
        /// </summary>
        /// <returns>Menu object representing products</returns>
        private MenuOption InitProductsMenu()
        {
            Dictionary<string, IWebElement> productsSubmenu = new Dictionary<string, IWebElement>()
            {
                { "PRODUCTS LIST", MnsProductList },
                { "FEES", MnsProductFees },
                { "COMMISSIONS", MnsProductCommissions },
                { "PRODUCT REWARDS", MnsProductRewards }
            };
            MenuOption products = new MenuOption("Products", LnkProductManagement, productsSubmenu);

            return products;
        }

        /// <summary>
        /// Initializes the Money Transfer menu object
        /// </summary>
        /// <returns>Menu object representing money transfer</returns>
        private MenuOption InitMoneyTransferMenu()
        {
            Dictionary<string, IWebElement> mtSubmenu = new Dictionary<string, IWebElement>()
            {
                { "PRICING GROUPS", MnsPricingGroup },
                { "RATE GROUPS", MnsRateGroup },
                { "BUY RATES", MnsBuyRates },
                { "AGENCY CODES", MnsAgencyCodes },
                { "AGENCY - MT GROUPS", MnsAgencyMtGroups },
                { "HANDLING FEE RULES", MnsHandlingFeeRules },
                { "RETAILER RULES", MnsRetailerRules },
                { "PAYER DISPLAY GROUPS", MnsPayerDisplayGroup }
            };
            MenuOption moneyTransfer = new MenuOption("Money Transfer", LnkMoneyTransfer, mtSubmenu);

            return moneyTransfer;
        }

        /// <summary>
        /// Initializes the Cms menu object
        /// </summary>
        /// <returns>Menu object representing Cms</returns>
        private MenuOption InitCmsMenu()
        {
            Dictionary<string, IWebElement> cmsSubmenu = new Dictionary<string, IWebElement>()
            {
                { "CHANGESETS", MnsChangesets },
                { "MESSAGES", MnsMessages },
                { "CONTESTS", MnsContests },
                { "PAGES AND ZONES", MnsPagesAndZones },
                { "ZONE REPORT", MnsZoneReport }
            };
            MenuOption cms = new MenuOption("Cms", LnkCms, cmsSubmenu);

            return cms;
        }

        /// <summary>
        /// Initializes the Configurtation menu object
        /// </summary>
        /// <returns>Menu object representing configuration</returns>
        private MenuOption InitConfigurationMenu()
        {
            Dictionary<string, IWebElement> configSubmenu = new Dictionary<string, IWebElement>()
            {
                { "CHANNEL ADMINISTRATION", MnsChannelAdministration },
                { "REDIS CLUSTERS", MnsRedisAdministration },
                { "REDIS MONITOR", MnsRedisMonitor },
                { "PREVIEW SITES", MnsPreviewSites }
            };
            MenuOption configuration = new MenuOption("Configuration", LnkConfiguration, configSubmenu);

            return configuration;
        }

        /// <summary>
        /// Initializes the Reports menu object
        /// </summary>
        /// <returns>Menu object representing reports</returns>
        private MenuOption InitReportsMenu()
        {
            Dictionary<string, IWebElement> reportsSubmenu = new Dictionary<string, IWebElement>()
            {
                { "BANK VERIFICATION", MnsBankVerification },
                { "ACCESS CODES", MnsAccessCodes },
                { "DISTRIBUTOR CERTIFICATES", MnsDistributorCertificates },
                { "LOGIN HISTORY", MnsLoginHistory },
                { "BILL PAY", MnsBillPay }
            };
            MenuOption reports = new MenuOption("Reports", LnkReports, reportsSubmenu);

            return reports;
        }

        /// <summary>
        /// Initializes the dictionary representing menus and submenus
        /// </summary>
        /// <returns>A dictionary of top level menu name to an object representing the menu and its corresponding submenus</returns>
        private Dictionary<string, MenuOption> InitializeMenuDictionary()
        {
            Dictionary<string, MenuOption> menuNameToMenuObjectDictionary = new Dictionary<string, MenuOption>();

            MenuOption dashboard = new MenuOption("Dashboard", LnkDashboard, new Dictionary<string, IWebElement>());
            menuNameToMenuObjectDictionary.Add("DASHBOARD", dashboard);

            MenuOption distributors = InitDistributorsMenu();
            menuNameToMenuObjectDictionary.Add("DISTRIBUTORS", distributors);

            MenuOption retailers = InitRetailersMenu();
            menuNameToMenuObjectDictionary.Add("RETAILERS", retailers);

            MenuOption customers = InitCustomersMenu();
            menuNameToMenuObjectDictionary.Add("CUSTOMERS", customers);

            MenuOption profiles = InitProfilesMenu();
            menuNameToMenuObjectDictionary.Add("PROFILES", profiles);

            MenuOption products = InitProductsMenu();
            menuNameToMenuObjectDictionary.Add("PRODUCTS", products);

            MenuOption moneyTransfer = InitMoneyTransferMenu();
            menuNameToMenuObjectDictionary.Add("MONEY TRANSFER", moneyTransfer);

            MenuOption cms = InitCmsMenu();
            menuNameToMenuObjectDictionary.Add("CMS", cms);

            MenuOption configuration = InitConfigurationMenu();
            menuNameToMenuObjectDictionary.Add("CONFIGURATION", configuration);

            MenuOption reports = InitReportsMenu();
            menuNameToMenuObjectDictionary.Add("REPORTS", reports);

            return menuNameToMenuObjectDictionary;
        }

        /// <summary>
        /// Returns the top-level menu item associated with the given name
        /// </summary>
        /// <param name="name">Name of the menu item</param>
        /// <returns>The menu item object</returns>
        private MenuOption GetMenuItem(string name)
        {
            return MenuDictionary[name.ToUpper()];
        }

        /// <summary>
        /// Represents a top-level menu web element, and a map of submenu name to submenu web element
        /// </summary>
        private class MenuOption
        {
            private string menuOption;
            private Dictionary<string, IWebElement> subMenuOptions;

            /// <summary>
            /// Initializes a new instance of the <see cref="MenuOption"/> class.
            /// </summary>
            /// <param name="menuOption">Menu item name</param>
            /// <param name="menuElement">Web element associated with the top level menu item</param>
            /// <param name="subMenuOptions">Map of submenu item name to submenu item web element</param>
            public MenuOption(string menuOption, IWebElement menuElement, Dictionary<string, IWebElement> subMenuOptions)
            {
                this.menuOption = menuOption;
                this.Element = menuElement;
                this.subMenuOptions = subMenuOptions;
            }

            /// <summary>
            /// Gets the web element that represents this menu item
            /// </summary>
            public IWebElement Element { get; }

            /// <summary>
            /// Gets one of the submenus associated with this menu, by submenu name
            /// </summary>
            /// <param name="submenuName">The name of the submenu</param>
            /// <returns>The submenu web element</returns>
            public IWebElement GetSubMenuElement(string submenuName)
            {
                if (subMenuOptions.ContainsKey(submenuName.ToUpper()))
                {
                    return subMenuOptions[submenuName.ToUpper()];
                }
                else
                {
                    throw new NoSuchElementException($"Unable to find submenu item {submenuName} for menu item {menuOption}");
                }
            }
        }
    }
}
