// <copyright file="ReadingAndWritingFiles.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Utils
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Castle.Core.Internal;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Euro.Core.Automation.Utilities.Logger;
    using NUnit.Framework;

    /// <summary>
    /// Class that contains the StreamWriter and StreamReader of Project.
    /// </summary>
    public class ReadingAndWritingFiles
    {
        private static string AssemblyPath = EnvironmentManager.AssemblyDirectoryPath;
        private static string path = AssemblyPath + "//failedScenario.txt";
        private static string environmentPath = AssemblyPath + "//allure-results//environment.properties";
        private static string transactionDataPath = AssemblyPath + "//BillingTransactions";
        private static string writeTransactionDataFileName = transactionDataPath + "//{0}-" + DateTime.Today.ToString("d").Replace("/", "-") + ".txt";
        private static string readTransactionDataFileName = transactionDataPath + "//{0}-" + DateTime.Today.AddDays(-1).ToString("d").Replace("/", "-") + ".txt";
        private static string categoriesFileLocation = AssemblyPath + "//categories.json";
        private static string allureResultsFolder = AssemblyPath + "//allure-results//categories.json";
        private Environment Environment;

        /// <summary>
        /// This methods add a new test full name.
        /// </summary>
        /// <param name="currentTestFullName">it is value of the FullName test</param>
        public static void AddFailedScenarioToFile(string currentTestFullName)
        {
            List<string> listFailedScenario = GetListFailedScenario();
            using (StreamWriter file = new StreamWriter(path, append: true))
            {
                if (listFailedScenario.Count != 0)
                {
                    if (!listFailedScenario.Contains(currentTestFullName))
                    {
                        file.WriteLine(currentTestFullName);
                    }
                }
                else
                {
                    file.WriteLine(currentTestFullName);
                }
            }
        }

        /// <summary>
        /// Gets the list failed scenario.
        /// </summary>
        /// <returns>List of Failed Scenarios</returns>
        public static List<string> GetListFailedScenario()
        {
            string line = string.Empty;
            List<string> listFailedScenario = new List<string>();
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        listFailedScenario.Add(line);
                    }
                }
            }

            return listFailedScenario;
        }

        /// <summary>
        /// This methods creates the Environment.propertie file.
        /// </summary>
        /// <param name="project">it is value of the Project Name</param>
        public static void CreateEnvironmentFile(string project)
        {
            var portals = EnvironmentManager.GetPortals();
            var language = TestContext.Parameters.Get("Language");
            var browserResolution = TestContext.Parameters.Get("width") + " x " + TestContext.Parameters.Get("height");

            using (StreamWriter file = new StreamWriter(environmentPath, append: true))
            {
                file.WriteLine("01.Project.Name=" + project);
                file.WriteLine("02.Project.Environment=" + EnvironmentManager.GetEnvironmentName());
                file.WriteLine("03.Browser.Name=" + WebDriverUtils.GetBrowserName());
                file.WriteLine("04.Browser.Version=" + WebDriverUtils.GetBrowserVersion());
                file.WriteLine("05.Browser.Resolution=" + browserResolution);
                var index = 6;

                // temporary check, because not all projects have language property
                if (!language.IsNullOrEmpty())
                {
                    file.WriteLine("06.Portal.Language=" + language);
                    index += 1;
                }

                foreach (Portal portal in portals)
                {
                    file.WriteLine(index.ToString("00") + ".Url." + portal.Name + "=" + portal.Url);
                    index++;
                }
            }
        }

        /// <summary>
        /// Creates  and saves a .txt file with transaction information.
        /// </summary>
        /// <param name="fileName">The value for part of the file name</param>
        /// <param name="transactionData">Contains the transaction data</param>
        public static void SaveTransacionDataFile(string fileName, Dictionary<string, string> transactionData)
        {
            string fullTransactionDataFileName = string.Format(writeTransactionDataFileName, fileName);
            CreatesDirectoryIfNotExists(transactionDataPath);

            if (!File.Exists(fullTransactionDataFileName))
            {
                CreateFileAndSaveInformation(fullTransactionDataFileName, transactionData);
            }
            else
            {
                File.Delete(fullTransactionDataFileName);
                CreateFileAndSaveInformation(fullTransactionDataFileName, transactionData);
            }
        }

        /// <summary>
        /// Creates  and saves a .txt file with information receiven in a Dictionary.
        /// </summary>
        /// <param name="fileName">The name for new file</param>
        /// <param name="content">Contains the information to save in the file</param>
        private static void CreateFileAndSaveInformation(string fileName, Dictionary<string, string> content)
        {
            StreamWriter file;
            using (file = File.CreateText(fileName))
            {
                foreach (var data in content)
                {
                    file.WriteLine(data.Key + "=" + data.Value);
                }
            }
        }

        /// <summary>
        /// Creates  a directory if it does not exist in the path.
        /// </summary>
        /// <param name="path">The directory that will be verified</param>
        private static void CreatesDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Gets the data from transaction data file in a dictionary.
        /// </summary>
        /// <param name="fileName">Part of the file name to read</param>
        /// <returns>A dictionary with the transaction data</returns>
        public static Dictionary<string, string> GetTransactionDataAsDictionary(string fileName)
        {
            string fullTransactionDataFileName = string.Format(readTransactionDataFileName, fileName);
            Dictionary<string, string> transData = new Dictionary<string, string>();
            var lines = File.ReadAllLines(fullTransactionDataFileName);
            foreach (var line in lines)
            {
                var data = line.Split('=');
                transData.Add(data[0], data[1].Replace("$", string.Empty));
            }

            return transData;
        }

        /// <summary>
        /// Verifies if billing file with transaction data exists.
        /// </summary>
        /// <param name="prefixFileName">Part of the file name to search, eg: MTTransactionData, DBPTransactionData</param>
        /// <returns>True if file exists in the expected directory</returns>
        public static bool IsBillingFileCreated(string prefixFileName)
        {
            string fullTransactionDataFileName = string.Format(readTransactionDataFileName, prefixFileName);
            return File.Exists(fullTransactionDataFileName);
        }

        /// <summary>
        /// This methods copies existing allure-categories file into allure-results folder.
        /// </summary>
        public static void CopyFileWithCategoriesIntoAllureResults()
        {
            try
            {
                File.Copy(categoriesFileLocation, allureResultsFolder, true);
                Logging.Info("The file with categories has been copied into allure-results folder");
            }
            catch (Exception)
            {
                Logging.Error("Something went wrong during copying allure-categories file into allure-results folder.\n");
            }
        }
    }
}
