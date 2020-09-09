// <copyright file="OperationsWithFileInDownloadDirectory.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright

namespace Euro.Core.Automation.Utilities.IO
{
    using System;
    using System.IO;

    /// <summary>
    /// This class provides functions to read and write files.
    /// </summary>
    public class OperationsWithFileInDownloadDirectory
    {
        private static readonly DirectoryInfo MyDocumentsFolder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

        /// <summary>
        /// Waits for file to download
        /// </summary>
        /// <param name="fileName">file Name</param>
        /// <param name="timeOutInSeconds">Time in seconds</param>
        public static void WaitUntilFileIsDownloaded(string fileName, int timeOutInSeconds = 10)
        {
            DateTime breakTime = DateTime.Now.AddSeconds(timeOutInSeconds);
            while (breakTime >= DateTime.Now)
            {
                if (IsFileExistsInDownloadDirectory(fileName))
                {
                    return;
                }
            }

            throw new Exception($"file {fileName} is not downloaded");
        }

        /// <summary>
        /// Checks if file exists in download directory of this windows running instance.
        /// </summary>
        /// <param name="fileName">Name of file including extension</param>
        /// <returns>True if file exists in download directory</returns>
        public static bool IsFileExistsInDownloadDirectory(string fileName)
        {
            bool isFileExists = false;
            if (MyDocumentsFolder.Parent != null)
            {
                string filepath = Path.Combine(MyDocumentsFolder.Parent.FullName, "Downloads", fileName);
                isFileExists = File.Exists(filepath);
            }

            return isFileExists;
        }

        /// <summary>
        /// Deletes the file from download directory of running windows instance.
        /// </summary>
        /// <param name="fileName">Name of file including extension</param>
        public static void DeleteFileInDownloadDirectory(string fileName)
        {
            try
            {
                if (MyDocumentsFolder.Parent != null)
                {
                    if (IsFileExistsInDownloadDirectory(fileName))
                    {
                        string filepath = Path.Combine(MyDocumentsFolder.Parent.FullName, "Downloads", fileName);
                        File.Delete(filepath);
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Boss Revolution Organizer Page was not loaded in the time expected.", exception);
            }
        }

        /// <summary>
        /// Reads the text or csv file from download directory and returns in string format
        /// </summary>
        /// <param name="fileName">Name of file including extension</param>
        /// <returns>returns string</returns>
        public static string ReadFileInDownloadDirectory(string fileName)
        {
            string fileContent = "";
            if (MyDocumentsFolder.Parent != null)
            {
                string filename = Path.Combine(MyDocumentsFolder.Parent.FullName, "Downloads", fileName);
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        fileContent = sr.ReadToEnd();
                    }
                }
            }

            return fileContent;
        }
    }
}
