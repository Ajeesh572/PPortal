namespace Euro.CP.Main.Utils
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using TechTalk.SpecFlow;

    [Binding]
    public class TestBaseWithBrowserOpenPerSuite : TestBaseFunctions
    {
        [BeforeScenario(Order = 0)]
        [Scope(Tag = "@LeloMaje")]
        public void SuiteSetup()
        {
            Reporting.Reset();
            Reporting.TestSuiteName = this.GetType().ToString();
            ConfigureLog4Net();
            //CreateZephyrCycle(this.GetType().ToString());
            SuiteStartTime = DateTime.Now;
            log.Debug("test fixture");
        }

        [AfterScenario(Order = 1)]
        [Scope(Tag = "@LeloMajedubara")]
        public void SuiteTearDown()
        {
            Reporting.SuiteTimer.Stop();
            log.Info("GenerateHtmlReport");
            Reporting.GenerateHtmlReport();
            string file = Path.GetTempFileName();
            //UpdateZephyrCycle();
            CleanUpPhantomJS();
        }

        [BeforeScenario(Order = 2)]
        [Scope(Tag = "@HogayaKaam")]
        public void TestSetup()
        {
            //IgnoreForSpec();
            Reporting.ResetDetailedHtmlElement();
            currentTestName = TestContext.CurrentContext.Test.Name;
            if (currentTestName == null)
            {
                currentTestName = "ASAS";
            }
            SetDescription();
            StartLogFileWithTestName();
        }

        [AfterScenario(Order = 0)]
        [Scope(Tag = "@HogayaKaam2")]
        public void TestTearDown()
        {
            //IgnoreForSpec();
            Reporting.TestTimer.Stop();

            if (Reporting.ErrorCount > 0 || TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                Reporting.Write("Test failed on an exception", LogContentType.Failed);

            if (Reporting.HasWarningOrError)
            {
                Reporting.LogTextSummary("No issues found");
            }
            log.Info("End of Test: " + currentTestName);
            string filepath = Reporting.GenerateDetailedHtmlReport(currentTestName);
            log.Info("Before Reporting.Log");
            Reporting.Log(TestContext.CurrentContext, filepath);
            log.Info("Before GetFailedSteps");
            string failedSteps = Reporting.GetFailedSteps();

           // if (true)
                //Assert.IsTrue(false, "This test should pass step(s): " + failedSteps.Substring(1));
        }
    }
}
