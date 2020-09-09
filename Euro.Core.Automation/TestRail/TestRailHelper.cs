using System.Reflection;
using Euro.Core.Automation.TestRail.Attribute;
using NUnit.Framework;

namespace Euro.Core.Automation.TestRail
{
    using System;
    using System.Text.RegularExpressions;
    using Utilities.Logger;

    /// <summary>
    /// Helper class for Test Rail integration
    /// </summary>
    public class TestRailHelper
    {
        /// <summary>
        /// Get the ID of Test cases of Scenario name
        /// </summary>
        /// <param name="title">Full Title of Scenario</param>
        /// <returns>ID of Test case</returns>
        public static int GetTestCaseId(string title)
        {
            var regex = new Regex(@"(?:C)(\d+)");
            var match = regex.Match(title);
            if (match.Success)
            {
                var id = match.Groups[1].Value;
                Logging.Debug($"Found Match for {match.Value}");
                Logging.Debug($"TestRail ID is '{id}'");
                return int.Parse(id);
            }

            return -1;
        }

        /// <summary>
        /// Gets the Bug id associated to test cases in the scenario title which is at the end of it with the format (BUG:MT-101)
        /// </summary>
        /// <param name="title">Full Title of Scenario</param>
        /// <returns>Bug id, for example MT-101</returns>
        public static string GetBugIdAssociateToTest(string title)
        {
            var regex = new Regex(@"\(([^)]*)\)");
            var match = regex.Match(title);
            if (match.Success)
            {
                return match.Groups[1].Value.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// Get the ID of Test cases of Attribute
        /// </summary>
        /// <returns>ID of Test case</returns>
        public static int GetTestCaseId()
        {
            Logging.Debug("Get Id from TestRail Attribute");
            var caseId = TestContext.CurrentContext.Test.Properties.Get("TestRailId") != null? (int)TestContext.CurrentContext.Test.Properties.Get("TestRailId") : 0;

            return caseId;
        }
    }
}
