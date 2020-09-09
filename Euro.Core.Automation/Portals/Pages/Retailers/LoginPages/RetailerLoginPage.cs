// <copyright file="RetailerLoginPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.LoginPages
{
    using System;
    using System.Data;
    using Euro.Core.Automation.Portals.Pages.Common.LoginPages;
    using Euro.Core.Automation.Portals.Pages.Retailers.Components;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.DB;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Euro.Core.Automation.Utilities.Logger;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class handles the Retailer Login Page.
    /// </summary>
    public class RetailerLoginPage : OneAppLoginPage
    {

        [IDTFindBy(How = How.CssSelector, Using = "button[data-submit-url*='TwoStepVerificationGetCode?deliveryMethod=Sms']")]
        private IWebElement BtnSendMeAText;

        [IDTFindBy(How = How.Name, Using = "code")]
        private IWebElement TxtCode;

        [IDTFindBy(How = How.CssSelector, Using = "input[name='code'] + div input[type='submit']")]
        private IWebElement BtnSubmit;

        private NotifyComponent NotifyComponent;

        public RetailerLoginPage()
        {
            NotifyComponent = new NotifyComponent();
        }

        /// <summary>
        /// Verifies if login is new device verification in Portal Web.
        /// </summary>
        /// <returns>True if login is new device verification in Retailer Portal Web</returns>
        public bool IsNewDeviceVerification()
        {
            return BtnSendMeAText.IsElementDisplayed();
        }

        /// <summary>
        /// Obtains the code for verification step.
        /// </summary>
        /// <returns>The code.</returns>
        public string GetTextCode()
        {
            ClickOnBtnSendMeAText();
            string query = @"select Code from oneapp.verification_code j where j.created_at > sysdate - 1/24 and verification_code_type = 'Login' order by j.created_at desc";
            int maximumNumberOfRetry = 3;
            int retry = 0;
            string codeObtained = string.Empty;
            DataTable table;
            while (retry <= maximumNumberOfRetry)
            {
                CommonActions.WaitUntil(1);
                table = DBConnection.GetData(EnvironmentManager.GetDatabaseName(), query);
                if (table.Rows.Count != 0)
                {
                    codeObtained = table.Rows[0]["CODE"].ToString();
                    break;
                }
                else
                {
                    Logging.Debug($"Try:'{retry}' - Error trying to get the verification code for the agent user'");
                }

                retry++;
            }

            Logging.Debug($"The number of retries to obtain the verification code '{codeObtained}' for the agent user were: '{retry}'");
            return codeObtained;
        }

        /// <summary>
        /// Clicks on Submit button.
        /// </summary>
        public void ClickOnBtnSubmit()
        {
            CommonActions.ClickElement(BtnSubmit);
            NotifyComponent.WaitUntilNotificationMessageIsInvisible();
        }

        /// <summary>
        /// Fills the code in the TxtCode WebElement.
        /// </summary>
        /// <param name="code">The code to fill.</param>
        /// <returns>An instance of <see cref="RetailerLoginPage"/>.</returns>
        public RetailerLoginPage FillTxtCode(string code)
        {
            CommonActions.SendKeys(TxtCode, code);
            return this;
        }

        /// <summary>
        /// Clicks on SendMeAText button.
        /// </summary>
        /// <returns>An instance of <see cref="RetailerLoginPage"/>.</returns>
        public RetailerLoginPage ClickOnBtnSendMeAText()
        {
            CommonActions.ClickElement(BtnSendMeAText);
            NotifyComponent.WaitUntilNotificationMessageIsInvisible();
            return this;
        }
    }
}
