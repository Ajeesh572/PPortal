// <copyright file="LineFormatter.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Formatter
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class provides methods to handle strings in different languages
    /// </summary>
    public class LineFormatter
    {
        /// <summary>
        /// Gets expected string by it's English line.
        /// </summary>
        /// <param name="lineInEnglish">Line in English</param>
        /// <returns>Returns value in required language via line in English</returns>
        public static string GetExpectedStringViaLineInEnglish(string lineInEnglish)
        {
            var pattern = new Regex("[^0-9a-zA-Z ]+");
            var lineInEnglishWithoutAdditionalCharacters = pattern.Replace(lineInEnglish.Replace("/", " "), string.Empty);
            var keyForTitleInLanguageManager = MakeUppercaseWordsAfterSpace(lineInEnglishWithoutAdditionalCharacters).Replace(" ", string.Empty);
            return LanguageManager.Instance.GetValue(keyForTitleInLanguageManager);
        }

        /// <summary>
        /// Gets string where all letters after space is capitalized.
        /// </summary>
        /// <param name="value">String</param>
        /// <returns>String with uppercase words</returns>
        private static string MakeUppercaseWordsAfterSpace(string value)
        {
            var array = value.ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }

            for (var i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }

                if (array[i - 1] != ' ')
                {
                    array[i] = char.ToLower(array[i]);
                }
            }

            return new string(array);
        }
    }
}
