// <copyright file="CssStyleHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.CssHelper
{
    using OpenQA.Selenium;

    /// <summary>
    /// Class provides help for getting/checking CSS styles.
    /// </summary>
    public static class CssStyleHelper
    {
        /// <summary>
        /// Check if provided element has Bold CSS style.
        /// </summary>
        /// <param name="element">Web element.</param>
        /// <returns>Bool if bold.</returns>
        public static bool CheckIfElementIsBold(this IWebElement element)
        {
            var fontWeight = GetComputedValue(element, "font-weight");
            return "bold".Equals(fontWeight) || "bolder".Equals(fontWeight) || (int.TryParse(fontWeight, out int fontWValue) && fontWValue >= 700);
        }

        /// <summary>
        /// Get element`s background color.
        /// </summary>
        /// <param name="element">Web element.</param>
        /// <returns>Background color.</returns>
        public static string GetBackgroundColor(this IWebElement element)
        {
            return GetComputedValue(element, "background-color");
        }

        /// <summary>
        /// Get element`s color.
        /// </summary>
        /// <param name="element">Web element.</param>
        /// <returns>Color.</returns>
        public static string GetColor(this IWebElement element)
        {
            return GetComputedValue(element, "color");
        }

        private static string GetComputedValue(IWebElement element, string computedAttribute)
        {
            var value = element.GetCssValue(computedAttribute);

            return value;
        }
    }
}
