namespace Euro.PatientPortal.PatientPortalAPI.Test.APITest.Steps
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Euro.Core.Automation.Transformation;
    using Euro.Core.Automation.Transformation.Models;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.API;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Euro.PatientPortal.PatientPortalAPI.Main.API.Common;
    using Euro.PatientPortal.PatientPortalAPI.Main.API.JSONObject;
    using Euro.Viracor.Labalert.PatientPortalAPI.Main;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using Org.Jsoup;
    using Org.Jsoup.Nodes;
    using RestSharp;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class CreateUserSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private const string CreateUserResource = "CreateUser";
        private const string GetUserByEmailIdResource = "GetUserByEmailId";
        private const string ForgotPasswordResoutce = "ForgotPassword";

        private const string GetUserAutherization = "basic NjlFQzNCNjQtRkY2RC00QjRELTk0RTMtMzMyNTFBQ0I5RTUx";
        private const string ForgetPasswordAutherization = "Basic NjlFQzNCNjQtRkY2RC00QjRELTk0RTMtMzMyNTFBQ0I5RTUx";
        private const string CreateUserAutherization = "VlJMZGVsIW0hdGVyNHlXeUNhVWIyRUZXc09GSis4MThIRTJQT0VXVUJpVEhiaC9mNWZlZ2VZYz0=";

        [Given(@"I create a user ""(.*)"" with email ""(.*)"" , BU ""(.*)"" and note the ""(.*)""")]
        public void GivenICreateAUserWithEmailBUAndNoteThe(string userKey, StringValue emailAddress, string bu, string referenceID)
        {
            CreateUser user = new CreateUser();
            string emailId = emailAddress.Value;
            user.firstName = emailId.Split('@')[0];
            user.lastName = emailId.Split('@')[0];
            user.dob = "1994-09-27";
            user.email = emailAddress.Value;
            user.phone = CommonFunctions.GetRandomPhoneNumber();
            user.city = Utils.GenerateRandomAlphabetLetters(8);
            user.state = "NY";
            user.ZipCode = "11747";
            user.testedLab = bu;
            user.addressLine1 = Utils.GenerateRandomAlphabetLetters(10);
            user.addressLine2 = null;
            user.privacyPolicy = true;
            user.termsOfUse = true;
           Api api = EnvironmentManager.GetApiInfo("USER");
            object jsonObect=JToken.FromObject(user);
            IRestResponse res = APIManager.PostRequest(api.Url, CreateUserResource, jsonObect, CreateUserAutherization);
            string actual = res.StatusCode.ToString();
            Assert.AreEqual("OK", res.StatusCode, $"Failed Creating user error {res.Content.ToString()} for the data {jsonObect.ToString()}");
            var value=res.Content.Substring(1).Replace('"', ' ').Trim();
            ScenarioContext.Current[referenceID] = value;
            ScenarioContext.Current[userKey] = user;
        }
 
        [When(@"User set password ""(.*)"" for the user ""(.*)"" with referenceId ""(.*)""")]
        public void WhenUserSetPasswordForTheUserWithReferenceId(string password, string userKey, string refIdKey)
        {
            CreateUser user = ScenarioContext.Current.Get<CreateUser>(userKey);
            Api api = EnvironmentManager.GetApiInfo("PASSWORD");
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.newPassword = password;
            forgotPassword.confirmPassword = password;
            forgotPassword.email = user.email;
            forgotPassword.objectId = ScenarioContext.Current.Get<string>(refIdKey).ToString();
            forgotPassword.userCode = "234234";
            forgotPassword.verificationCode = "234234";
            forgotPassword.sentDateTime = DateTime.Now;
            object jsonObect = JToken.FromObject(forgotPassword);
            IRestResponse res = APIManager.PostRequest(api.Url, ForgotPasswordResoutce, jsonObect, CreateUserAutherization);
            string statusCode = res.StatusCode.ToString();
            Assert.AreEqual("OK", statusCode, $"Setting password failed with error {res.Content.ToString()} for the data {jsonObect.ToString()}");
        }

        [When(@"I set password ""(.*)"" for created User ""(.*)"" with referenceId ""(.*)""")]
        public void WhenISetPasswordForCreatedUserWithReferenceId(string password, string userKey, string refIdKey)
        {
            AddPatientReportInfo addPatientReportInfo = ScenarioContext.Current.Get<AddPatientReportInfo>(userKey);
            Api api = EnvironmentManager.GetApiInfo("PASSWORD");
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.newPassword = password;
            forgotPassword.confirmPassword = password;
            forgotPassword.email = addPatientReportInfo.email;
            forgotPassword.objectId = ScenarioContext.Current.Get<string>(refIdKey).ToString();
            forgotPassword.userCode = "234234";
            forgotPassword.verificationCode = "234234";
            forgotPassword.sentDateTime = DateTime.Now;
            object jsonObect = JToken.FromObject(forgotPassword).ToString();
            IRestResponse res = APIManager.PostRequest(api.Url, ForgotPasswordResoutce, jsonObect, ForgetPasswordAutherization);
            string statusCode = res.StatusCode.ToString();
            Assert.AreEqual("OK", statusCode,$"Setting password failed with error {res.Content.ToString()} for the data {jsonObect.ToString()}");
        }

        [When(@"I Create User ""(.*)"" and note referenceId ""(.*)""")]
        public void WhenICreateUserAndNoteReferenceId(string userKey, string refKey)
        {
            CreateUser user = new CreateUser();
            AddPatientReportInfo addPatientReportInfo = ScenarioContext.Current.Get<AddPatientReportInfo>(userKey);
            string emailId = addPatientReportInfo.email;
            user.firstName = emailId.Split('@')[0];
            user.lastName = emailId.Split('@')[0];
            user.dob = "1994-09-27";
            user.email = emailId;
            user.phone = (string)addPatientReportInfo.phone;
            user.city = addPatientReportInfo.city;
            user.state = addPatientReportInfo.state;
            user.ZipCode = addPatientReportInfo.zipCode;
            user.testedLab = addPatientReportInfo.bu;
            user.addressLine1 = addPatientReportInfo.addressLine1;
            user.addressLine2 = (string)addPatientReportInfo.addressLine2;
            user.privacyPolicy = true;
            user.termsOfUse = true;
            Api api = EnvironmentManager.GetApiInfo("USER");
            Api getUser = EnvironmentManager.GetApiInfo("IDMUSER");
            object jsonObect = JToken.FromObject(user).ToString();
            IRestResponse response = APIManager.PostRequest(api.Url, CreateUserResource, jsonObect, CreateUserAutherization);
            string statusCode = response.StatusCode.ToString();
            Assert.AreEqual("OK", statusCode, $"User Creation failed with error {response.Content.ToString()} for the data {jsonObect.ToString()}");
            CommonActions.WaitUntil(1);
            response = APIManager.GetRequest(getUser.Url, $"{GetUserByEmailIdResource}/{emailId}",GetUserAutherization);
            string value=JObject.Parse(response.Content).GetValue("id").ToString();
            ScenarioContext.Current[refKey] = value;
        }
    }
}
