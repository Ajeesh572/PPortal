// <copyright file="AlertSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions
{
    using System;
    using Euro.Core.Automation.Assert;
    using Euro.Core.Automation.Transformation.Models;
    using Euro.Core.Automation.Utilities;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class AlertSteps
    {
        [StepDefinition(@"I confirm alert")]
        public void ConfirmAlert()
        {
            WebDriverUtils.AcceptAlertIfPresent();
        }

        [Then(@"(?:I )?[Ss]hould see that alert ""(is|is not)"" presented")]
        public void IsAlertPresent(string expectedCondition)
        {
            var isAlertPresented = WebDriverUtils.IsAlertPresent();
            var isAlertExpectedToBeShown = false;
            switch (expectedCondition)
            {
                case "is":
                    isAlertExpectedToBeShown = true;
                    break;
                case "is not":
                    break;
                default:
                    throw new ArgumentException("Expected condition could be only 'is' or 'is not'");
            }

            Assert.That(isAlertPresented.Equals(isAlertExpectedToBeShown), $"Actual value of alert presence is '{isAlertPresented}' but expected '{isAlertExpectedToBeShown}'!");
        }

        [Then(@"The alert has message ""(.*)""")]
        public void CheckAlertHasMessage(StringValue expectedMessage)
        {
            var actualMessage = WebDriverUtils.GetAlertMessage();
            SoftAssert.AreEquals(expectedMessage.Value, actualMessage, "The alert message incorrect.");
        }
    }
}
