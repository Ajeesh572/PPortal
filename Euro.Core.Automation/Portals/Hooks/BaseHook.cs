// <copyright file="BaseHook.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Hooks
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using NUnit.Framework.Interfaces;
    using NUnit.Framework.Internal;
    using TechTalk.SpecFlow;

    public abstract class BaseHook
    {
        private static readonly Regex TagWithParametersRegex = new Regex(@"@(?<function>\w+)\((?<params>[^;]*)\)");
        private static readonly Regex ParametersRegex = new Regex(@"(\s?:?\s?'?'[^,]+\(.+?\)''?)|([^,]+)");

        /// <summary>
        /// Gets parameters for tag in scenario.
        /// Example: execute method: GetParametersForTag("CreateRegulatedReceipt"),
        /// For scenario we use tag: @CreateRegulatedReceipt(ReceiptId)
        /// And this method return list with one element: 'ReceipId'
        /// </summary>
        /// <param name="tagName">Tag name without parameters.</param>
        /// <returns>Get list of parameters for tag.</returns>
        protected List<string> GetParametersForTag(string tagName)
        {
            var tagWithParameters = ScenarioContext.Current.ScenarioInfo.Tags.FirstOrDefault(tag => tag.Contains(tagName));
            if (tagWithParameters == null)
            {
                return null;
            }

            var nonParsedParameters = TagWithParametersRegex.Match($"@{tagWithParameters}").Groups["params"].Value;
            return ParametersRegex.Matches(nonParsedParameters).Cast<Match>()
                .Select(item => item.Value.Trim().TrimStart('\'').TrimEnd('\'')).ToList<string>();
        }

        /// <summary>
        /// Gets state that tag for current test exist.
        /// <param name="tagName">Tag name without parameters.</param>
        /// <returns>Bool state, true if exist, false is not exist.</returns>
        protected bool IsTagByNameExist(string tagName) => ScenarioContext.Current.ScenarioInfo.Tags.Any(tag => tag.Contains(tagName));

        /// <summary>
        /// Get state that test marked ignore tag or nor.
        /// </summary>
        /// <returns>Bool state, true if not marked, false marked.</returns>
        protected bool IsNotIgnoreTest() => !ResultState.Ignored.Equals(TestExecutionContext.CurrentContext.CurrentResult.ResultState);
    }
}
