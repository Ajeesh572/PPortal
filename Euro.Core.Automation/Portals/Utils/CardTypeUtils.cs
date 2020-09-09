// <copyright file="CardTypeUtils.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Portals.Utils
{
    using System.Collections.Generic;

    /// <summary>
    /// This class contains all Card Types with its respective initials
    /// </summary>
    public class CardTypeUtils
    {
        /// <summary>
        /// Creates a dictionary that contains all Card Types with initials
        /// </summary>
        /// <returns> the dictionary is returned </returns>
        public static Dictionary<string, string> GetCardsTypeDictionary()
        {
            return new Dictionary<string, string>()
            {
                { "A", "Amex" },
                { "D", "Discover" },
                { "M", "Master Card" },
                { "V", "Visa" }
            };
        }
    }

}
