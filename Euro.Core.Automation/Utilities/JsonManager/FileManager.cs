// <copyright file="FileManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.JsonManager
{
    using System;
    using System.IO;
    using System.Reflection;
    using Logger;

    /// <summary>
    /// Searchs a file in the bin folder and gets its content.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Searchs for the requested file in Debug folder.
        /// </summary>
        /// <param name="fileName">File name with its extention (Name.txt, Name.json, etc).</param>
        /// <returns>Path of requested file.</returns>
        public static string GetFilePath(string fileName)
        {
            string debugPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            if (Directory.GetFiles(new Uri(debugPath).LocalPath, fileName, SearchOption.AllDirectories).Length != 1)
            {
                Logging.Error(fileName + ": Cannot be found in " + debugPath);
                throw new FileNotFoundException("\r\nFile not found.");
            }

            return Directory.GetFiles(new Uri(debugPath).LocalPath, fileName, SearchOption.AllDirectories)[0];
        }

        /// <summary>
        /// Reads Json files by file name.
        /// </summary>
        /// <param name="fileName">File name value as string.</param>
        /// <returns>json file readed as string.</returns>
        public static string ReadJsonFiles(string fileName)
        {
            try
            {
                return File.ReadAllText(GetFilePath(fileName));
            }
            catch (FileNotFoundException ex)
            {
                Logging.Error(ex.ToString());
                return string.Empty;
            }
        }
    }
}
