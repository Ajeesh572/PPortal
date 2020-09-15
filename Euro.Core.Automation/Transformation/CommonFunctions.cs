// <copyright file="CommonFunctions.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Transformation
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Euro.Core.Automation.Entities;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.Context;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Newtonsoft.Json;

    /// <summary>
    /// This class contain function which we can execute in gerkhin steps
    /// </summary>
    public static class CommonFunctions
    {
        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specified object.
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="value">The object to format.</param>
        /// <returns>A copy of format in which any format items are replaced by the string representation of value.</returns>
        public static string StringFormat(string format, object value)
        {
            return string.Format(format, value);
        }

        /// <summary>
        /// Get value from ScenarioContext by key .
        /// </summary>
        /// <param name="key">Key for value</param>
        /// <returns>Value from ScenarioContext.</returns>
        public static string GetValueFromContex(string key)
        {
            return ScenarioContextManager.GetStringValue(key);
        }

        /// <summary>
        /// Return current date by format
        /// Example  if current date = "12/07/2018"
        /// We call function DateNow('MM/dd/yyyy') = "12/07/2018"
        /// </summary>
        /// <param name="format">Date format in example it 'MM/dd/yyyy'.</param>
        /// <returns>Get date by format in example it "12/07/2018" .</returns>
        public static string DateNow(string format)
        {
            return DateTime.Now.ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the date in the desired format that differs
        /// from the current day by the parameter, both up and down.
        /// Example if current date = "12/07/2018"
        /// And we call function ShiftDay(2, 'MM/dd/yyyy') = "12/09/2018"
        /// And also we call function ShiftDay(-2, 'MM/dd/yyyy') = "12/05/2018"
        /// </summary>
        /// <param name="day">Shift day.</param>
        /// <param name="format">Date format.</param>
        /// <returns>Get date by format.</returns>
        public static string ShiftDay(string day, string format)
        {
            return DateTime.Now.AddDays(int.Parse(day)).ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Method that gets an entity with user information
        /// </summary>
        /// <param name="portal">name of portal</param>
        /// <param name="userType">type of user</param>
        /// <returns>User Name</returns>
        public static string GetUserNameFromEnvironment(string portal, string userType)
        {
            return EnvironmentManager.GetUser(portal, userType).Name;
        }

        /// <summary>
        /// Method that gets an entity with user information
        /// </summary>
        /// <param name="portal">name of portal</param>
        /// <param name="userType">type of user</param>
        /// <returns>User Password</returns>
        public static string GetUserPasswordFromEnvironment(string portal, string userType)
        {
            return EnvironmentManager.GetUser(portal, userType).Password;
        }

        /// <summary>
        /// Get string by key from language file.
        /// </summary>
        /// <param name="key">Key for string</param>
        /// <returns>The value that to be in the Language file.</returns>
        public static string GetValueFromLangFile(string key)
        {
            return LanguageManager.Instance.GetValue(key);
        }

        /// <summary>
        /// Return current date where zone id Eastern Standard Time by format
        /// Example  if current date = "12/07/2018"
        /// We call function GetServerDateNow('MM/dd/yyyy') = "12/07/2018"
        /// </summary>
        /// <param name="format">Date format in example it 'MM/dd/yyyy'.</param>
        /// <returns>Get date by format in example it "12/07/2018" .</returns>
        public static string GetServerDateNow(string format)
        {
            string zoneId = "Eastern Standard Time";
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(zoneId)).ToString(format);
        }

        /// <summary>
        /// Gets value from json by key.
        /// Example: execute method: GetValueFromJson("RegulatedReceipt.Receipt.Org"),
        /// File name: RegulatedReceipt.json
        /// File content: { "Receipt":{"ProductCategory":"MT","Org":"UTA New Jersey"}}
        /// And this method return string: 'UTA New Jersey'
        /// </summary>
        /// <param name="pathValue">Path for value(first part is file name(to the first point), next is path value in json).</param>
        /// <returns>Value from JSON</returns>
        public static string GetValueFromJson(string pathValue)
        {
            var keys = pathValue.Split('.').ToList();
            var fileName = keys[0];
            keys.RemoveAt(0);
            dynamic json = JsonConvert.DeserializeObject(FileManager.ReadJsonFiles($"{fileName}.json"));
            var value = json;
            keys.ForEach(key => value = value[key]);
            return value;
        }

        /// <summary>
        /// Returns a copy of this string converted to uppercase.
        /// </summary>
        /// <param name="s">String to convert to uppercase</param>
        /// <returns>copy of this string in uppercase</returns>
        public static string ToUpper(string s)
        {
            return s.ToUpper();
        }

        /// <summary>
        /// Returns a copy of this string converted to lowercase.
        /// </summary>
        /// <param name="s">String to convert to lowercase</param>
        /// <returns>copy of this string in lowercase</returns>
        public static string ToLower(string s)
        {
            return s.ToLower();
        }

        /// <summary>
        /// Returns a copy of this string with all leading whitespaces removed
        /// </summary>
        /// <param name="s">String to trim leading whitespaces from</param>
        /// <returns>copy of this string with leading whitespaces removed</returns>
        public static string TrimStart(string s)
        {
            return s.TrimStart();
        }

        /// <summary>
        /// Returns a copy of this string with all trailing whitespaces removed
        /// </summary>
        /// <param name="s">String to trim trailing whitespaces from</param>
        /// <returns>copy of this string with trailing whitespaces removed</returns>
        public static string TrimEnd(string s)
        {
            return s.TrimEnd();
        }

        /// <summary>
        /// Returns a copy of this string with all leading and trailing whitespaces removed
        /// </summary>
        /// <param name="s">String to trim leading and trailing whitespaces from</param>
        /// <returns>copy of this string with leading and trailing whitespaces removed</returns>
        public static string Trim(string s)
        {
            return s.Trim();
        }

        /// <summary>
        /// Gets entity field value from scenario context
        /// </summary>
        /// <param name="entityKey">Key name by which gets entity from scenario context.</param>
        /// <param name="fieldName">Field name by which gets field value from entity.</param>
        /// <returns>Return field value from entity in string format.</returns>
        public static string GetEntityFieldValueFromContext(string entityKey, string fieldName)
        {
            return (string)ScenarioContextManager.GetScenarioContextEntity<BaseEntity>(entityKey)[fieldName];
        }

        /// <summary>
        /// Generate random email address
        /// </summary>
        /// <returns>Return a random email.</returns>
        public static string GenerateRandomEmail()
        {
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(10000);
            string email = $"username{randomInt}@test.test";
            return email;
        }

        /// <summary>
        /// Generate random email address
        /// </summary>
        /// <param name="domain">reguired domain</param>
        /// <returns>Return a random email.</returns>
        public static string GenerateRandomEmailWithDomain(string domain)
        {
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000000);
            string email = $"user{randomInt}@{domain}";
            return email;
        }

        /// <summary>
        /// Generate random Phone Number
        /// </summary>
        /// <returns>Return a random phone Number.</returns>
        public static string GetRandomPhoneNumber()
        {
            var random = new Random();
            var prefix = random.Next(2, 10).ToString();
            var longPart = ((long)(random.NextDouble() * 900000000) + 100000000).ToString();
            return $"{prefix}{longPart}";
        }
    }
}
