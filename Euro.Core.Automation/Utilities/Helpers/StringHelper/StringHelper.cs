// <copyright file="StringHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.StringHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using OpenQA.Selenium;

    /// <summary>
    /// Class that helps working with string.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Gets numbers as string from line with exact number.
        /// </summary>
        /// <param name="notFormattedLines">List with elements</param>>
        /// <param name="item">Number of phone we should get from ths list</param>
        /// <param name="includeSymbols">Parameter that shows should we extract '+' symbol or not</param>
        /// <returns>Phone number</returns>
        public static string GetNumbersFromExactLine(this IList<IWebElement> notFormattedLines, int item, bool includeSymbols = true)
        {
            string formattedLine;
            try
            {
                formattedLine = GetDigitsFromLine(notFormattedLines[item - 1].Text, includeSymbols);
            }
            catch (Exception ex)
            {
                throw new Exception($"The {item} line isn't found");
            }

            return formattedLine;
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="notFormattedLines">List with elements</param>>
        /// <param name="includeSymbols">Parameter that shows should we extract '+' symbol or not</param>
        /// <returns>List with phone numbers</returns>
        public static List<string> GetNumbersFromLines(this IList<IWebElement> notFormattedLines, bool includeSymbols = true)
        {
            return notFormattedLines.Select(notFormattedLine => GetDigitsFromLine(notFormattedLine.Text, includeSymbols)).ToList();
        }

        /// <summary>
        /// Provide an ability to get digits as string from line.
        /// </summary>
        /// <param name="line">Line from which we are getting digits</param>
        /// <param name="includeSymbols">Parameter that shows should we extract '+' symbol or not</param>
        /// <returns>Instance of a class.</returns>
        public static string GetDigitsFromLine(this string line, bool includeSymbols)
        {
            List<char> list = new List<char>();
            foreach (char character in line)
            {
                if (char.IsDigit(character))
                {
                    list.Add(character);
                }
                else if (includeSymbols && char.IsSymbol(character))
                {
                    list.Add(character);
                }
            }

            return new string(list.ToArray());
        }

        /// <summary>
        /// Reduce spaces.
        /// </summary>
        /// <param name="text">Output string</param>
        /// <returns>Converted string.</returns>
        public static string ReduceSpaces(this string text)
        {
            var regex = new Regex("[\\s\\n\\r ]+");
            return regex.Replace(text, " ").Trim();
        }
    }
}
