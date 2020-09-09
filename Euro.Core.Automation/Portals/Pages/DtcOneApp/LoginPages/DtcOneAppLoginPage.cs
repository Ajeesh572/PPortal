// <copyright file="DtcOneAppLoginPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.DtcOneApp.LoginPages
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Common;
    using Euro.Core.Automation.Portals.Pages.Common.LoginPages;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.JsonManager;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Handles the login page in DTC OneApp portal
    /// </summary>
    public class DtcOneAppLoginPage : BasePage, ILoginPage
    {
        [IDTFindBy(How = How.Id, Using = "UserName")]
        private IWebElement TxtUsername;

        [IDTFindBy(How = How.Id, Using = "Password")]
        private IWebElement TxtPassword;

        [IDTFindBy(How = How.CssSelector, Using = "input[name = 'login']")]
        private IWebElement BtnLogin;

        [IDTFindBy(How = How.CssSelector, Using = "div[class = 'key container flash-error']")]
        private IWebElement LblErrorMessage;

        /// <inheritdoc/>
        public bool IsLoginPage()
        {
            bool isLoginPage;
            isLoginPage = TxtUsername.Displayed && TxtPassword.Displayed ? true : false;
            return isLoginPage;
        }

        /// <inheritdoc/>
        public void LoginAsUserType(UserType userType, PortalWeb portal)
        {
            var user = EnvironmentManager.GetUser(portal.ToString(), userType.ToString());
            CommonActions.SendKeys(TxtUsername, user.Name);
            CommonActions.SendKeys(TxtPassword, user.Password);
            CommonActions.ScrollIntoView(BtnLogin, true);
            BtnLogin.ClickElementByJavaScript();
        }

        /// <summary>
        /// Login user in DTC OneApp portal.
        /// </summary>
        /// <param name="username">Is the username.</param>
        /// <param name="password">Is the password.</param>
        public void LoginUser(string username, string password)
        {
            CommonActions.SendKeys(TxtUsername, username);
            CommonActions.SendKeys(TxtPassword, password);
            CommonActions.ScrollIntoView(BtnLogin, true);
            BtnLogin.ClickElementByJavaScript();
        }

        /// <summary>
        /// Verifies if an error message is displayed.
        /// </summary>
        /// <returns>True if the error message is displayed</returns>
        public bool IsAnErrorMessageDisplayed()
        {
            return LblErrorMessage.Displayed;
        }

        /// <summary>
        /// Gets the error meesage content.
        /// </summary>
        /// <returns>The text in LblErrorMessage</returns>
        public string GetTheErrorMessage()
        {
            return LblErrorMessage.Text;
        }
    }
}
