// <copyright file="CommonSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions
{
    using System;
    using System.Linq;
    using Euro.Core.Automation.Portals.Pages.Common;
    using Euro.Core.Automation.Portals.Utils;
    using Euro.Core.Automation.Transformation;
    using Euro.Core.Automation.Transformation.Models;
    using Euro.Core.Automation.Utilities;
    using Euro.Core.Automation.Utilities.Context;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class that handles common steps on diferentes portals.
    /// </summary>
    [Binding]
    public class CommonSteps
    {
        private PortalWeb CurrentPortalWeb;
        private PortalPageTransporter PageTransporter;

        [StepDefinition(@"I go to main page of ""(.*)"" portal")]
        public void GoToMainPageOfPortal(string portalWeb)
        {
            FeatureContext.Current["Portal"] = portalWeb;
            CurrentPortalWeb = (PortalWeb)Enum.Parse(typeof(PortalWeb), portalWeb);
            PageTransporter = PortalPageTransporter.Instance;

            // Navigate to login portal web
            PageTransporter.NavigateMainPortalWeb(CurrentPortalWeb);
        }

        [StepDefinition(@"I open new tab")]
        public void OpenNewTab()
        {
            WebDriverUtils.OpenNewTabAndSwitchToIt();
        }

        [StepDefinition(@"I return to first tab")]
        public void ReturnToFirstTab()
        {
            WebDriverUtils.CloseTabAndBackToFirstDriver();
        }

        [StepDefinition(@"I switch to last tab")]
        public void SwitchToLastTab()
        {
            WebDriverUtils.SwitchToLastTab();
        }

        [StepDefinition(@"I save value ""(.*)"" by key with name ""(.*)""")]
        public void SaveValueByKeyWithName(StringValue value, StringValue key)
        {
            ScenarioContextManager.SetStringValue(key.Value, value.Value);
        }

        [StepDefinition(@"I choose Random Value from following table and remember by key ""(.*)"":")]
        public void ChooseRandomFromFollowingAndRememberByKey(StringValue key, Table table)
        {
            var transformedTable = table.TransformTable();
            var values = transformedTable.Rows.Select(row => row[row.Keys.First()]).ToList();
            Random random = new Random();
            ScenarioContextManager.SetStringValue(key.Value, values[random.Next(values.Count())]);
        }

        [StepDefinition(@"I reformat the date ""(.*)"" with current date format ""(.*)"" to new date format ""(.*)"" into ""(.*)""")]
        public void ReformatDate(StringValue date, StringValue currentFormat, StringValue newFormat, string variableName)
        {
            string reformatted = DateTimeUtils.ReformatDate(date.Value, currentFormat.Value, newFormat.Value);
            ScenarioContextManager.SetStringValue(variableName, reformatted);
        }

        [StepDefinition(@"I switch to tab contains URL ""(.*)""")]
        public void SwitchToTabContainsURL(string urlpart)
        {
            WebDriverUtils.SwitchToExactWindowByUrlPartAndStay(urlpart);
        }

        [Then(@"The opened url ""(contains|end with)"" following string ""(.*)""")]
        public void CheckUrl(string action, string urlPart)
        {
            var currentUrl = WebDriverUtils.GetUrl();
            var expectedConditionWithUrl = false;
            switch (action)
            {
                case "contains":
                    expectedConditionWithUrl = currentUrl.Contains(urlPart);
                    break;
                case "end with":
                    expectedConditionWithUrl = currentUrl.EndsWith(urlPart);
                    break;
                default:
                    throw new ArgumentException("The action with url can be only: 'contains' or 'end with'!");
            }

            Assert.True(expectedConditionWithUrl, $"The url should '{action}' the next url part '{urlPart}' but it isn't! Current url is '{currentUrl}'");
        }
    }
}
