// <copyright file="ScenarioHooks.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Hooks
{
    using System;
    using System.IO;
    using System.Linq;
    using Allure.Commons;
    using Assert;
    using Environment;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using NUnit.Framework.Internal;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using TestRail;
    using Utilities.Context;
    using Utilities.JsonManager;
    using Utilities.Logger;
    using Utilities.Screenshots;
    using Utils;
    using WebDriver;

    /// <summary>
    /// Hooks for actions of a Scenario.
    /// </summary>
    [Binding]
    public class ScenarioHooks : BaseHook
    {
        private string _bugIdForSkippedTest = string.Empty;
        private static AllureLifecycle allure = AllureLifecycle.Instance;

        /// <summary>
        /// Delete file by path.
        /// </summary>
        [AfterScenario]
        [Scope(Tag = "@DeleteFileAfter")]
        public void DeleteFile()
        {
            var tagName = "DeleteFileByPath";
            if (IsNotIgnoreTest() && IsTagByNameExist(tagName))
            {
                var filePathKey = GetParametersForTag(tagName)[0];
                if (!ScenarioContextManager.IsKeyExist(filePathKey))
                {
                    return;
                }

                var filePath = ScenarioContextManager.GetStringValue(filePathKey);
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Gets info of the scenario.
        /// </summary>
        [BeforeScenario(Order = 1)]
        public void GetInfoScenario()
        {
            Logging.Debug($"[========== Scenario Info ==========]");
            Logging.Debug($"Feature: {FeatureContext.Current.FeatureInfo.Title}");
            Logging.Debug($"Scenario: {ScenarioContext.Current.ScenarioInfo.Title}");
        }

        /// <summary>
        /// Skips scenarios which have @skipped tag for both environments.
        /// </summary>
        [BeforeScenario(Order = 1)]
        [Scope(Tag = "@skipped")]
        public void BeforeScenarioSkippedBothEnvironments()
        {
            if (!bool.Parse(EnvironmentManager.GetForceToExecution()))
            {
                TestRailManager.AddResultTestCaseInTestRail(ScenarioContext.Current);
                _bugIdForSkippedTest = TestRailHelper.GetBugIdAssociateToTest(ScenarioContext.Current.ScenarioInfo.Title);
                Assert.Ignore(_bugIdForSkippedTest);
            }
        }

        /// <summary>
        /// Skips scenarios which have @deprecated tag for all environments.
        /// </summary>
        [BeforeScenario(Order = 1)]
        [Scope(Tag = "@deprecated")]
        public void BeforeScenarioDeprecatedAllEnvironments()
        {
            Assert.Ignore("Deprecated test case.");
        }

        /// <summary>
        /// Skips scenarios which have @skipped_rc tag for QA environment.
        /// </summary>
        [BeforeScenario(Order = 1)]
        [Scope(Tag = "@skipped_rc")]
        public void BeforeScenarioSkippedQa()
        {
            IgnoreTestAndAddResultToTestRailIfEnvironment(Environments.Qa);
        }

        /// <summary>
        /// Skips scenarios which have @skipped_master tag for Master environment.
        /// </summary>
        [BeforeScenario(Order = 1)]
        [Scope(Tag = "@skipped_master")]
        public void BeforeScenarioSkippedMaster()
        {
            IgnoreTestAndAddResultToTestRailIfEnvironment(Environments.Master);
        }

        /// <summary>
        /// Skips scenarios which have @skipped_uat tag for UAT environment.
        /// </summary>
        [BeforeScenario(Order = 1)]
        [Scope(Tag = "@skipped_uat")]
        public void BeforeScenarioSkippedUat()
        {
            IgnoreTestAndAddResultToTestRailIfEnvironment(Environments.Uat);
        }

        /// <summary>
        /// Verifies if the browser is responding after any scenario.
        /// </summary>
        [AfterScenario(Order = 1001)]
        public void AfterScenarioBrowserCheck()
        {
            Logging.Debug($"After Scenario - ScenarioHooks : BrowserCheck.");
            if (ScenarioContext.Current.TestError != null && !ScenarioContext.Current.ScenarioInfo.Tags.Contains("api"))
            {
                try
                {
                    Logging.Debug($"Trying to verify if browser respond");
                    WebDriverManager.Instance.GetWebDriver.FindElement(By.CssSelector("html"));
                }
                catch (WebDriverException e) when (e.Message.Contains("The HTTP request to the remote WebDriver server for URL"))
                {
                    Logging.Debug($"Restarting browser because it's not responding {e.GetBaseException()}");
                    WebDriverManager.Instance.RestartWebDriver();
                }
            }
        }

        /// <summary>
        /// Check soft asserts and fail test if has errors.
        /// </summary>
        [AfterScenario(Order = 1)]
        public void AfterScenarioCheckSoftAsserts()
        {
            SoftAssert.AssertAll();
        }

        /// <summary>
        /// Verifies if status after any scenario.
        /// </summary>
        [AfterScenario(Order = 3)]
        public void AfterScenarioRetry()
        {
            var status = TestExecutionContext.CurrentContext.CurrentResult.ResultState;
            var isTestFail = !ResultState.Success.Equals(status) || SoftAssert.HasErrors();
            if (isTestFail && !ResultState.Ignored.Equals(status) && !ScenarioContext.Current.ScenarioInfo.Tags.Contains("api"))
            {
                Logging.Debug($"Added to Retry file: " + TestExecutionContext.CurrentContext.CurrentTest.FullName);
                ReadingAndWritingFiles.AddFailedScenarioToFile(TestExecutionContext.CurrentContext.CurrentTest.FullName);
            }
        }

        /// <summary>
        /// Adds result test case in TestRail.
        /// </summary>
        [AfterScenario(Order = 3)]
        public void AfterScenarioAddResultTestCaseInTestRail()
        {
            Logging.Debug($"Added to result test case in TestRail: {ScenarioContext.Current.ScenarioInfo.Title}");
            TestRailManager.AddResultTestCaseInTestRail(ScenarioContext.Current);
        }

        /// <summary>
        /// Take the Screenshot and attach it to the Allure Report if scenario failed
        /// </summary>
        [AfterScenario(Order = 4)]
        public static void AfterScenarioScreenshot()
        {
            var status = TestExecutionContext.CurrentContext.CurrentResult.ResultState;
            if (!ResultState.Success.Equals(status) && !ResultState.Ignored.Equals(status) && !ScenarioContext.Current.ScenarioInfo.Tags.Contains("api"))
            {
                TakeScreenshot();
            }
        }

        /// <summary>
        /// Take the Screenshot and attach it to the Allure Report
        /// </summary>
        public static void TakeScreenshot()
        {
            if (!ScenarioContext.Current.ScenarioInfo.Tags.Contains("api"))
            {
                var path = string.Empty;
                try
                {
                    var status = TestExecutionContext.CurrentContext.CurrentResult.ResultState;
                    path = ScreenshotHelper.TakeScreenshot();
                    Logging.Debug($"Take Screenshot for Failed scenario: " + path);
                    allure.AddAttachment(path, ScenarioContext.Current.ScenarioInfo.Title);
                }
                catch (Exception e)
                {
                    Logging.Error("Screenshot Error :: " + e.Message);
                    Logging.Info("Path :: " + path);
                }
            }
        }

        /// <summary>
        /// Ignores test due to reason.
        /// </summary>
        /// <param name="environment">Environment where tests are executed.</param>
        private void IgnoreTestAndAddResultToTestRailIfEnvironment(Environments environment)
        {
            if (!bool.Parse(EnvironmentManager.GetForceToExecution()) &&
                EnvironmentManager.GetEnvironmentName().Equals(environment.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                TestRailManager.AddResultTestCaseInTestRail(ScenarioContext.Current);
                _bugIdForSkippedTest =
                    TestRailHelper.GetBugIdAssociateToTest(ScenarioContext.Current.ScenarioInfo.Title);
                Assert.Ignore(_bugIdForSkippedTest);
            }
        }
    }
}
