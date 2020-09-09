// <copyright file="DashboardSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.Bro
{
    using Euro.Core.Automation.Portals.Pages.Bro;
    using TechTalk.SpecFlow;

    /// <summary>
    /// The steps definitions for the DashboardSteps feature.
    /// </summary>
    [Binding]
    public class DashboardSteps
    {
        private DashboardPage DashboardPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardSteps"/> class.
        /// </summary>
        public DashboardSteps()
        {
            DashboardPage = new DashboardPage();
        }

        [StepDefinition(@"I click on ""(.*)"" option in Dashboard")]
        public void ClickOnOptionInDashboard(string option)
        {
            DashboardPage.ClickOnLknOption(option);
        }
    }
}
