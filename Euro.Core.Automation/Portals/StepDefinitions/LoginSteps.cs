// <copyright file="LoginSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions
{
    using System;
    using Euro.Core.Automation.Entities;
    using Euro.Core.Automation.Portals.Pages.Common;
    using Euro.Core.Automation.Portals.Pages.Common.HomePages;
    using Euro.Core.Automation.Portals.Pages.Common.LoginPages;
    using Euro.Core.Automation.Portals.Pages.Retailers.LoginPages;
    using Euro.Core.Automation.Portals.Utils;
    using Euro.Core.Automation.Transformation.Models;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.Context;
    using Euro.Core.Automation.Utilities.JsonManager;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class LoginSteps
    {
        private ILoginPage LoginPage;
        private User User;
        private UserType currentUserType;
        private PortalWeb currentPortalWeb;
        private OneAppLoginPage OneAppLogin;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSteps"/> class.
        /// </summary>
        /// <param name="user"> user for current scenario</param>
        public LoginSteps(User user)
        {
            User = user;
        }

        [StepDefinition(@"I login to ""(.*)"" portal web with ""(.*)"" credentials")]
        public void ILoginToWebWithCredentials(string portalWeb, string userType)
        {
            User.Type = userType;
            FeatureContext.Current["Portal"] = portalWeb;
            currentPortalWeb = (PortalWeb)Enum.Parse(typeof(PortalWeb), portalWeb);
            currentUserType = (UserType)Enum.Parse(typeof(UserType), userType);
            OneAppLoginHelper.LoginToWebWithCredentials(currentPortalWeb, currentUserType);
            ScenarioContextManager.SetValue("CurrentPortalWeb", currentPortalWeb);
        }

        /// <summary>
        /// StepDefiniton used only for Billing Transaction processes.
        /// </summary>
        /// <param name="portal">Name of Portal</param>
        /// <param name="type">Type of Credential</param>
        [Given(@"I login to ""(.*)"" portal web with respective ""(.*)"" credentials")]
        public void GivenILoginToPortalWebWithRespectiveCredentials(string portal, string type)
        {
            var userType = string.IsNullOrEmpty(TestContext.Parameters.Get("dbpsetting")) ? string.Concat(type, "BillingRetailerDAILY") :
                string.Concat(type, "BillingRetailer", TestContext.Parameters.Get("dbpsetting").ToUpper());
            ILoginToWebWithCredentials(portal, userType);
        }

        [StepDefinition(@"Go to ""(.*)"" login portal")]
        public void GivenGoToLoginPortal(string portalWeb)
        {
            FeatureContext.Current["Portal"] = portalWeb;
            currentPortalWeb = (PortalWeb)Enum.Parse(typeof(PortalWeb), portalWeb);
            OneAppLoginHelper.GoToLoginPage(currentPortalWeb);
        }

        [StepDefinition(@"Enter ""(.*)"" credentials")]
        public void WhenEnterCredentials(string userType)
        {
            currentUserType = (UserType)Enum.Parse(typeof(UserType), userType);
            LoginPage = new LoginFactory().CreateLoginPage(currentPortalWeb);

            // Login in Portal Web.
            LoginPage.LoginAsUserType(currentUserType, currentPortalWeb);
        }

        [StepDefinition(@"I send me a text code by phone")]
        public void ISendMeATextCodeByPhone()
        {
            LoginPage = OneAppLoginHelper.GetLoginPageInstance(currentPortalWeb);
            if (LoginPage.GetType() == typeof(RetailerLoginPage))
            {
                RetailerLoginPage retailerLoginPage = (RetailerLoginPage)LoginPage;
                if (retailerLoginPage.IsNewDeviceVerification())
                {
                    string textCode = retailerLoginPage.GetTextCode();
                    retailerLoginPage
                        .FillTxtCode(textCode)
                        .ClickOnBtnSubmit();
                }
            }
            else
            {
                throw new LoginExecption($"The type of class isn't of type RetailerLoginPage, it is: {LoginPage.GetType()}");
            }
        }

        /// <summary>
        /// Assert true if the current page is an agent or retailer homepage.
        /// </summary>
        [Then(@"Verify that User is able to login successfully")]
        [Then(@"Verify that User is on Home Page")]
        public void VerifyThatRetailerUserIsAbleToLoginSuccessfully()
        {
            IHomePage homePage = new HomePageFactory().CreateHomePage(currentPortalWeb);
            Assert.IsTrue(homePage.IsHomePage(), "User is not on the Home page");
        }

        [StepDefinition(@"I click on Log In button on One App Login page")]
        [When(@"I click on log in button")]
        public void ClickOnLogInButton()
        {
            OneAppLogin = (OneAppLoginPage)new LoginFactory().CreateLoginPage(currentPortalWeb);
            OneAppLogin.ClickOnLogInButton();
            LanguageManager.Instance.VerifyLanguageInRetailerPortal();
        }

        [StepDefinition(@"I fill the username field with ""(.*)"" value and password with ""(.*)"" value in login page")]
        public void FillTheUsernameAndPasswordWithValueInLoginPage(StringValue usernameValue, StringValue passwordValue)
        {
            OneAppLogin = (OneAppLoginPage)new LoginFactory().CreateLoginPage(currentPortalWeb);
            OneAppLogin.SetUserName(usernameValue.Value);
            OneAppLogin.SetPassword(passwordValue.Value);
        }

        [StepDefinition(@"I fill login form on One App Login page")]
        public void FillLoginForm(LoginEntity loginEntity)
        {
            ((OneAppLoginPage)new LoginFactory().CreateLoginPage(currentPortalWeb)).FillForm(loginEntity);
        }

        [Then(@"the error message ""(.*)"" should be displayed in Login Page for ""(.*)"" field")]
        public void TheErrorMessageShouldBeDisplayedInLoginPageForField(string errorMessage, string fieldName)
        {
            Assert.AreEqual(errorMessage, OneAppLogin.GetValidationErrorByField(fieldName), $"Wrong error validation message is displayed for '{fieldName}' field in Login Page");
        }

        [Then(@"Verify that we are on Login page")]
        public void IsLoginPageOpen()
        {
            Assert.IsTrue(OneAppLogin.IsLoginPage(), "We are not at the Login Page");
        }
    }
}
