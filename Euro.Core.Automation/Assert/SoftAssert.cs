// <copyright file="SoftAssert.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Assert
{
    using System;
    using Allure.Commons;
    using Euro.Core.Automation.Portals.Hooks;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.Context;
    using NUnit.Framework;

    /// <summary>
    /// Class that provides soft asserts.
    /// </summary>
    public static class SoftAssert
    {
        private const string AllureCurrentTestCaseUiidKey = "AllureCurrentTestCaseUiid";
        private const string HaveFailsTestsKey = "HaveFailsTests";
        private const string ErrorMessagesKey = "ErrorMessages";

        /// <summary>
        /// Soft assert test.
        /// </summary>
        /// <param name="expected">Expected object.</param>
        /// <param name="actual">Actual object.</param>
        /// <param name="errorMessage">Error message.</param>
        public static void AreEqualsIgnoreCase(string expected, string actual, string errorMessage)
        {
            if (!expected.Equals(actual, StringComparison.OrdinalIgnoreCase))
            {
                AddErrorMessage($"{errorMessage}. Objects must be equal: expected '{expected}', but actual: '{actual}'");
            }
        }

        /// <summary>
        /// Soft assert test.
        /// </summary>
        /// <param name="expectedDate">Expected object.</param>
        /// <param name="actualDate">Actual object.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="maxAccuracy">Max accuracy.</param>
        public static void AreEqualsDateAccuracy(string expectedDate, string actualDate, string errorMessage, TimeSpan maxAccuracy)
        {
            if (!DateTimeUtils.CompareDate(expectedDate, actualDate, maxAccuracy))
            {
                AddErrorMessage($"{errorMessage}. Date must be equal: expected '{expectedDate}', but actual: '{actualDate}'");
            }
        }

        /// <summary>
        /// Soft assert test for compare date with default accuracy 2 minutes.
        /// </summary>
        /// <param name="expectedDate">Expected object.</param>
        /// <param name="actualDate">Actual object.</param>
        /// <param name="errorMessage">Error message.</param>
        public static void AreEqualsDateAccuracy(string expectedDate, string actualDate, string errorMessage)
        {
            var maxAccuracy = TimeSpan.FromMinutes(2);
            AreEqualsDateAccuracy(expectedDate, actualDate, errorMessage, maxAccuracy);
        }

        /// <summary>
        /// Soft assert test.
        /// </summary>
        /// <param name="expected">Expected object.</param>
        /// <param name="actual">Actual object.</param>
        /// <param name="errorMessage">Error message.</param>
        public static void AreEquals(object expected, object actual, string errorMessage)
        {
            if (!expected.Equals(actual))
            {
                AddErrorMessage($"{errorMessage}. Objects must be equal: expected '{expected}', but actual: '{actual}'");
            }
        }

        /// <summary>
        /// Soft assert test.
        /// </summary>
        /// <param name="expected">Expected object.</param>
        /// <param name="actual">Actual object.</param>
        /// <param name="errorMessage">Error message.</param>
        public static void AreNotEqual(object expected, object actual, string errorMessage)
        {
            if (expected.Equals(actual))
            {
                AddErrorMessage($"{errorMessage}. Objects must not be equal: expected '{expected}', but actual: '{actual}'");
            }
        }

        /// <summary>
        /// Soft assert test.
        /// </summary>
        /// <param name="condition">Bool condition for check.</param>
        /// <param name="errorMessage">Error message.</param>
        public static void IsTrue(bool condition, string errorMessage)
        {
            if (!condition)
            {
                AddErrorMessage(errorMessage);
            }
        }

        /// <summary>
        /// Soft assert test.
        /// </summary>
        /// <param name="condition">Bool condition for check.</param>
        /// <param name="errorMessage">Error message.</param>
        public static void IsFalse(bool condition, string errorMessage)
        {
            if (condition)
            {
                AddErrorMessage(errorMessage);
            }
        }

        /// <summary>
        /// Soft assert test.
        /// </summary>
        /// <param name="partString">Part string for contains.</param>
        /// <param name="fullString">Full string where find part string.</param>
        /// <param name="errorMessage">Error message.</param>
        public static void Contains(string partString, string fullString, string errorMessage)
        {
            if (!fullString.Contains(partString))
            {
                AddErrorMessage($"{errorMessage}. Full string: '{fullString}' does not contain: '{partString}'");
            }
        }

        /// <summary>
        /// Asserts test with all errors messages.
        /// And delete all errors messages.
        /// </summary>
        public static void AssertAll()
        {
            var errors = GetErrorMessages();
            if (HasErrors())
            {
                AllureLifecycle.Instance.UpdateTestCase(ScenarioContextManager.GetStringValue(AllureCurrentTestCaseUiidKey), testResult => {
                    testResult.status = Status.failed;
                    testResult.statusDetails.message = errors;
                });
                CleanErrorsMessages();
                Assert.Warn(errors);
            }
        }

        /// <summary>
        /// Get state of sort asserts.
        /// </summary>
        /// <returns>Bool state</returns>
        public static bool HasErrors()
        {
            return ScenarioContextManager.IsKeyExist(HaveFailsTestsKey) ? ScenarioContextManager.GetValue<bool>(HaveFailsTestsKey) : false;
        }

        /// <summary>
        /// Delete all errors messages.
        /// </summary>
        public static void CleanErrorsMessages()
        {
            AddOrUpdateValueInContext(HaveFailsTestsKey, false);
            if (ScenarioContextManager.IsKeyExist(ErrorMessagesKey))
            {
                ScenarioContextManager.Remove(ErrorMessagesKey);
            }
        }

        /// <summary>
        /// Get error message.
        /// </summary>
        /// <returns>Error message</returns>
        public static string GetErrorMessages()
        {
            return ScenarioContextManager.IsKeyExist(ErrorMessagesKey) ? ScenarioContextManager.GetStringValue(ErrorMessagesKey) : "Soft assert errors: ";
        }

        private static void AddErrorMessage(string message)
        {
            ScenarioHooks.TakeScreenshot();
            AddOrUpdateValueInContext(HaveFailsTestsKey, true);
            AddOrUpdateValueInContext(ErrorMessagesKey, string.Concat(GetErrorMessages(), Environment.NewLine, message));
            AllureLifecycle.Instance.UpdateTestCase(testResult =>
            {
                ScenarioContextManager.SetStringValue(AllureCurrentTestCaseUiidKey, testResult.uuid);
            });
        }

        private static void AddOrUpdateValueInContext(string key, object value)
        {
            ScenarioContextManager.SetValue(key, value);
        }
    }
}
