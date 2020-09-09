// <copyright file="AdminComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Class to handle the Admin component
    /// </summary>
    public class AdminComponent : BasePage, IOasisComponent
    {
        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/admin/LoginAs.cfm']")]
        [IDTFieldName("LOGIN AS")]
        private IWebElement LnkLoginAs;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/admin/usermaintain.cfm']")]
        [IDTFieldName("USER MAINTENANCE")]
        private IWebElement LnkUserMaintenance;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/admin/SetNotice.cfm']")]
        [IDTFieldName("SET NOTICE")]
        private IWebElement LnkSetNotice;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/msa/MSAtree.cfm']")]
        [IDTFieldName("MSA")]
        private IWebElement LnkMsa;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/utility/TransDateChange.cfm']")]
        [IDTFieldName("CHANGE TRANSACTION DATE")]
        private IWebElement LnkChangeTransactionDate;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/utility/CardEditor.cfm']")]
        [IDTFieldName("CARD EDITOR")]
        private IWebElement LnkCardEditor;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/utility/ResetStaging.cfm']")]
        [IDTFieldName("RESET STAGING")]
        private IWebElement LnkResetStaging;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/PendingCreditCheck.cfm']")]
        [IDTFieldName("PENDING CREDIT CHECK")]
        private IWebElement LnkPendingCreditCheck;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/utility/ExpireCards.cfm']")]
        [IDTFieldName("EXPIRE/UNEXPIRE CARDS")]
        private IWebElement LnkExpireUnexpireCards;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/utility/EscrowMiscInvoice.cfm?init=true']")]
        [IDTFieldName("UPLOAD ESCROW REBATE")]
        private IWebElement LnkUploadEscrowRebate;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/utility/BulkReceiptUpload.cfm?init=true']")]
        [IDTFieldName("BULK RECEIPT UPLOAD")]
        private IWebElement LnkBulkReceiptUpload;

        [IDTFindBy(How = How.CssSelector, Using = "a[href='/debit/oasis/admin/RefreshOracleSnapshots.cfm']")]
        [IDTFieldName("REFRESH ORACLE SNAPSHOT")]
        private IWebElement LnkRefreshOracleSnapshot;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/admin/RAM.cfm?init=true']")]
        [IDTFieldName("ROUTE ADMIN")]
        private IWebElement LnkRouteAdmin;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/admin/CustomerRegistration.cfm']")]
        [IDTFieldName("CUSTOMER REGISTRATION")]
        private IWebElement LnkCustomerRegistration;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/admin/RouteReconPending.cfm']")]
        [IDTFieldName("ROUTE INVENTORY RECONCILIATION")]
        private IWebElement LnkRouteInventoryReconciliation;

        [IDTFindBy(How = How.CssSelector, Using = "a[href = '/debit/oasis/utility/NRSInvoice.cfm?init=true']")]
        [IDTFieldName("NRS INVOICE")]
        private IWebElement LnkNrsInvoice;

        /// <inheritdoc />
        public void ClickOnItem(string item)
        {
            Click(item);
        }

        /// <inheritdoc />
        public void ClickOnSubItem(string item, string subitem)
        {
            // no submenus for this tab
        }
    }
}
