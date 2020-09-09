// <copyright file="TestRailManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.TestRail
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Euro.Core.Automation.Assert;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using TechTalk.SpecFlow;
    using Utilities.Logger;

    /// <summary>
    /// TestRail Reporting Class
    /// </summary>
    public class TestRailManager
    {
        private static APIClient _client;

        /// <summary>
        /// Add a Result for a TC into the TestRail run
        /// </summary>
        /// <param name="scenario">Add a Result into a Test Case</param>
        public static void AddResultTestCase(ScenarioContext scenario)
        {
            var testCaseId = TestRailHelper.GetTestCaseId(scenario.ScenarioInfo.Title);
            Logging.Debug($"Updating the status of '{testCaseId}' test case at TestRail");
            var pInfo = typeof(ScenarioContext).GetProperty("TestStatus",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var getter = pInfo.GetGetMethod(nonPublic: true);
            var testResult = getter.Invoke(scenario, null).ToString();

            SendResultToTestRail(testCaseId, testResult, ScenarioContext.Current.TestError);
        }

        /// <summary>
        /// Add a Result for a TC into the TestRail run
        /// <param name="assembly">Need to provide executed assembly</param>
        /// </summary>
        public static void AddResultTestCase()
        {
            var testCaseId = TestRailHelper.GetTestCaseId();

            SendResultToTestRail(testCaseId, GetStatus(), GetMessage());
        }

        /// <summary>
        /// Add a Result for a TC into the TestRail run
        /// <param name="errorMessage">Error message provided</param>
        /// </summary>
        public static void AddResultTestCase(string errorMessage)
        {
            var testCaseId = TestRailHelper.GetTestCaseId();

            SendResultToTestRail(testCaseId, GetStatus(), errorMessage);
        }

        /// <summary>
        /// Adds a Result for a TC into the TestRail run
        /// </summary>
        /// <param name="scenario"><see cref="ScenarioContext"/></param>
        public static void AddResultTestCaseInTestRail(ScenarioContext scenario)
        {
            var testCaseId = TestRailHelper.GetTestCaseId(scenario.ScenarioInfo.Title);
            Logging.Debug($"Updating the status of '{testCaseId}' test case at TestRail");
            var data = new Dictionary<string, object>();
            UpdateData(data, GetStatus(), GetMessage(), GetException());
            ApiSendResults(testCaseId, data);
        }

        /// <summary>
        /// Get test case status.
        /// </summary>
        /// <returns>Status</returns>
        public static TestStatus GetStatus()
        {
            return SoftAssert.HasErrors() ? TestStatus.Failed : TestContext.CurrentContext.Result.Outcome.Status;
        }

        /// <summary>
        /// Get test case error message.
        /// </summary>
        /// <returns>Error message</returns>
        public static string GetMessage()
        {
            return SoftAssert.HasErrors() ? SoftAssert.GetErrorMessages() : TestContext.CurrentContext.Result.Message;
        }

        /// <summary>
        /// Get test case exception.
        /// </summary>
        /// <returns>Exception</returns>
        public static Exception GetException()
        {
            var exceptionIfNotSoftAssert = ScenarioContext.Current.TestError ?? new Exception(TestContext.CurrentContext.Result.Message);
            return SoftAssert.HasErrors() ? new Exception(GetMessage()) : exceptionIfNotSoftAssert;
        }

        /// <summary>
        /// Updates Data before sending to TR
        /// </summary>
        /// <param name="data">Data to be updated</param>
        /// <param name="testStatus">Test Result</param>
        /// <param name="testErrorMessage">Error type</param>
        /// <param name="error">Error exception</param>
        private static void UpdateData(Dictionary<string, object> data, TestStatus testStatus, string testErrorMessage, Exception error)
        {
            switch (testStatus)
            {
                case TestStatus.Failed:
                    data.Add("status_id", 5);
                    data.Add("comment", $"Type '{error.GetType().Name}', \nMessage: '{error.Message}'");
                    break;
                case TestStatus.Passed:
                    data.Add("status_id", 1);
                    data.Add("comment", "Passed by Automation Framework");
                    break;
                case TestStatus.Skipped:
                    data.Add("status_id", 6);
                    data.Add("comment", $"Skipped by Automation Framework due to: '{testErrorMessage}'");
                    break;
                default:
                    data.Add("status_id", 2);
                    data.Add("comment", $"Blocked by Automation Framework due to: '{testErrorMessage}'");
                    break;
            }
        }


        /// <summary>
        /// Common method to send Results to TestRail
        /// <param name="testCaseId">Int value of TestRail Case Id.</param>
        /// <param name="testResult">Test Result.</param>
        /// <param name="lastError">Exception of executed tests.</param>
        /// </summary>
        public static void SendResultToTestRail(int testCaseId, string testResult, Exception lastError)
        {
            if (EnvironmentManager.GetTestRailRunId() <= 0)
            {
                return;
            }

            var data = new Dictionary<string, object>();

            Logging.Debug($"Updating the status of '{testCaseId}' test case at TestRail");

            if (lastError == null)
            {
                UpdateData(data, testResult, string.Empty, string.Empty);
            }
            else
            {
                UpdateData(data, testResult, lastError.GetType().Name, lastError.Message);
            }

            ApiSendResults(testCaseId, data);
        }

        /// <summary>
        /// Common method to send Results to TestRail
        /// <param name="testCaseId">Int value of TestRail Case Id.</param>
        /// <param name="testResult">Nunit TestStatus</param>
        /// <param name="lastError">Exception of executed tests. Can be null.</param>
        /// </summary>
        public static void SendResultToTestRail(int testCaseId, TestStatus testStatus, string error)
        {
            if (EnvironmentManager.GetTestRailRunId() <= 0)
            {
                return;
            }

            var data = new Dictionary<string, object>();
            Logging.Debug($"Updating the status of '{testCaseId}' test case at TestRail");

            UpdateData(data, testStatus, error);

            ApiSendResults(testCaseId, data);
        }

        /// <summary>
        /// Common method to update a manual test in TestRail
        /// </summary>
        /// <param name="data">Data to be updated</param>
        public static void UpdatedTestcaseInTestRail(IDictionary<string, string> data)
        {
            foreach (var item in data)
            {
                var test = new Dictionary<string, object>();
                test.Add("custom_steps", item.Value);
                ApiSendUpdateTestcase(Convert.ToInt32(item.Key), test);
            }
        }

        /// <summary>
        /// API send Testcase updates to TestRail
        /// </summary>
        /// <param name="testCaseId">Int Case ID</param>
        /// <param name="data">Data to be sent</param>
        private static void ApiSendUpdateTestcase(int testCaseId, IDictionary<string, object> data)
        {
            var endpoint = "update_case/" + testCaseId;

            if (_client == null)
            {
                _client = new APIClient();
            }

            if (testCaseId == 0)
            {
                Logging.Debug($"TestRail Case ID is 0. Return without sending updates");
                return;
            }

            try
            {
                var r = (JObject)_client.SendPost(endpoint, data);
            }
            catch (Exception e)
            {
                Logging.Error($"Error while updating Test Rail Testcase. Error:\n{e.Message}");
            }
        }

        /// <summary>
        /// API send resulst to TestRail
        /// </summary>
        /// <param name="testCaseId">Int Case ID</param>
        /// <param name="data">Data to be sent</param>
        private static void ApiSendResults(int testCaseId, IDictionary<string, object> data)
        {
            var endpoint = "add_result_for_case/" + EnvironmentManager.GetTestRailRunId() + "/" + testCaseId;

            if (_client == null)
            {
                _client = new APIClient();
            }

            if (testCaseId == 0)
            {
                Logging.Debug($"TestRail Case ID is 0. Return without sending any results");
                return;
            }

            try
            {
                var r = (JObject)_client.SendPost(endpoint, data);
            }
            catch (Exception e)
            {
                Logging.Error($"Error while updating Test Rail Run '{EnvironmentManager.GetTestRailRunId()}'. Error:\n{e.Message}");
            }
        }

        /// <summary>
        /// Update Data before sending to TR
        /// </summary>
        /// <param name="data">Data to be updated</param>
        /// <param name="testResult">Test Result</param>
        /// <param name="errorTypeName">Error type</param>
        /// <param name="errorMessage">Error message</param>
        private static void UpdateData(IDictionary<string, object> data, string testResult, string errorTypeName, string errorMessage)
        {
            switch (testResult)
            {
                case "TestError":
                    data.Add("status_id", 5);
                    data.Add("comment", $"Type '{errorTypeName}', \nMessage: '{errorMessage}'");
                    break;
                case "OK":
                    data.Add("status_id", 1);
                    data.Add("comment", "Passed by Automation Framework");
                    break;
                default:
                    data.Add("status_id", 2);
                    data.Add("comment", "Blocked by Automation Framework");
                    break;
            }
        }

        /// <summary>
        /// Update Data before sending to TR
        /// </summary>
        /// <param name="data">Data to be updated</param>
        /// <param name="testStatus">NUnit Test Status</param>
        /// <param name="errorMessage">Error message</param>
        private static void UpdateData(IDictionary<string, object> data, TestStatus testStatus, string errorMessage)
        {
            switch (testStatus)
            {
                case TestStatus.Failed:
                    data.Add("status_id", 5);
                    data.Add("comment", $"Message: '{errorMessage}'");
                    break;
                case TestStatus.Passed:
                    data.Add("status_id", 1);
                    data.Add("comment", "Passed by Automation Framework");
                    break;
                case TestStatus.Skipped:
                    data.Add("status_id", 6);
                    data.Add("comment", $"Skipped by Automation Framework: '{errorMessage}'");
                    break;
                default:
                    data.Add("status_id", 2);
                    data.Add("comment", "Blocked by Automation Framework");
                    break;
            }
        }
    }
}
