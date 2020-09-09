// <copyright file="Utils.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text.RegularExpressions;
    using Euro.Core.Automation.Transformation;
    using Euro.Core.Automation.Utilities.Logger;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;

    public static class Utils
    {
        /// <summary>
        /// Find a Locator based on ResX file.
        /// GetByLocator("Name of Resx file", "Locator key", "Value 1", "Value 2", "Value #")
        /// </summary>
        /// <param name="resxfile">Name of Resx file</param>
        /// <param name="locatorKey">Key value to find a locator in Resx file</param>
        /// <param name="values">Parameters</param>
        /// <returns>By Locator</returns>
        public static By GetByLocator(string resxfile, string locatorKey, params string[] values)
        {
            string fullLocator = ResourceReader.GetValue(resxfile, locatorKey);
            string[] locatorParts = fullLocator.Split(new char[] { '_' }, 2);
            string locatorType = locatorParts[0];
            string locatorValue = locatorParts[1].Substring(1, locatorParts[1].Length - 1);
            locatorValue = AddParameters(locatorValue, values);

            switch (locatorType)
            {
                case "id":
                    return By.Id(locatorValue);
                case "name":
                    return By.Name(locatorValue);
                case "tagname":
                    return By.TagName(locatorValue);
                case "classname":
                    return By.ClassName(locatorValue);
                case "css":
                    return By.CssSelector(locatorValue);
                case "link":
                    return By.LinkText(locatorValue);
                case "partiallink":
                    return By.PartialLinkText(locatorValue);
                case "xpath":
                    return By.XPath(locatorValue);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Converts from table to dictionary.
        /// </summary>
        /// <typeparam name="T1"><see cref="T1"/></typeparam>
        /// <param name="table"><see cref="Table"/></param>
        /// <returns><seealso cref="Dictionary<T1, String>"/></returns>
        public static Dictionary<T1, string> ToDictionary<T1>(Table table)
        {
            var dictionary = new Dictionary<T1, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add((T1)System.Enum.Parse(typeof(T1), row[0].ToUpper(), true), row[1]);
            }

            return dictionary;
        }

        /// <summary>
        /// Converts from class to dictionary.
        /// </summary>
        /// <typeparam name="T1"><see cref="T1"/></typeparam>
        /// <param name="t"><see cref="object"/></param>
        /// <returns><seealso cref="Dictionary<T1, String>"/></returns>
        public static Dictionary<T1, string> ToDictionary<T1>(object t)
        {
            var dictionary = new Dictionary<T1, string>();
            foreach (var prop in t.GetType().GetProperties())
            {
                string propertyValue = prop.GetValue(t, null).ToString();
                if (!string.IsNullOrWhiteSpace(propertyValue))
                {
                    dictionary.Add((T1)System.Enum.Parse(typeof(T1), prop.Name.ToUpper(), true), propertyValue);
                }
            }

            return dictionary;
        }

        /// <summary>
        /// Obtains only numbers string of phone number for example (xxx) xxx-xxxx -> xxxxxxxxxx.
        /// </summary>
        /// <param name="phoneNumber">The phone number to convert.</param>
        /// <returns>The number.</returns>
        public static String FromPhoneNumberToNumber(string phoneNumber)
        {
            return Regex.Replace(phoneNumber, @"^\((.*)\) (.*)\-(.*)", "$1$2$3");
        }

        /// <summary>
        /// Removes the spaces from a given text.
        /// </summary>
        /// <param name="text">The text from which all the spaces will be deleted.</param>
        /// <returns>The text without spaces.</returns>
        public static string RemoveSpacesFromTheText(string text)
        {
            string space = " ";

            return text.Contains(space) ? text.Replace(space, string.Empty) : text;
        }

        /// <summary>
        /// Obtains a random string by giving length value.
        /// </summary>
        /// <param name="characters">It's the characters</param>
        /// <param name="length">It's the length of the required random string.</param>
        /// <returns>Random string.</returns>
        public static string GenerateRandom(string characters, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(characters, length)
                .Select(generateString => generateString[random.Next(generateString.Length)]).ToArray());
        }

        /// <summary>
        /// Obtains a random alphanumeric string by giving length value.
        /// </summary>
        /// <param name="length"> It's the length of the required random string.</param>
        /// <returns> Random string.</returns>
        public static string GenerateRandomString(int length)
        {
            return GenerateRandom("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length);
        }

        /// <summary>
        /// Obtains a random string with alphabet letters by giving length value.
        /// </summary>
        /// <param name="length"> It's the length of the required random string.</param>
        /// <returns> Random string.</returns>
        public static string GenerateRandomAlphabetLetters(int length)
        {
            return GenerateRandom("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length);
        }

        /// <summary>
        /// Gets a random number between min and max value received, in string format.
        /// </summary>
        /// <param name="minValue">Is the minimum value to generate with random function</param>
        /// <param name="maxValue">Is the maximum value to generate with random function</param>
        /// <returns>An int number in string format</returns>
        public static string GetRandomNumberAsString(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue).ToString();
        }

        /// <summary>
        /// Method that adds parameters to locators
        /// i.e. xpath__//span[contains(text(),'{0}')]/strong[text()='{1}']
        /// </summary>
        /// <param name="locatorValue">Value of Locator</param>
        /// <param name="values">Values to be added</param>
        /// <returns>Locator modified</returns>
        private static string AddParameters(string locatorValue, string[] values)
        {
            if (values.Length > 0)
            {
                List<string> parameters = new List<string>();
                foreach (string value in values)
                {
                    parameters.Add(value);
                }

                locatorValue = string.Format(locatorValue, parameters.ToArray());
            }

            return locatorValue;
        }

        /// <summary>
        /// Gets the text of a list of web elements in a list.
        /// </summary>
        /// <param name="webElementsList">Is a list of web elements</param>
        /// <returns>A list with the text contained in the web elements.</returns>
        public static List<string> GetTextFromAListOfWebElements(IList<IWebElement> webElementsList)
        {
            List<string> textList = new List<string>();
            foreach (IWebElement element in webElementsList)
            {
                textList.Add(element.Text);
            }

            return textList;
        }

        /// <summary>
        /// Get the value of the Year.
        /// </summary>
        /// <param name="year">The value for the year field.</param>
        /// <returns>The year.</returns>
        public static string GetValueYear(string year)
        {
            return year == "Current Year" ? DateTime.Now.Year.ToString() : year;
        }

        /// <summary>
        ///  Handles the exception for a method.
        /// </summary>
        /// <param name="method">The method for the control a exception.</param>
        /// <param name="errorMessage">The error message for the log.</param>
        public static void HandleException(Action method, string errorMessage)
        {
            try
            {
                Logging.Error($"Entered the method for exception handler");
                method();
            }
            catch (Exception ex)
            {
                Logging.Error($"{errorMessage} {ex}");
            }
        }

        /// <summary>
        /// Gets a specific abbreviation of a language
        /// </summary>
        /// <param name="language">language</param>
        /// <returns>string the abbreviation</returns>
        public static string GetAbbreviationLanguage(string language)
        {
            Dictionary<string, string> elementNames = new Dictionary<string, string>
            {
                { "SPANISH", "ES" },
                { "ENGLISH", "EN" }
            };
            return elementNames[language.ToUpper()];
        }

        /// <summary>
        /// Gets a list of ips of machine.
        /// </summary>
        /// <param name="type">Type of network interface.</param>
        /// <returns>A list of string of ips.</returns>
        public static List<string> GetAllLocalIPv4(NetworkInterfaceType type)
        {
            List<string> ipAddrList = new List<string>();
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddrList.Add(ip.Address.ToString());
                        }
                    }
                }
            }

            return ipAddrList;
        }

        /// <summary>
        /// Print values of an object in the log by current step definition.
        /// </summary>
        /// <param name="objectData">object</param>
        public static void PrintValuesOfObjectInTheLogByCurrentStepDefinition(object objectData)
        {
            try
            {
                if (objectData != null)
                {
                    Logging.Debug(string.Format(
                                    "Step Definition : '{0}' of Scenario '{1}'",
                                    ScenarioContext.Current.StepContext.StepInfo.Text,
                                    ScenarioContext.Current.ScenarioInfo.Title));
                    Logging.Debug($"Values of '{objectData.GetType().Name}");
                    Logging.Debug(string.Join(" - ", objectData.GetType()
                                                   .GetProperties()
                                                   .Where(field => field.GetValue(objectData) != null)
                                                   .Select(field => $"{field.Name}: {field.GetValue(objectData)}")));
                }
            }
            catch (Exception error)
            {
                Logging.Debug($"Error in the method PrintValuesOfObjectInTheLogByCurrentStepDefinition: {error}'");
            }
        }

        /// <summary>
        /// Get the value of the Month.
        /// </summary>
        /// <returns>The month.</returns>
        public static int GetCurrentMonth()
        {
            DateTime dateTime = DateTime.Now;
            return dateTime.Month;
        }

        /// <summary>
        /// Method to create a dictionary of two column spec flow table
        /// </summary>
        /// <param name="specFlowTable">Spec flow Data table</param>
        /// <returns>dictionary of type (string,string).</returns>
        public static IDictionary<string, string> ToDictionary(this Table specFlowTable)
        {
            specFlowTable = specFlowTable.TransformTable();

            Dictionary<string, string> searchData = new Dictionary<string, string>();
            foreach (var criteria in specFlowTable.Rows)
            {
                string fieldName = criteria[0];
                string fieldValue = criteria[1];
                searchData.Add(fieldName, fieldValue);
            }

            return searchData;
        }
    }
}
