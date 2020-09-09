// <copyright file="ResourceReader.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Euro.Core.Automation.Utilities.Logger;

    /// <summary>
    /// This class handles the resource file.
    /// </summary>
    public static class ResourceReader
    {
        private static string PathAssemby = Path.GetDirectoryName(typeof(ResourceReader).Assembly.Location);

        /// <summary>
        /// Gets the value through key name in resource file.
        /// </summary>
        /// <param name="fileName">The filename of resource file.</param>
        /// <param name="keyName">The key name of resource file.</param>
        /// <returns>The value that to be in the resource file.</returns>
        public static string GetValue(string fileName, string keyName)
        {
            var locators = GetList(fileName);
            if (locators.Contains(keyName))
            {
                return locators[keyName].ToString();
            }

            throw new Exception($"The key '{keyName}' not found in resource file '{fileName}'");
        }

        public static string GetKey(string fileName, string value)
        {
            return GetListByValue(fileName)[value].ToString();
        }

        /// <summary>
        /// Iterates a resx file and transforms it into a dictionary
        /// </summary>
        /// <param name="locatorFile">location of file</param>
        /// <returns>A dictionary with the names and values</returns>
        public static IDictionary GetList(string locatorFile)
        {
            var result = (from item in GetResxFile(locatorFile).Descendants("data")
                         select new
                         {
                             Name = item.Attribute("name").Value,
                             Value = item.Element("value").Value
                         }).ToList();
            Logging.Debug($" **************** BEGIN -- ResourceReader.GetList for {locatorFile} -- BEGIN ******************");
            result.ForEach(row =>
            {
                Logging.Debug($"Name :{row.Name}, Value :{row.Value}");
            });
            Logging.Debug($" **************** END -- ResourceReader.GetList for {locatorFile} -- END******************");
            return result.ToDictionary(n => n.Name, n => n.Value);
        }

        /// <summary>
        /// Iterates a resx file and transforms it into a dictionary
        /// </summary>
        /// <param name="fileName">location of file</param>
        /// <returns>A dictionary with the values and name</returns>
        public static IDictionary GetListByValue(string fileName)
        {
            var resultDictionary = new Dictionary<string, string>();
            var result = from item in GetResxFile(fileName).Descendants("data")
                         select new
                         {
                             Name = item.Attribute("name").Value,
                             Value = item.Element("value").Value
                         };
            foreach (var res in result)
            {
                try
                {
                    resultDictionary.Add(res.Value, res.Name);
                }
                catch (ArgumentException)
                {
                    Logging.Debug($"A key is already present in a dictionary. Tried to add the following key: '{res.Value}'");
                }
            }

            return resultDictionary;
        }

        /// <summary>
        /// Gets the resource file in XDocument format.
        /// </summary>
        /// <param name="fileName">The filename of resource file.</param>
        /// <returns>The XDocument format.</returns>
        private static XDocument GetResxFile(string fileName)
        {
            string resxFilename = SearchFile(PathAssemby, fileName + ".resx");
            if (string.IsNullOrEmpty(resxFilename))
            {
                throw new FileNotFoundException($"File with name {fileName}.resx was not found in '{PathAssemby}' and it subfolders.");
            }

            return XDocument.Load(resxFilename);
        }

        /// <summary>
        /// Searchs the resource file in the project.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="fileNameToSearch">The file name to search.</param>
        /// <returns>The absolute path of resource file.</returns>
        private static string SearchFile(string folderPath, string fileNameToSearch)
        {
            string foundFilePath = null;

            // Get all directories in current directory
            string[] directories = Directory.GetDirectories(folderPath);

            if (directories != null && directories.Length > 0)
            {
                foreach (string dirPath in directories)
                {
                    foundFilePath = SearchFile(dirPath, fileNameToSearch);
                    if (foundFilePath != null)
                    {
                        return foundFilePath;
                    }
                }
            }

            string[] files = Directory.GetFiles(folderPath);
            if (files != null && files.Length > 0)
            {
                foundFilePath = files.FirstOrDefault(filePath =>
                Path.GetFileName(filePath).Equals(fileNameToSearch, System.StringComparison.OrdinalIgnoreCase));
            }

            return foundFilePath;
        }
    }
}
