// <copyright file="RestAPIValidationsSteps.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Euro.Viracor.Labalert.PatientPortalAPI.Test.APITest.Steps
{
    using System;
    using Euro.Core.Automation.Transformation;
    using Euro.Core.Automation.Transformation.Models;
    using Euro.Core.Automation.Utilities.API;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Euro.PatientPortal.PatientPortalAPI.Main.API.Common;
    using Euro.Viracor.Labalert.PatientPortalAPI.Main;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using RestSharp;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class RestAPIValidationsSteps
    {
        private const string Autherization = "VlJMZGVsIW0hdGVyNHlXeUNhVWIyRUZXc09GSis4MThIRTJQT0VXVUJpVEhiaC9mNWZlZ2VZYz0=";

        [When(@"user hits api ""(.*)"" (without|with) Report ""(.*)"" for BU ""(.*)"" and email ""(.*)"" and save respose code by key ""(.*)""")]
        public void WhenUserHitsApiWithoutReportForBUAndEmailAndSaveResposeCodeByKey(string resource, string reportW, string reportName, string bu, StringValue email, string key)
        {
            Api api = EnvironmentManager.GetApiInfo("REPORT");
            AddPatientReportInfo aPRI = new AddPatientReportInfo();
            aPRI.orderId = CommonFunctions.GetRandomPhoneNumber();
            aPRI.orderDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz"));
            aPRI.testName = $"Test: {DateTime.Now}";
            aPRI.bu = bu;
            aPRI.orderStatus = null;
            aPRI.reportId = null;
            aPRI.firstName = CommonFunctions.GetRandomPhoneNumber();
            aPRI.lastName = CommonFunctions.GetRandomPhoneNumber();
            aPRI.dob = "1994-09-27";
            aPRI.email = email.Value;
            aPRI.phone = null;
            aPRI.zipCode = "11747";
            aPRI.city = "Pune";
            aPRI.state = "VT";
            aPRI.addressLine1 = "Address";
            aPRI.addressLine2 = null;
            aPRI.report = reportW.Equals("with") ? PPCommmon.GetPdfInBytes(reportName) : null;
            Root root = new Root();
            IRestResponse res = APIManager.PostRequest(api.Url, resource, JToken.FromObject(root.AddPatientReportInfo(aPRI)), Autherization);
            ScenarioContext.Current[key] = res.StatusCode.ToString();
        }

        [Then(@"verify that resposnse code ""(.*)"" is ""(.*)""")]
        public void ThenVerifyThatResposnseCodeIs(string key, string value)
        {
            string resCode = ScenarioContext.Current[key].ToString();
            Assert.AreEqual(value.ToUpper(), resCode.ToUpper());
        }
    }
}