// <copyright file="CountryUtils.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Utils
{
    using System.Collections.Generic;

    /// <summary>
    /// This class contains all countries with its respective initials
    /// </summary>
    public class CountryUtils
    {
        /// <summary>
        /// Creates a dictionary that contains all countries with initials
        /// </summary>
        /// <returns> the dictionary is returned </returns>
        public static Dictionary<string, string> GetCountryDictionary()
        {
            return new Dictionary<string, string>()
            {
                { "US", "United States of America" }
            };
        }
    }

}
