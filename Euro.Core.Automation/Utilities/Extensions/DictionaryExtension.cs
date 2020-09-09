// <copyright file="DictionaryExtension.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Extensions
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// This class is in charge to extend the dictionary functionality.
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// Gets value from dictionary by provided key
        /// </summary>
        /// <param name="dict">Dictionary from which to get value</param>
        /// <param name="key">Key used to search value in dictionary</param>
        /// <typeparam name="TK">Key in dictionary</typeparam>
        /// <typeparam name="TV">Value in dictionary</typeparam>
        /// <returns>Value from dictionary by defined key</returns>
        public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dict, TK key)
        {
            var trace = new StackTrace(1, true);
            var fileName = trace.GetFrame(0).GetFileName();
            return dict.TryGetValue(key, out var value)
                ? value
                : throw new KeyNotFoundException($"The key '{key}' has not been found in dictionary in file '{fileName}'!");
        }
    }
}
