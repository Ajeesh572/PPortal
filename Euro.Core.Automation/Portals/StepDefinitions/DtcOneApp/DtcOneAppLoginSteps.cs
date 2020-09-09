// <copyright file="DtcOneAppLoginSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.DtcOneApp
{
    using Euro.Core.Automation.Portals.Pages.DtcOneApp.LoginPages;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Handles the step definition methods for Login page of DTC OneApp portal
    /// </summary>
    [Binding]
    public class DtcOneAppLoginSteps
    {
        private DtcOneAppLoginPage LoginPage;

        public DtcOneAppLoginSteps()
        {
            LoginPage = new DtcOneAppLoginPage();
        }

        [StepDefinition(@"I enter (.*) (?:email|phone number) and (.*) (?:password|security code) to login user in DTC OneApp portal")]
        public void EnterUsernameAndPasswordToLoginUser(string username, string password)
        {
            LoginPage.LoginUser(username, password);
        }

        [Then(@"an error message should be displayed in DTC OneApp portal with the following content: (.*)")]
        public void AnErrorMessageShouldBeDisplayedWithTheFollowingContent(string message)
        {
            Assert.Multiple(() =>
            {
                Assert.True(LoginPage.IsAnErrorMessageDisplayed(), "Error: The expected error message is not displayed");
                Assert.AreEqual(LoginPage.GetTheErrorMessage(), message, string.Format("Error: The actual error message: {0} is different than the expected {1}", LoginPage.GetTheErrorMessage(), message));
            });
        }
    }
}
