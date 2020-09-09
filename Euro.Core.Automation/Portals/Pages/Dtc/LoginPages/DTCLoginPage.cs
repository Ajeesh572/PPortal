// <copyright file="DTCLoginPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Dtc.LoginPages
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Common;
    using Euro.Core.Automation.Portals.Pages.Common.LoginPages;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Euro.Core.Automation.Utilities.Logger;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// MVNO Login page object
    /// </summary>
    public class DTCLoginPage : BasePage, ILoginPage
    {
        [IDTFindBy(How = How.Id, Using = "phoneNumber")]
        private IWebElement TxtPhoneNumber;

        [IDTFindBy(How = How.Id, Using = "securityCode")]
        private IWebElement TxtSecurityCode;

        [IDTFindBy(How = How.Id, Using = "signIn")]
        private IWebElement BtnSignIn;

        public bool IsLoginPage()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(TxtPhoneNumber));
                result = true;
            }
            catch (WebDriverTimeoutException e)
            {
                // TODO Change for log when it is implemented.
                Logging.Debug("Cannot find to web element." + e);
            }

            return result;
        }

        /// <summary>
        /// Logs in according to the given user type.
        /// </summary>
        /// <param name="userType">Type of user required.</param>
        public void LoginAsUserType(UserType userType, PortalWeb portal)
        {
            var user = EnvironmentManager.GetUser(portal.ToString(), userType.ToString());
            // TODO Change this implemention when to implement CredentialManager logic.
            CommonActions.SendKeys(TxtPhoneNumber, user.Name);
            CommonActions.SendKeys(TxtSecurityCode, user.Password);
            CommonActions.ClickElement(BtnSignIn);
            CommonActions.WaitUntilLocatorExists(By.CssSelector("div[class='loader']"));
        }
    }
}
