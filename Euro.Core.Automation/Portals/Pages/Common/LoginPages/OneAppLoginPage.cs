// <copyright file="OneAppLogin.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Common.LoginPages
{
    using Euro.Core.Automation.Entities;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Portals.Pages.Common;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Euro.Core.Automation.Utilities.Logger;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// This class handles the OneAppLogin Login Page.
    /// </summary>
    public class OneAppLoginPage : BasePage, ILoginPage
    {
        [IDTFindBy(How = How.Id, Using = "Username")]
        private IWebElement TxtUserName;

        [IDTFindBy(How = How.Id, Using = "Password")]
        private IWebElement TxtPassword;

        [IDTFindBy(How = How.CssSelector, Using = "form#login-form div button[value='Log in']")]
        private IWebElement BtnLogin;

        /// <summary>
        /// Verifies that current page is equal to login page.
        /// </summary>
        /// <returns>True if current page is login page, false otherwise.</returns>
        public bool IsLoginPage()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(BtnLogin));
                result = true;
            }
            catch (WebDriverTimeoutException e)
            {
                // Change for log when it is implemented.
                System.Console.WriteLine("Cannot find to web element.");
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

            // Change this implementation when to implement CredentialManager logic.
            CommonActions.SendKeys(TxtUserName, user.Name);
            CommonActions.SendKeys(TxtPassword, user.Password);
            BtnLogin.ClickElement();
            if (portal == PortalWeb.Retailer || portal == PortalWeb.Distributor)
            {
                LanguageManager.Instance.VerifyLanguageInRetailerPortal();
            }
        }

        /// <summary>
        /// Fill login form.
        /// </summary>
        /// <param name="loginEntity">Represent login entity.</param>
        public void FillForm(LoginEntity loginEntity)
        {
            SetUserName(loginEntity.Login);
            SetPassword(loginEntity.Password);
        }

        /// <summary>
        /// Sets user name field.
        /// </summary>
        /// <param name="userName">the value to fill on userName field.</param>
        public void SetUserName(string userName)
        {
            CommonActions.SendKeys(TxtUserName, userName);
        }

        /// <summary>
        /// Sets password field.
        /// </summary>
        /// <param name="password">the value to fill on password field.</param>
        public void SetPassword(string password)
        {
            CommonActions.SendKeys(TxtPassword, password);
        }

        /// <summary>
        /// Clicks on Log In button.
        /// </summary>
        public void ClickOnLogInButton()
        {
            CommonActions.ClickElement(BtnLogin);
        }

        /// <summary>
        /// Gets the validation error by the given field .
        /// </summary>
        /// <param name="fieldName">The name of field</param>
        /// <returns>The validation error according to the given field.</returns>
        public string GetValidationErrorByField(string fieldName)
        {
            string idValue = fieldName.ToUpper().Equals("USERNAME") ? "Username" : "Password";
            By errorMessageLocatorByField = By.CssSelector($".field-validation-error span[id^='{idValue}-error']");
            try
            {
                return WebDriverManager.Instance.GetWebDriver.FindElement(errorMessageLocatorByField).Text.Trim();
            }
            catch (NoSuchElementException e)
            {
                Logging.Debug($"Unable to find the error message locator for '{fieldName}' field in Login Page: {e.GetBaseException()}");
                return string.Empty;
            }
        }
    }
}
