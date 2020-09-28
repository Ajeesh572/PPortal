

namespace Euro.PatientPortal.PatientPortalAPI.Main.Reporting
{
    using System;
    using System.IO;
    using Euro.CP.Main.Utils;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using TechTalk.SpecFlow;

    [TestFixture]
    public class TestBaseWithBrowserOpenPerSuite : TestBaseFunctions
    {
        [OneTimeSetUp]
        public void SuiteSetup()
        {
            //Reporting.Reset();
            //Reporting.TestSuiteName = this.GetType().ToString();
            //ConfigureLog4Net();
            //SuiteStartTime = DateTime.Now;
            //log.Debug("test fixture");
        }

        [OneTimeTearDown]
        public void SuiteTearDown()
        {
            //Reporting.SuiteTimer.Stop();
            //log.Info("GenerateHtmlReport");
            //Reporting.GenerateHtmlReport();
            //string file = Path.GetTempFileName();
            //File.Delete(file);
            ////UpdateZephyrCycle();
            //CleanUpPhantomJS();
        }

        [SetUp]
        public void TestSetup()
        {
            ////IgnoreForSpec();
            //Reporting.ResetDetailedHtmlElement();
            //currentTestName = TestContext.CurrentContext.Test.Name;
            //SetDescription();
            //StartLogFileWithTestName();
        }

        [TearDown]
        public void TestTearDown()
        {
        //    //IgnoreForSpec();
        //    Reporting.TestTimer.Stop();

        //    if (Reporting.ErrorCount > 0 || TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        //        Reporting.Write("Test failed on an exception", LogContentType.Failed);

        //    if (Reporting.HasWarningOrError)
        //    {
        //        Reporting.LogTextSummary("No issues found");
        //    }
        //    log.Info("End of Test: " + currentTestName);
        //    string filepath = Reporting.GenerateDetailedHtmlReport(currentTestName);
        //    log.Info("Before Reporting.Log");
        //    Reporting.Log(TestContext.CurrentContext, filepath);
        //    log.Info("Before GetFailedSteps");
        //    string failedSteps = Reporting.GetFailedSteps();

        //    if (failedSteps != string.Empty)
        //        Assert.IsTrue(false, "This test should pass step(s): " + failedSteps.Substring(1));
        }
    }
}
