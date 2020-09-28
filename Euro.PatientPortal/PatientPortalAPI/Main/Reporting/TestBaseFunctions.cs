namespace Euro.CP.Main.Utils
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Repository.Hierarchy;
    using NUnit.Framework;
    using OpenQA.Selenium;

    public class TestBaseFunctions
    {
        #region Variables
        public static string ZephyrCycleId { get; set; }
        public static string ZephyrCycleDescription { get; set; }
        public DriverHandler DriverHandler = new DriverHandler();
        protected IWebDriver driver;
        //private QmetryAPI _qmetryApi = null;
        protected string currentTestName;
        protected string deviationPercentage;
        protected ILog log;
        private static string path;
        #endregion
        public static DateTime SuiteStartTime { get; set; }
        public static string NodeTestMachine { get; set; }

        /// <summary>
        /// Method contains Exception handling functionalities
        /// </summary>
        /// <param name="ex">Exception object</param>
        public static void HandleException(Exception ex)
        {
            Reporting.HasWarningOrError = true;
            if (true)
            {
                string fileName = DriverHandler.TakeGrayscaleScreenShot(string.Format(@"{0}\{1}\{2}", RUtils.LogPath, RUtils.ResultFolder, Reporting.TestCaseFolder));
                Reporting.ErrorMessage = string.Format("<b>Message:</b> '{0}' <br><b>Stack-Trace:</b> '{1}'", ex.Message, ex.StackTrace);
                Reporting.Write(ex, LogContentType.Failed, fileName, Reporting.TxtReport);
            }
            else
            {
                Reporting.Write(ex.Message, LogContentType.Failed, Reporting.TxtReport);
            }

            throw ex;
        }

        //public void IgnoreForSpec()
        //{
        //    string ignoreKeyword = string.Format(
        //        "skip_{0}",
        //        "Chrome".ToString().Substring(0, 2).ToLower());

        //    List<String> testCategories = null;
        //    var properties = TestContext.CurrentContext.Test.Properties as Dictionary<string, List<String>>;
        //    if (properties != null) properties.TryGetValue("_CATEGORIES", out testCategories);
        //    if (testCategories != null && testCategories.Contains(ignoreKeyword))
        //    {
        //        Assert.Ignore();
        //    }
        //}


        public void ConfigureLog4Net()
        {
            XmlConfigurator.Configure();
            Hierarchy h =
            (Hierarchy)LogManager.GetRepository();
            log = LogManager.GetLogger(this.GetType().ToString());
            foreach (IAppender a in h.Root.Appenders)
            {
                if (a is FileAppender)
                {
                    FileAppender fa = (FileAppender)a;
                    // Programmatically set this to the desired location here
                    string logFileLocation = string.Format(@"{0}\{1}\{2}.log", RUtils.LogPath,
                                                           RUtils.ResultFolder, this.GetType().ToString());
                    fa.File = logFileLocation;
                    fa.ActivateOptions();
                    break;
                }
            }
        }

        public void StartLogFileWithTestName()
        {
            Reporting.LogTextSummary(currentTestName, true);
            log = LogManager.GetLogger(currentTestName);
            log.Info("Start of Test: " + currentTestName);
        }

        public void SetDescription()
        {
            MemberInfo[] m = this.GetType().GetMember(currentTestName);
            if (m != null && m.Length > 0)
            {
                var att = (DescriptionAttribute)Attribute.GetCustomAttribute(m[0], typeof(DescriptionAttribute));
                if (att != null)
                    Reporting.Description = att.ToString();
                else
                    Reporting.Description = null;
            }
            else
                Reporting.Description = null;
        }

        protected static void CleanUpPhantomJS()
        {
            foreach (Process process in Process.GetProcessesByName("phantomjs"))
            {
                process.Kill();
            }
        }
    }
}
