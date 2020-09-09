// <copyright file="CustomAssert.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Assert
{
    using System;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.Formatter;
    using NUnit.Framework;

    /// <summary>
    /// Class that provides custom aserts.
    /// </summary>
    public class CustomAssert
    {
        /// <summary>
        /// Asserts that content on the page is correct.
        /// </summary>
        /// <param name="page">Page on which we are checking content</param>
        /// <param name="contentLabel">Label for content</param>
        public static void ThatContentOnPageIsCorrect(IAssertableComponent page, string contentLabel)
        {
            var actualContentOnUi = page.GetText(contentLabel);
            var expectedContent = LineFormatter.GetExpectedStringViaLineInEnglish(contentLabel);
            AssertThatContentOnUiEqualsExpectedContent(actualContentOnUi, expectedContent);
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
            var message = $"{errorMessage}. Date must be equal: expected '{expectedDate}', but actual: '{actualDate}'";
            SoftAssert.IsTrue(DateTimeUtils.CompareDate(expectedDate, actualDate, maxAccuracy), message);
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
            Assert.That(expected.Equals(actual), $"{errorMessage}. Objects must be equal: expected '{expected}', but actual: '{actual}'");
        }

        /// <summary>
        /// Soft assert test.
        /// </summary>
        /// <param name="partString">Part string for contains.</param>
        /// <param name="fullString">Full string where find part string.</param>
        /// <param name="errorMessage">Error message.</param>
        public static void Contains(string partString, string fullString, string errorMessage)
        {
            Assert.That(fullString.Contains(partString), $"{errorMessage}. Full string: '{fullString}' does not contain: '{partString}'");
        }

        /// <summary>
        /// Asserts that content on UI equals to expected content.
        /// </summary>
        /// <param name="actualContentOnUi">Actual content on UI</param>
        /// <param name="expectedContent">Expected content</param>
        public static void ThatContentOnUiEqualsExpectedContent(string actualContentOnUi, string expectedContent)
        {
            AssertThatContentOnUiEqualsExpectedContent(actualContentOnUi, expectedContent);
        }

        /// <summary>
        /// Asserts element is displayed on UI.
        /// </summary>
        /// <param name="page">Page on which we are checking element</param>
        /// <param name="elementName">Element name</param>
        public static void ThatElementIsDisplayed(IAssertableComponent page, string elementName)
        {
            AssertThatElementIsDisplayed(page, elementName, "element");
        }

        /// <summary>
        /// Asserts element is displayed on UI.
        /// </summary>
        /// <param name="page">Page on which we are checking element</param>
        /// <param name="linkName">Link name</param>
        public static void ThatLinkIsDisplayed(IAssertableComponent page, string linkName)
        {
            AssertThatElementIsDisplayed(page, linkName, "link");
        }

        /// <summary>
        /// Asserts element is displayed on UI.
        /// </summary>
        /// <param name="page">Page on which we are checking element</param>
        /// <param name="buttonName">Button name</param>
        public static void ThatButtonIsDisplayed(IAssertableComponent page, string buttonName)
        {
            AssertThatElementIsDisplayed(page, buttonName, "button");
        }

        /// <summary>
        /// Asserts label text on UI equals to expected one.
        /// </summary>
        /// <param name="actualTextLabelOnUi">Actual label text on UI</param>
        /// <param name="expectedTextLabel">Expected label text</param>
        public static void ThatLabelTextOnUiEqualsExpectedText(string actualTextLabelOnUi, string expectedTextLabel)
        {
            AssertThatLabelTextOnUiEqualsExpectedText(actualTextLabelOnUi, expectedTextLabel);
        }

        /// <summary>
        /// Asserts label text on UI equals to expected one.
        /// </summary>
        /// <param name="page">Page on which we are checking label text</param>
        /// <param name="labelName">Label name from which we are getting text</param>
        public static void ThatLabelTextIsDisplayed(IAssertableComponent page, string labelName)
        {
            var actualTextLabelOnUi = page.GetText(labelName);
            var expectedTextLabel = LineFormatter.GetExpectedStringViaLineInEnglish(labelName);
            AssertThatLabelTextOnUiEqualsExpectedText(actualTextLabelOnUi, expectedTextLabel);
        }

        /// <summary>
        /// Asserts quantity of elements on UI equals to expected one.
        /// </summary>
        /// <param name="page">Page on which we are counting quantity of the same elements</param>
        /// <param name="element">Element name which we are counting</param>
        /// <param name="expectedQuantity">Expected quantity of elements</param>
        public static void ThatQuantityOfSameElementOnUiEqualsExpected(IAssertableComponent page, string element, int expectedQuantity)
        {
            var quantityOfLinksOnUi = page.GetQuantityOfElementsOnUi(element);
            SoftAssert.IsTrue(quantityOfLinksOnUi.Equals(expectedQuantity), $"Quantity of {element} on UI is '{quantityOfLinksOnUi}' but should be '{expectedQuantity}'!");
        }

        /// <summary>
        /// Asserts element is displayed on UI.
        /// </summary>
        /// <param name="section">Section on the page</param>
        public static void ThatSectionIsDisplayed(BasePageSection section)
        {
            SoftAssert.IsTrue(
                section.Displayed,
                $"The section '{section}' isn't displayed on '{section.GetType().Name}' but should be!");
        }

        /// <summary>
        /// Asserts field contains value.
        /// </summary>
        /// <param name="actualValue">Actual value from Ui</param>
        /// <param name="expectedValue">Expected value that should be displayed</param>
        /// <param name="element">Element name</param>
        public static void ThatFieldContainsValue(string actualValue, string expectedValue, string element)
        {
            SoftAssert.AreEquals(actualValue, expectedValue, $"The '{element}' contains value '{actualValue}' but should contain '{expectedValue}'");
        }

        /// <summary>
        /// Asserts value presented in drop down.
        /// </summary>
        /// <param name="isValuePresented">Is value presented in dropDown</param>
        /// <param name="expectedValue">Expected value in drop down</param>
        /// <param name="dropDown">Drop down name</param>
        public static void ThatValueIsPresentedInDropDown(bool isValuePresented, string expectedValue, string dropDown)
        {
            SoftAssert.IsTrue(isValuePresented, $"Value '{expectedValue}' not presented in drop down '{dropDown}' but should be!");
        }

        /// <summary>
        /// Asserts actual value equals expected value.
        /// </summary>
        /// <param name="actualValue">Actual value to compare</param>
        /// <param name="expectedValue">Expected value to compare</param>
        public static void ThatActualValueEqualsExpectedValue(string actualValue, string expectedValue)
        {
            SoftAssert.AreEquals(actualValue, expectedValue, $"Actual value is '{actualValue}' but should be '{expectedValue}'!");
        }

        /// <summary>
        /// Asserts element is displayed on UI.
        /// </summary>
        /// <param name="page">Page on which we are checking element</param>
        /// <param name="elementName">Element name</param>
        /// <param name="whatElementIs">What element it is</param>
        private static void AssertThatElementIsDisplayed(IAssertableComponent page, string elementName, string whatElementIs)
        {
            SoftAssert.IsTrue(
                page.IsElementDisplayed(elementName),
                $"The {whatElementIs} '{elementName}' isn't displayed on '{page.GetType().Name}' but should be!");
        }

        /// <summary>
        /// Asserts that content on UI equals to expected content.
        /// </summary>
        /// <param name="actualContentOnUi">Actual content on UI</param>
        /// <param name="expectedContent">Expected content</param>
        private static void AssertThatContentOnUiEqualsExpectedContent(string actualContentOnUi, string expectedContent)
        {
            SoftAssert.AreEquals(
                actualContentOnUi, expectedContent, $"The content \n '{actualContentOnUi}' \n is shown but should be \n '{expectedContent}'");
        }

        /// <summary>
        /// Asserts label text on UI equals to expected one.
        /// </summary>
        /// <param name="actualTextLabelOnUi">Actual label text on UI</param>
        /// <param name="expectedTextLabel">Expected label text</param>
        private static void AssertThatLabelTextOnUiEqualsExpectedText(string actualTextLabelOnUi, string expectedTextLabel)
        {
            SoftAssert.AreEquals(
                actualTextLabelOnUi, expectedTextLabel, $"The label text \n '{actualTextLabelOnUi}' \n is shown but should be \n '{expectedTextLabel}'");
        }
    }
}
