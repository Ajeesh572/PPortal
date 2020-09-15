

namespace Euro.PatientPortal.PatientPortalAPI.Test.APITest.Steps
{
    using System;
    using System.IO;
    using Euro.Core.Automation.Assert;
    using Euro.Core.Automation.Transformation;
    using Euro.Core.Automation.Transformation.Models;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.API;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Euro.PatientPortal.PatientPortalAPI.Main.API.Common;
    using Euro.PatientPortal.PatientPortalAPI.Main.API.JSONObject;
    using Euro.Viracor.Labalert.PatientPortalAPI.Main;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using RestSharp;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class AddReportSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private const string Autherization = "VlJMZGVsIW0hdGVyNHlXeUNhVWIyRUZXc09GSis4MThIRTJQT0VXVUJpVEhiaC9mNWZlZ2VZYz0=";

        [When(@"I add report ""(.*)"" for the user ""(.*)""")]
        public void WhenIAddReportForTheUser(string reportName, string userKey)
        {
            CreateUser user = ScenarioContext.Current.Get<CreateUser>(userKey);
            Api api = EnvironmentManager.GetApiInfo("REPORT");
            AddPatientReportInfo aPRI = new AddPatientReportInfo();
            aPRI.orderId = CommonFunctions.GetRandomPhoneNumber();
            aPRI.orderDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz"));
            aPRI.testName = $"Test: {DateTime.Now}";
            aPRI.bu = user.testedLab;
            aPRI.firstName = user.firstName;
            aPRI.lastName = user.lastName;
            aPRI.dob = user.dob;
            aPRI.email = user.email;
            aPRI.phone = user.phone;
            aPRI.zipCode = user.ZipCode;
            aPRI.city = user.city;
            aPRI.state = user.state;
            aPRI.addressLine1 = user.addressLine1;
            aPRI.addressLine2 = user.addressLine2;
            aPRI.report = PPCommmon.GetPdfInBytes(reportName);
            Root root = new Root();
            string array = JToken.FromObject(root.AddPatientReportInfo(aPRI)).ToString();
            IRestResponse res = APIManager.PostRequest(api.Url, "AddPatientReportInfo", array, Autherization);
            string expected = "OK";
            string actual = res.StatusCode.ToString();
            Assert.AreEqual(expected, actual);
        }

        [When(@"I add ""(.*)"" reports for user ""(.*)""")]
        public void WhenIAddReportsForUser(int numOfReports, string userKey)
        {
            for (int i = 0; i < numOfReports; i++)
            {
                AddPatientReportInfo user = ScenarioContext.Current.Get<AddPatientReportInfo>(userKey);
                Api api = EnvironmentManager.GetApiInfo("REPORT");
                AddPatientReportInfo aPRI = new AddPatientReportInfo();
                aPRI.orderId = CommonFunctions.GetRandomPhoneNumber();
                aPRI.orderDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz"));
                aPRI.testName = $"Test: {DateTime.Now}";
                aPRI.bu = user.bu;
                aPRI.firstName = user.firstName;
                aPRI.lastName = user.lastName;
                aPRI.dob = user.dob;
                aPRI.email = user.email;
                aPRI.phone = user.phone;
                aPRI.zipCode = user.zipCode;
                aPRI.city = user.city;
                aPRI.state = user.state;
                aPRI.addressLine1 = user.addressLine1;
                aPRI.addressLine2 = user.addressLine2;
                aPRI.report = PPCommmon.GetPdfInBytes(getRandomPDFFile());
                Root root = new Root();
                string array = JToken.FromObject(root.AddPatientReportInfo(aPRI)).ToString();
                IRestResponse response = APIManager.PostRequest(api.Url, "AddPatientReportInfo", array, Autherization);
                string expected = "OK";
                string actual = response.StatusCode.ToString();
                Assert.AreEqual(expected, actual, $"Sending report failed with response{response.Content} for the data {array}");
            }
        }

        [When(@"I added User creds username ""(.*)"" password ""(.*)"" and number of reports added ""(.*)""")]
        public void WhenIAddedUserCredsUsernamePasswordAndNumberOfReportsAdded(string userKey, string password, int numOfReports=1)
        {
            int reports = numOfReports + 1;
            try
            {
                CreateUser user = ScenarioContext.Current.Get<CreateUser>(userKey);
                CsvData.LogCsvSummary(string.Format("{0}", string.Empty + "," + user.email + "," + user.firstName + "," + user.lastName + "," + user.dob + "," + user.ZipCode + "," + user.phone + "," + password + "," + reports));
            }
            catch
            {
                AddPatientReportInfo aPRI= ScenarioContext.Current.Get<AddPatientReportInfo>(userKey);
                CsvData.LogCsvSummary(string.Format("{0}", string.Empty + "," + aPRI.email + "," + aPRI.firstName + "," + aPRI.lastName + "," + aPRI.dob + "," + aPRI.zipCode + "," + aPRI.phone + "," + password + "," + reports));
            }
        }

        private string getRandomPDFFile()
        {
            string[] filePaths = Directory.GetFiles(@"C:\CodeBases\Eurofins_PP\Euro\Euro.PatientPortal\TestPdfs\", "*.pdf");
            Random random = new Random();
            int index = random.Next(filePaths.Length);
            var path = filePaths[index];
            return Path.GetFileName(path);
        }

        [Given(@"I send report ""(.*)"" for the user ""(.*)"" with email ""(.*)"" for Bu ""(.*)""")]
        public void GivenISendReportForTheUser(string reportName, string userKey,StringValue emailAddress, string bu)
        {
            Api api = EnvironmentManager.GetApiInfo("REPORT");
            AddPatientReportInfo aPRI = new AddPatientReportInfo();
            aPRI.orderId = CommonFunctions.GetRandomPhoneNumber();
            aPRI.orderDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz"));
            aPRI.testName = $"Test: {DateTime.Now}";
            aPRI.bu = bu;
            aPRI.firstName = emailAddress.Value.Split('@')[0];
            aPRI.lastName = aPRI.firstName;
            aPRI.dob = "1994-09-27";
            aPRI.email = emailAddress.Value;
            aPRI.phone = CommonFunctions.GetRandomPhoneNumber();
            aPRI.zipCode = "11747";
            aPRI.city = "Pune";
            aPRI.state = "NY";
            aPRI.addressLine1 = Utils.GenerateRandomString(8);
            aPRI.addressLine2 = null;
            aPRI.report = PPCommmon.GetPdfInBytes(reportName);
            Root root = new Root();
            object array = JToken.FromObject(root.AddPatientReportInfo(aPRI));
            IRestResponse res = APIManager.PostRequest(api.Url, "AddPatientReportInfo", array, Autherization);
            string expected = "OK";
            string actual = res.StatusCode.ToString();
            ScenarioContext.Current[userKey] = aPRI;
            Assert.AreEqual(expected, actual, $"Sending report failed with response {res.Content} for the data {array}");
        }
    }
}
