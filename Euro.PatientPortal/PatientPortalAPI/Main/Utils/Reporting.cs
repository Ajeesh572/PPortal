// <copyright file="Reporting.cs" company="IDT">
// Copyright (c) IDT. All rights reserved.
// </copyright>

namespace Euro.CP.Main.Utils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using log4net;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;

    /// <summary>
    /// Defines the LogContentType enumeration
    /// </summary>
    public enum LogContentType
    {
        /// <summary>
        /// Image enumeration
        /// </summary>
        ImageLink,

        /// <summary>
        /// Error enumeration
        /// </summary>
        Failed,

        /// <summary>
        /// H1 enumeration
        /// </summary>
        Warning,

        /// <summary>
        /// H2 enumeration
        /// </summary>
        Passed,

        /// <summary>
        /// Title enumeration
        /// </summary>
        Header,

        /// <summary>
        /// Title enumeration
        /// </summary>
        Columns,

        /// <summary>
        /// Info enumeration
        /// </summary>
        Info,

        /// <summary>
        /// Cancelled enumeration
        /// </summary>
        Cancelled
    }

    /// <summary>
    /// Defines the ReportType enumeration
    /// </summary>
    public enum ReportType
    {
        /// <summary>
        /// Suite enumeration
        /// </summary>
        Suite,

        /// <summary>
        /// TestCase enumeration
        /// </summary>
        TestCase,

        /// <summary>
        /// Table enumeration
        /// </summary>
        Table
    }

    /// <summary>
    /// Loggers class methods and properties
    /// </summary>
    public static class Reporting
    {
        #region Variables

        /// <summary>
        /// List of Html test-case Elements
        /// </summary>
        public const string TestCaseFolder = "TestCases";

        /// <summary>
        /// Specflow FeatureName
        /// </summary>
        public static string FeatureName;

        /// <summary>
        /// Dictionary to store the results
        /// </summary>
        // public static Dictionary<string, string> _ResultSets = new Dictionary<string, string>();

        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static List<HtmlElement> _testCaseElements = new List<HtmlElement>();

        private static Dictionary<string, string> _summaryDetails = new Dictionary<string, string>();

        //private static QmetryAPI _qmetryApi;

        /// <summary>
        /// List of detailed test-case Elements
        /// </summary>
        private static List<DetailedHtmlElement> _testStepElements = new List<DetailedHtmlElement>();

        private static List<DetailedHtmlElement> _testImageElements = new List<DetailedHtmlElement>();

        private static StreamWriter _imagewriter = null;

        /// <summary>
        /// Text report writer object
        /// </summary>
        private static StreamWriter _txtwriter = null;

        /// <summary>
        /// HTML report writer object
        /// </summary>
        private static StreamWriter _writer = null;

        /// <summary>
        /// Detailed HTML report writer object
        /// </summary>
        private static StreamWriter _detailedWriter = null;

        /// <summary>
        /// Detailed HTML data Table writer object
        /// </summary>
        private static StreamWriter _tableWriter = null;

        /// <summary>
        /// Timer object to manipulate test execution time.
        /// </summary>
        private static Stopwatch _testTimer = new Stopwatch();

        /// <summary>
        /// Timer object to manipulate suite execution time.
        /// </summary>
        private static Stopwatch _suiteTimer = new Stopwatch();

        private static double _totalExecutionTime = 0;

        private static int _testStepCount = 1;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Error Message
        /// </summary>
        public static string Description { get; set; }

        /// <summary>
        /// Gets or sets the Error Message
        /// </summary>
        public static string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the Results Folder Name
        /// </summary>
        public static string DetailedResultsFolderName { get; set; }

        /// <summary>
        /// Gets or sets the Test Suite Name
        /// </summary>
        public static string TestSuiteName { get; set; }

        /// <summary>
        /// Gets or sets the Timer object
        /// </summary>  
        public static Stopwatch TestTimer
        {
            get
            {
                return _testTimer;
            }

            set
            {
                _testTimer = value;
            }
        }

        /// <summary>
        /// Gets or sets the Timer object
        /// </summary>  
        public static Stopwatch SuiteTimer
        {
            get
            {
                return _suiteTimer;
            }

            set
            {
                _suiteTimer = value;
            }
        }

        /// <summary>
        /// Gets or sets the Test Case Count
        /// </summary>
        public static int TestCaseCount { get; set; }

        /// <summary>
        /// Gets or sets the Failed TestCase Count
        /// </summary>
        public static int FailedTestCaseCount { get; set; }

        /// <summary>
        /// Gets or sets the Pass TestCase Count
        /// </summary>
        public static int PassTestCaseCount { get; set; }

        /// <summary>
        /// Gets or sets the Warning Count
        /// </summary>
        public static int ErrorCount { get; set; }

        /// <summary>
        /// Gets or sets the Warning Count
        /// </summary>
        public static int WarningCount { get; set; }

        /// <summary>
        /// Gets or sets the Test Error Count
        /// </summary>
        public static bool HasWarningOrError { get; set; }

        /// <summary>
        /// Gets or sets the Text report
        /// </summary>
        public static bool TxtReport { get; set; }
        #endregion

        #region Public Methods

        /// <summary>
        /// Method to reset all the counters and element list.
        /// </summary>
        public static void Reset()
        {
            _testCaseElements.Clear();
            _testImageElements.Clear();
            TestCaseCount = 0;
            ErrorCount = 0;
            PassTestCaseCount = 0;
            FailedTestCaseCount = 0;
            WarningCount = 0;
            CheckDirectory();
            _writer = null;
            _detailedWriter = null;
            ResetStopWatch(ref _testTimer);
            SuiteTimer.Stop();
            SuiteTimer.Reset();
            SuiteTimer.Start();
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TextReport"]) &&
                ConfigurationManager.AppSettings["TextReport"].ToLower().Equals("true"))
            {
                TxtReport = true;
                _txtwriter = new StreamWriter(string.Format(@"{0}\{1}\result.txt", RUtils.LogPath, RUtils.ResultFolder));
                if (_txtwriter != null)
                {
                    _txtwriter.WriteLine("SUITE SUMMARY");
                    _txtwriter.WriteLine("_________________________________________________________________");
                    _txtwriter.Close();
                }
            }
            if (!Directory.Exists(string.Format(@"{0}\{1}", RUtils.DownloadsPath, RUtils.ResultFolder)) && TestContext.CurrentContext.Test.FullName.ToUpper().Contains("CMGAEXCELS"))
            {
                Directory.CreateDirectory(string.Format(@"{0}\{1}", RUtils.DownloadsPath, RUtils.ResultFolder));
            }
        }

        /// <summary>
        /// Method to reset the stop watch
        /// </summary>
        /// <param name="watch">StopWatch object</param>
        public static void ResetStopWatch(ref Stopwatch watch)
        {
            watch.Stop();
            watch.Reset();
            watch.Start();
        }

        /// <summary>
        /// Method to reset the Detailed Html Element
        /// </summary>
        public static void ResetDetailedHtmlElement()
        {
            _testStepElements = new List<DetailedHtmlElement>();
            _testStepCount = 1;
            ErrorMessage = "-No Error Message-";
            _testTimer.Stop();
            _testTimer.Reset();
            _testTimer.Start();
            HasWarningOrError = false;
        }

        /// <summary>
        /// Method to reset the writer
        /// </summary>
        public static void ResetWriter()
        {
            _detailedWriter = null;
        }


        /// <summary>
        /// Method to write HTML report Header content.
        /// </summary>
        public static void GenerateHtmlReport()
        {
            string resultFile = string.Format(@"{0}\{1}\result.html", RUtils.LogPath, RUtils.ResultFolder);
            bool fileExisted = File.Exists(resultFile);
            if (fileExisted)
            {
                string text = File.ReadAllText(resultFile);
                text = text.Replace("</body>", string.Empty).Replace("</html>", string.Empty);
                File.WriteAllText(resultFile, text);
            }
            _writer = new StreamWriter(resultFile, true);
            try
            {
                if (!fileExisted)
                {
                    PrepareHtmlHeader(_writer);
                    AddDiv(new HtmlElement(LogContentType.Header, "<HR />"));
                    if (string.IsNullOrEmpty(string.Empty))
                    {
                        AddDiv(new HtmlElement(LogContentType.Header, string.Format("OS Version : {0}", Environment.OSVersion)));
                        AddDiv(new HtmlElement(LogContentType.Header, string.Format("Machine Name : {0}", Environment.MachineName)));
                        AddDiv(new HtmlElement(LogContentType.Header, string.Format("User Domain Name : {0}", Environment.UserDomainName)));
                        AddDiv(new HtmlElement(LogContentType.Header, string.Format("User Name : {0}", Environment.UserName)));
                    }
                    else
                    {
                        AddDiv(new HtmlElement(LogContentType.Header, string.Format("Machine Name : {0}", TestBaseFunctions.NodeTestMachine)));
                    }

                    if (!string.IsNullOrEmpty("1.2"))
                        AddDiv(new HtmlElement(LogContentType.Header, string.Format("Build : {0}", "1.2")));
                    if (!string.IsNullOrEmpty("Ajeesh"))
                        AddDiv(new HtmlElement(LogContentType.Header, string.Format("AppUserName : {0}", "Ajeesh")));
                    if (!string.IsNullOrEmpty("OneApp"))
                        AddDiv(new HtmlElement(LogContentType.Header, string.Format("Site : {0}", "OneApp")));
                    AddDiv(new HtmlElement(LogContentType.Header, string.Format("Browser : {0}", "Chrome")));
                    if (_summaryDetails.Count > 0)
                    {
                        foreach (KeyValuePair<String, String> entry in _summaryDetails)
                        {
                            AddDiv(new HtmlElement(LogContentType.Header, string.Format("{0} : {1}", entry.Key, entry.Value)));
                        }
                    }
                }
                AddDiv(new HtmlElement(LogContentType.Header, string.Format("Duration : {0} Minutes", SuiteTimer.Elapsed.TotalMinutes)));
                AddDiv(new HtmlElement(LogContentType.Header, "<HR />"));
                AddTable(_writer);
                AddTableHeader();
                foreach (HtmlElement testElement in _testCaseElements)
                {
                    AddTableRow(testElement);
                }
                CloseTable(_writer);
                //_totalExecutionTime += SuiteTimer.Elapsed.TotalMinutes;
                //AddDiv(new HtmlElement(LogContentType.Header, string.Format("Total Execution Time : {0} Minutes", _totalExecutionTime)));
                //AddDiv(new HtmlElement(LogContentType.Header, "<HR />"));
                //AddDiv(new HtmlElement(LogContentType.Header, "<HR />"));
                CloseHtml(_writer);
            }
            finally
            {

                if (_writer != null)
                {
                    _writer.Close();
                }

                _writer = null;
            }

            if (TxtReport)
            {
                // Image Snapshot Html page
                _imagewriter = new StreamWriter(string.Format(@"{0}\{1}\snapshot.html", RUtils.LogPath, RUtils.ResultFolder));
                try
                {
                    PrepareHtmlHeader(_imagewriter);
                    AddDiv(new HtmlElement(LogContentType.Header, "<HR />"), _imagewriter);
                    if (string.IsNullOrEmpty(String.Empty))
                    {
                        AddDiv(
                            new HtmlElement(LogContentType.Header,
                                            string.Format("OS Version : {0}", Environment.OSVersion)), _imagewriter);
                        AddDiv(
                            new HtmlElement(LogContentType.Header,
                                            string.Format("Machine Name : {0}", Environment.MachineName)), _imagewriter);
                        AddDiv(
                            new HtmlElement(LogContentType.Header,
                                            string.Format("User Domain Name : {0}", Environment.UserDomainName)),
                            _imagewriter);
                        AddDiv(
                            new HtmlElement(LogContentType.Header,
                                            string.Format("User Name : {0}", Environment.UserName)), _imagewriter);
                    }

                    if (!string.IsNullOrEmpty("1.2"))
                        AddDiv(
                            new HtmlElement(LogContentType.Header,
                                            string.Format("Build : {0}", "1.2".ToString())),
                            _imagewriter);
                    AddDiv(
                        new HtmlElement(LogContentType.Header,
                                        string.Format("Browser : {0}", "Chrome")), _imagewriter);
                    if (_summaryDetails.Count > 0)
                    {
                        foreach (KeyValuePair<String, String> entry in _summaryDetails)
                        {
                            AddDiv(
                                new HtmlElement(LogContentType.Header,
                                                string.Format("{0} : {1}", entry.Key, entry.Value)), _imagewriter);
                        }
                    }
                    AddDiv(
                        new HtmlElement(LogContentType.Header,
                                        string.Format("Duration : {0} Minutes",
                                                      SuiteTimer.Elapsed.TotalMinutes)), _imagewriter);
                    AddDiv(new HtmlElement(LogContentType.Header, "<HR />"), _imagewriter);
                    foreach (DetailedHtmlElement testElement in _testImageElements)
                    {
                        AddImage(testElement);
                    }
                    CloseHtml(_imagewriter);
                }
                finally
                {

                    if (_imagewriter != null)
                    {
                        _imagewriter.Close();
                    }

                    _writer = null;
                }
            }
            _summaryDetails = new Dictionary<string, string>();
        }

        /// <summary>
        /// Method to write Detailed HTML report Header content
        /// </summary>
        public static string GenerateDetailedHtmlReport(string name)
        {
            string filePath = string.Empty;
            DetailedResultsFolderName = Regex.Replace(name, @"[ \/:*?<>""'\\]", string.Empty);
            int pathCount = Path.GetFullPath(string.Format(
                @"{0}\{1}\TestCases",
                RUtils.LogPath,
                RUtils.ResultFolder)).Count();
            if (DetailedResultsFolderName.EndsWith(",null)"))
                DetailedResultsFolderName = DetailedResultsFolderName.Replace(",null)", ")");

            var lengthofCurrentDir = Directory.GetCurrentDirectory().Length;

            var totalfileNameCharLeft = 240 - pathCount;
            if (DetailedResultsFolderName.Length > totalfileNameCharLeft)
            {
                DetailedResultsFolderName = DetailedResultsFolderName.Substring(0, totalfileNameCharLeft);
            }
            filePath = string.Format(
                @"{0}\{1}\TestCases\{2}.html",
                RUtils.LogPath,
                RUtils.ResultFolder,
                DetailedResultsFolderName);

            filePath = Path.GetFullPath(filePath);
            while (File.Exists(filePath))
            {
                filePath = string.Format(
                @"{0}\{1}\TestCases\{2}.html",
                RUtils.LogPath,
                RUtils.ResultFolder,
                DetailedResultsFolderName + "_" + RUtils.GetRandomString(3));
            }

            _detailedWriter = new StreamWriter(filePath);
            try
            {
                PrepareHtmlHeader(_detailedWriter);
                AddDiv(new DetailedHtmlElement(LogContentType.Header, string.Format("<input type='button' value='Back To Summary' onclick='goBack()' />")));
                AddDiv(new DetailedHtmlElement(LogContentType.Header, string.Format("<center><b>{0}</b></center>", DetailedResultsFolderName)));
                AddDiv(new DetailedHtmlElement(LogContentType.Header, "<HR />"));
                if (string.IsNullOrEmpty(String.Empty))
                {
                    AddDiv(new DetailedHtmlElement(LogContentType.Header, string.Format("Test-Case Name : {0}", name)));
                    AddDiv(new DetailedHtmlElement(LogContentType.Header, string.Format("OS Version : {0}", Environment.OSVersion)));
                    AddDiv(new DetailedHtmlElement(LogContentType.Header, string.Format("Machine Name : {0}", Environment.MachineName)));
                    AddDiv(new DetailedHtmlElement(LogContentType.Header, string.Format("User Domain Name : {0}", Environment.UserDomainName)));
                    AddDiv(new DetailedHtmlElement(LogContentType.Header, string.Format("User Name : {0}", Environment.UserName)));
                }
                AddDiv(new DetailedHtmlElement(LogContentType.Header, string.Format("Browser : {0}", "Chrome")));
                AddDiv(new DetailedHtmlElement(LogContentType.Header, string.Format("Site : {0}", "IDT".ToString())));
                if ("1.2" != null)
                    AddDiv(new DetailedHtmlElement(LogContentType.Header,
                        string.Format("Build: {0}", "1.2".ToString())));

                AddDiv(new DetailedHtmlElement(LogContentType.Header, "<HR />"));
                AddTable(_detailedWriter);
                AddTableHeader(ReportType.TestCase);
                foreach (DetailedHtmlElement testElement in _testStepElements)
                {
                    AddTableRow(testElement);
                }
                //ReportingJiraExtension.FindZephyrTestCase(_testStepElements);
                CloseTable(_detailedWriter);
                CloseHtml(_detailedWriter);
            }
            finally
            {
                if (_detailedWriter != null)
                {
                    _detailedWriter.Close();
                }

                _detailedWriter = null;
            }
            return filePath;
        }

        /// <summary>
        /// Method to write the logs
        /// </summary>
        /// <param name="test">TestContext Object</param>
        /// <param name="filePath">Current TestContext Object</param>
        public static void Log(TestContext test, string filePath)
        {
            //remove last one
            if (_testCaseElements.Count > 0 && _testCaseElements[_testCaseElements.Count - 1].TestName.Equals(test.Test.Name))
                _testCaseElements.RemoveAt(_testCaseElements.Count - 1);
            _testCaseElements.Add(new HtmlElement(test, filePath));
        }

        /// <summary>
        /// Method to write the logs
        /// </summary>
        /// <param name="testName">TestContext Object</param>
        /// <param name="errorMessage">Message to be logged</param>
        /// <param name="filePath">Current TestContext Object</param>
        public static void Log(string testName, string errorMessage, string filePath)
        {
            //remove last one
            if (_testCaseElements.Count > 0 && _testCaseElements[_testCaseElements.Count - 1].TestName.Equals(testName))
                _testCaseElements.RemoveAt(_testCaseElements.Count - 1);
            _testCaseElements.Add(new HtmlElement(testName, filePath, errorMessage));
        }

        /// <summary>
        /// Method to write the logs into Html report
        /// </summary>
        /// <param name="msg">Message to be logged</param>
        /// <param name="logContentType">Type of the Log</param>
        public static void Write(string msg, LogContentType logContentType, bool logText = false)
        {
            if ((logContentType == LogContentType.Failed))
            {
                _testStepElements.Add(new DetailedHtmlElement(logContentType, msg, DriverHandler.TakeGrayscaleScreenShot(string.Format(@"{0}\{1}\{2}", RUtils.LogPath, RUtils.ResultFolder, TestCaseFolder))));
            }
            else
                _testStepElements.Add(new DetailedHtmlElement(logContentType, msg));

            if (logText)
            {
                _testImageElements.Add(new DetailedHtmlElement(logContentType, msg));
                if (logContentType.Equals(LogContentType.Failed) || logContentType.Equals(LogContentType.Warning))
                {
                    LogTextSummary(msg);
                }
            }
        }

        /// <summary>
        /// Method to write the logs into Html report with passed messages
        /// </summary>
        /// <param name="description">Message in description section</param>
        /// <param name="logContentType">Type of the Log</param>
        /// <param name="msg">Message in message section</param>
        public static void WriteWMsg(string description, LogContentType logContentType, string msg, bool logText = false)
        {
            DetailedHtmlElement detail = new DetailedHtmlElement(logContentType, description);
            detail.ErrMessage = msg;
            _testStepElements.Add(detail);
            if (logText)
            {
                if (logContentType.Equals(LogContentType.Failed) || logContentType.Equals(LogContentType.Warning))
                {
                    LogTextSummary(description);
                }
            }
        }

        /// <summary>
        /// Method to write the logs into Html report with image taken
        /// </summary>
        /// <param name="description">Message in description section</param>
        /// <param name="logContentType">Type of the Log</param>
        public static void WriteWImg(string description, LogContentType logContentType, bool logText = false)
        {
            string snapshotPath =
                DriverHandler.TakeScreenShot(string.Format(@"{0}\{1}\{2}", RUtils.LogPath, RUtils.ResultFolder,
                                                           TestCaseFolder));
            _testStepElements.Add(new DetailedHtmlElement(logContentType, description, snapshotPath));
            if (logText)
            {
                _testImageElements.Add(new DetailedHtmlElement(logContentType, description, snapshotPath));
                if (logContentType.Equals(LogContentType.Failed) || logContentType.Equals(LogContentType.Warning))
                {
                    LogTextSummary(description);
                }
            }
        }

        /// <summary>
        /// Method to write the logs into table report
        /// </summary>
        /// <param name="msg">Message to be logged</param>
        /// <param name="logContentType">Type of the Log</param>
        /// <param name="table">Table Object</param>
        public static void Write(string msg, LogContentType logContentType, DataTable table, bool logText = false)
        {
            _testStepElements.Add(new DetailedHtmlElement(logContentType, msg, GenerateDataTableReport(table)));
            if (logText)
            {
                if (logContentType.Equals(LogContentType.Failed) || logContentType.Equals(LogContentType.Warning))
                {
                    LogTextSummary(msg);
                }
            }
        }

        /// <summary>
        /// Method to write the logs into table report
        /// </summary>
        /// <param name="msg">Message to be logged</param>
        /// <param name="logContentType">Type of the Log</param>
        /// <param name="reader">SqlDataReader Object</param>
        /// <param name="logText">log to text file instead of html</param>
        public static void Write(string msg, LogContentType logContentType, SqlDataReader reader, bool logText = false)
        {
            var table = new DataTable();
            table.Load(reader);
            Write(msg, logContentType, table);
            if (logText)
            {
                if (logContentType.Equals(LogContentType.Failed) || logContentType.Equals(LogContentType.Warning))
                {
                    LogTextSummary(msg);
                }
            }
        }

        /// <summary>
        /// Method to Log the exception
        /// </summary>
        /// <param name="ex">Exception raised</param>
        /// <param name="logContentType">Type of the Log</param>
        /// /// <param name="imagePath">Path of Image</param>
        public static void Write(Exception ex, LogContentType logContentType, string imagePath, bool logText = false)
        {
            if (ex != null)
            {
                _testStepElements.Add(new DetailedHtmlElement(logContentType, ex.Message, imagePath));
            }
            if (logText)
            {
                if (logContentType.Equals(LogContentType.Failed) || logContentType.Equals(LogContentType.Warning))
                {
                    LogTextSummary(ex.Message);
                }
            }
        }

        public static void WriteWAssertFailWhenNotTrueOrNull(object assertForNotTrueOrNull, string logText)
        {
            if (assertForNotTrueOrNull == null || (assertForNotTrueOrNull.GetType().Equals(typeof(Boolean)) && !(bool)assertForNotTrueOrNull))
            {
                Write(logText, LogContentType.Failed);
                Assert.Fail(logText);
            }
            Write(logText, LogContentType.Passed);
        }

        /// <summary>
        /// Kill the execution if username/site is invalid
        /// </summary>
        public static void WriteWAssertFail(object assertForNotTrueOrNull, string logText)
        {
            if (assertForNotTrueOrNull == null || (assertForNotTrueOrNull.GetType().Equals(typeof(Boolean)) && !(bool)assertForNotTrueOrNull))
            {
                ResetDetailedHtmlElement();
                Write(logText, LogContentType.Failed);
                string filepath = GenerateDetailedHtmlReport(logText);
                Log(TestContext.CurrentContext, filepath);
                DriverHandler.Driver.Quit();
                GenerateHtmlReport();
                //TestBaseFunctions.SendCompleteTestResults("<font color='red'>" + logText + " : FAILED </font>");
                try
                {
                    Process.GetCurrentProcess().Kill();
                }
                catch (Exception rv)
                {
                    Console.Write(rv.StackTrace);
                }
            }
            Write(logText, LogContentType.Passed);
        }

        /// <summary>
        /// Return the strings for all the failure steps
        /// </summary>
        public static string GetFailedSteps()
        {
            string failedSteps = string.Empty;
            for (int stepCount = 0; stepCount < _testStepElements.Count; stepCount++)
            {
                if (_testStepElements[stepCount].ContentType == LogContentType.Failed)
                    failedSteps = failedSteps + ", " + (stepCount + 1).ToString();
            }
            return failedSteps;
        }

        /// <summary>
        /// Method to write add customised summary in Summary report
        /// </summary>
        /// <param name="infoKey">Summary heading to be logged</param>
        /// <param name="infoValue">Summary content to be logged</param>
        public static void AddSummary(string infoKey, string infoValue)
        {
            if (_summaryDetails.ContainsKey(infoKey))
            {
                _summaryDetails[infoKey] = infoValue;
            }
            else
            {
                _summaryDetails.Add(infoKey, infoValue);
            }
        }



        /// <summary>
        /// log to text file
        /// </summary>
        /// <param name="content">content of the summary</param>
        /// <param name="heading">the format is different when it is set to heading or not heading</param>
        public static void LogTextSummary(string content, bool heading = false)
        {
            if (TxtReport)
            {
                _txtwriter = new StreamWriter(string.Format(@"{0}\{1}\result.txt", RUtils.LogPath, RUtils.ResultFolder), true);
                if (_txtwriter != null)
                {
                    if (heading)
                    {
                        _txtwriter.WriteLine(string.Format("::{0}", content));
                    }
                    else
                    {
                        HasWarningOrError = true;
                        _txtwriter.WriteLine(string.Format("   - {0}", content));
                    }
                    _txtwriter.Close();
                }
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method to write Table Data HTML file
        /// </summary>
        private static string GenerateDataTableReport(DataTable table)
        {
            string filePath = string.Empty;
            string fileName = RUtils.GetRandomString(10);
            filePath = string.Format(
                @"{0}\{1}\TestCases\{2}.html",
                RUtils.LogPath,
                RUtils.ResultFolder,
                fileName);

            while (File.Exists(filePath))
            {
                filePath = string.Format(
                @"{0}\{1}\TestCases\{2}.html",
                RUtils.LogPath,
                RUtils.ResultFolder,
                fileName + "_" + RUtils.GetRandomString(3));
            }

            filePath = Path.GetFullPath(filePath);
            _tableWriter = new StreamWriter(filePath);
            try
            {
                PrepareHtmlHeader(_tableWriter);
                _tableWriter.Write("<input type='button' value='Back To Summary' onclick='goBack()' />");
                _tableWriter.Write("<HR />");
                AddTable(_tableWriter);
                ArrayList cols = new ArrayList();
                foreach (DataColumn col in table.Columns)
                {
                    cols.Add(col.ColumnName);
                }
                AddTableHeader(ReportType.Table, cols);

                foreach (DataRow row in table.Rows)
                {
                    _tableWriter.Write("<tr>");
                    foreach (DataColumn col in table.Columns)
                    {
                        _tableWriter.Write(string.Format("<td>{0}</td>", row[col.ColumnName]));
                    }
                    _tableWriter.WriteLine("</tr>");
                }

                CloseTable(_tableWriter);
                CloseHtml(_tableWriter);
            }
            finally
            {
                if (_tableWriter != null)
                {
                    _tableWriter.Close();
                }

                _tableWriter = null;
            }
            return filePath;
        }

        /// <summary>
        /// Method to close the html report.
        /// </summary>
        /// <param name="report">StreamWriter object</param>
        private static void CloseHtml(StreamWriter report)
        {
            report.WriteLine("</body>");
            report.WriteLine("</html>");
        }

        /// <summary>
        /// Method to add a new div node
        /// </summary>
        /// <param name="report">StreamWriter object</param>
        private static void AddTable(StreamWriter report)
        {
            if (report != null)
            {
                report.Write("<table border=5 width=100%>");
            }
        }

        /// <summary>
        /// Method to add a new table node
        /// </summary>
        /// <param name="report">StreamWriter object</param>
        private static void CloseTable(StreamWriter report)
        {
            if (report != null)
            {
                report.Write("</table>");
            }
        }

        /// <summary>
        /// Method to add a new div node
        /// </summary>
        /// <param name="element">Htmlelemnt or DetailedHtmlElement object</param>
        private static void AddTableRow(Object element)
        {
            StreamWriter report = GetWriter(element);
            if (report != null)
            {
                report.Write("<tr class=\"");
                AddContentType(element);
                report.WriteLine("\">");
                AddTableData(element);
                report.WriteLine("</tr>");
            }
        }

        /// <summary>
        /// Method to add a new td
        /// </summary>
        /// <param name="report" >_writer or _detailwriter</param>
        /// <param name="content"> content of the column</param>
        private static void AddTableColmn(StreamWriter report, string content)
        {
            if (report != null)
            {
                report.Write("<td>");
                if (content.Equals(string.Empty))
                    content = "&nbsp";
                report.Write(content);
                report.Write("</td>");
            }
        }

        /// <summary>
        /// Method to decide which writer the method should use depending on the type of element
        /// </summary>
        private static StreamWriter GetWriter(object element)
        {
            if (element.GetType().Name.Equals(typeof(HtmlElement).Name))
            {
                return _writer;
            }
            else if (element.GetType().Name.Equals(typeof(DetailedHtmlElement).Name))
            {
                return _detailedWriter;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Method to add a new div node
        /// </summary>
        /// <param name="reportType">Type of the report been generated</param>
        private static void AddTableHeader(ReportType reportType = ReportType.Suite, ArrayList cols = null)
        {
            StreamWriter report = null;
            string[] columns = { };
            if (reportType.Equals((ReportType.Suite)))
            {
                var element = new HtmlElement(LogContentType.Columns,
                                              "Sl.No:End-Time:Test-Name:Time-Taken:Test-Description:Status:Message");
                columns = element.Text.Split(':');
                report = _writer;
            }
            else if (reportType.Equals((ReportType.TestCase)))
            {
                var element = new DetailedHtmlElement(LogContentType.Columns,
                                                      "Sl.No:Description:Status:Message:Link");
                columns = element.Msg.Split(':');
                report = _detailedWriter;
            }

            else if (reportType.Equals((ReportType.Table)) && cols != null)
            {
                //_tableWriter;
                _tableWriter.Write("<tr class=\"");
                _tableWriter.Write("column");
                _tableWriter.WriteLine("\">");
                foreach (string column in cols)
                {
                    AddTableColmn(_tableWriter, column);
                }
                _tableWriter.WriteLine("</tr>");
            }

            if (report != null)
            {
                report.Write("<tr class=\"");
                report.Write("column");
                report.WriteLine("\">");

                foreach (var column in columns)
                {
                    AddTableColmn(report, column);
                }
                report.WriteLine("</tr>");
            }
        }

        /// <summary>
        /// Method to add a new div node
        /// </summary>
        /// <param name="element">Detailed Html elemnt object</param>
        private static void AddDiv(Object element, StreamWriter writerObject = null)
        {
            StreamWriter report;
            string msg;
            if (writerObject == null)
            {
                if (element.GetType().Name.Equals(typeof(HtmlElement).Name))
                {
                    report = _writer;
                    msg = ((HtmlElement)element).Text;
                }
                else
                {
                    report = _detailedWriter;
                    msg = ((DetailedHtmlElement)element).Msg;
                }
            }
            else
            {
                report = writerObject;
                if (element.GetType().Name.Equals(typeof(HtmlElement).Name))
                {
                    msg = ((HtmlElement)element).Text;
                }
                else
                {
                    msg = ((DetailedHtmlElement)element).Msg;
                }
            }

            if (report != null)
            {
                report.Write("<div class=\"");
                AddContentType(element);
                report.WriteLine("\">");
                report.WriteLine(msg);
                report.WriteLine("</div>");
            }
        }

        /// <summary>
        /// Method to add a new Image node
        /// </summary>
        /// <param name="element">Detailed Html elemnt object</param>
        private static void AddImage(DetailedHtmlElement element)
        {
            if (_imagewriter != null)
            {
                _imagewriter.WriteLine(string.Format("<div>{0}</div>", ((DetailedHtmlElement)element).Msg));
                _imagewriter.WriteLine(string.Format("<image src='TestCases\\{0}'>", Path.GetFileName(element.ImagePath)));
            }
        }

        /// <summary>
        /// Method to add a new div node
        /// </summary>
        /// <param name="element">Html elemnt/DetailedHtmlElement object</param>
        private static void AddTableData(object element)
        {
            if (element.GetType().Name.Equals(typeof(HtmlElement).Name))
                AddTableData((HtmlElement)element);
            else
                AddTableData((DetailedHtmlElement)element);
        }

        /// <summary>
        /// Method to add a new div node
        /// </summary>
        /// <param name="element">Html elemnt object</param>
        private static void AddTableData(HtmlElement element)
        {
            TestCaseCount++;
            if (element.Status == "Failed")
                FailedTestCaseCount++;
            else if (element.Status == "Error")
                ErrorCount++;

            if (_writer != null)
            {
                AddTableColmn(_writer, TestCaseCount.ToString());
                AddTableColmn(_writer, element.CompletionTime);
                AddTableColmn(_writer, "<a href='" + string.Format(@"{0}/{1}", TestCaseFolder, Path.GetFileName(element.TestFileName)) + "'>" + element.TestName + "</a>");
                AddTableColmn(_writer, element.TimeTaken);
                AddTableColmn(_writer, FeatureName + element.TestName);
                AddTableColmn(_writer, element.Status);
                AddTableColmn(_writer, element.Text);
            }
        }

        /// <summary>
        /// Method to add a new div node
        /// </summary>
        /// <param name="element">Html elemnt object</param>
        private static void AddTableData(DetailedHtmlElement element)
        {
            if (_detailedWriter != null)
            {
                AddTableColmn(_detailedWriter, _testStepCount.ToString());
                AddTableColmn(_detailedWriter, element.Msg);
                AddTableColmn(_detailedWriter, element.ContentType.ToString());
                AddTableColmn(_detailedWriter, element.ErrMessage);

                if (!element.ImagePath.Equals(string.Empty))
                {
                    AddTableColmn(_detailedWriter, "<a href=" + Path.GetFileName(element.ImagePath) + ">" + "Click-Link" + "</a>");
                }
                else
                {
                    AddTableColmn(_detailedWriter, string.Empty);
                }
            }
            _testStepCount++;
        }

        /// <summary>
        /// Method to write content type
        /// </summary>
        /// <param name="element">Object of DetailedHtmlElement or HtmlElement</param>
        private static void AddContentType(Object element)
        {
            StreamWriter report;
            LogContentType contentType;
            if (element.GetType().Name.Equals(typeof(DetailedHtmlElement).Name))
            {
                report = _detailedWriter;
                contentType = ((DetailedHtmlElement)element).ContentType;
            }
            else
            {
                report = _writer;
                contentType = ((HtmlElement)element).ContentType;
            }

            switch (contentType)
            {
                case LogContentType.Failed:
                    {
                        report.Write("failed");
                        break;
                    }

                case LogContentType.Passed:
                    {
                        report.Write("passed");
                        break;
                    }

                case LogContentType.Warning:
                    {
                        report.Write("warning");
                        break;
                    }

                case LogContentType.Info:
                    {
                        report.Write("info");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Method to prepare the header
        /// </summary>
        /// <param name="streamWriter"></param>
        private static void PrepareHtmlHeader(StreamWriter streamWriter)
        {
            if (streamWriter != null)
            {
                streamWriter.WriteLine("<html>");
                streamWriter.WriteLine("<head>");
                streamWriter.WriteLine("<title>Test-Report</title>");
                streamWriter.WriteLine("<script>function goBack(){window.history.back()}</script>");
                streamWriter.WriteLine("<style>");
                streamWriter.Write(@"body{
                    color: black;
                }
                div.header {
                    margin-top: 10;
                    margin-bottom: 10;
                    font-size: 16;
                    font-family: Times New Roman;
                    text-align: left;
                }
                tr {
                    font-size:12;
                    margin-top:10;
                    margin-bottom:10;
                    margin-left:10;
                    margin-right:10;
                    font-family:Trebuchet MS;
                    text-align: left;    
                }
                tr.column {
                    background-color:	#E3E4FA;
                }
                tr.failed {
                    color: red;
                }
                tr.warning {
                    color: orange;
                }");
                streamWriter.WriteLine("</style>");
                streamWriter.WriteLine("</head>");
            }
        }

        /// <summary>
        /// Method to verify the Directory structure
        /// </summary>
        private static void CheckDirectory()
        {
            if (!System.IO.Directory.Exists(RUtils.LogPath))
            {
                System.IO.Directory.CreateDirectory(RUtils.LogPath);
            }
            if (string.IsNullOrEmpty(RUtils.ResultFolder))
            {
                RUtils.ResultFolder = string.Format("{0}{1}{2:s}", "IDT", '_', DateTime.Now).Replace(':', '-');
                System.IO.Directory.CreateDirectory(string.Format(@"{0}\{1}", RUtils.LogPath, RUtils.ResultFolder));
                if (Directory.Exists(string.Format(@"{0}\{1}", RUtils.LogPath, RUtils.ResultFolder)))
                    System.IO.Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", RUtils.LogPath, RUtils.ResultFolder, TestCaseFolder));
            }
            if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", RUtils.LogPath, RUtils.ResultFolder, TestCaseFolder)))
            {
                throw new SystemException("Create test case folder failed");
            }
        }


        #endregion

        #region Internal Class
        
        /// <summary>
        /// Internal Html element class
        /// </summary>
        internal class HtmlElement
        {
            public string TestName { get; set; }

            public string TestFileName { get; set; }

            public string TestDesc { get; set; }

            public string CompletionTime { get; set; }

            public string TimeTaken { get; set; }

            public string Status { get; set; }

            public string Text { get; set; }

            public string Link { get; set; }

            /// <summary>
            /// Gets or sets the ContentType
            /// </summary>
            public LogContentType ContentType { get; set; }


            public HtmlElement(string testName, string filepath, string errorMessage)
            {
                TestDesc = testName;
                TestName = testName;
                CompletionTime = DateTime.Now.ToShortTimeString();
                TimeTaken = _testTimer.Elapsed.ToString();
                TestFileName = filepath;
                Text = ErrorMessage;
                var failedSteps = GetFailedSteps();
                if (string.IsNullOrEmpty(errorMessage) && failedSteps.Length.Equals(0))
                {
                    ContentType = LogContentType.Passed;
                }
                else
                {
                    ContentType = LogContentType.Failed;
                    Status = "Failed";
                }
            }

            public HtmlElement(TestContext test, string filepath = "")
            {
                if (!string.IsNullOrEmpty(Description))
                    TestDesc = Description;
                else
                    TestDesc = "-No Description-";

                TestName = test.Test.Name;
                CompletionTime = DateTime.Now.ToShortTimeString();
                TimeTaken = _testTimer.Elapsed.ToString();
                TestFileName = filepath;
                Text = ErrorMessage;

                var resultState = test.Result.Outcome;
                if (resultState.Equals(ResultState.Cancelled))
                {
                    ContentType = LogContentType.Warning;
                    Status = "Cancelled";
                }
                else if (resultState.Equals(ResultState.Error))
                {
                    ContentType = LogContentType.Failed;
                    Status = "Error";
                }
                else if (resultState.Equals(ResultState.Failure))
                {
                    ContentType = LogContentType.Failed;
                    Status = "Error";
                }
                else if (resultState.Equals(ResultState.Ignored))
                {
                    ContentType = LogContentType.Warning;
                    Status = "Ignored";
                }
                else if (resultState.Equals(ResultState.Inconclusive))
                {
                    ContentType = LogContentType.Warning;
                    Status = "Inconclusive";
                }
                else if (resultState.Equals(ResultState.NotRunnable))
                {
                    ContentType = LogContentType.Warning;
                    Status = "NotRunnable";
                }
                else if (resultState.Equals(ResultState.Skipped))
                {
                    ContentType = LogContentType.Warning;
                    Status = "Skipped";
                }
                else if (resultState.Equals(ResultState.Success))
                {
                    ContentType = LogContentType.Passed;
                    Status = "Success";
                    string failedSteps = GetFailedSteps();
                    if (failedSteps.Length > 0)
                    {
                        Status = "Failed";
                        ContentType = LogContentType.Failed;
                        Text = "This test failed at step(s) " + failedSteps.Substring(1);
                    }
                }
            }

            public HtmlElement(LogContentType contentType, string text)
            {
                Text = text;
                ContentType = contentType;
                TimeTaken = _testTimer.Elapsed.ToString();
                Link = text;
            }
        }

        /// <summary>
        /// Internal Html element class
        /// </summary>
        internal class DetailedHtmlElement
        {
            public DetailedHtmlElement(LogContentType headerType, string text, string imagePath = "")
            {
                Msg = text;
                ContentType = headerType;
                ImagePath = imagePath;
                ErrMessage = ErrorMessage;
            }

            /// <summary>
            /// Gets or sets the value of Message
            /// </summary>
            public string Msg { get; set; }

            /// <summary>
            /// Gets or sets the ContentType
            /// </summary>
            public LogContentType ContentType { get; set; }

            /// <summary>
            /// Gets or sets the ImagePath
            /// </summary>
            public string ImagePath { get; set; }

            /// <summary>
            /// Gets or sets the Error Message
            /// </summary>
            public string ErrMessage { get; set; }
        }
        #endregion
    }
}