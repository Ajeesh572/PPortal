// <copyright file="DtcOneAppHomeSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.DtcOneApp
{
    using Euro.Core.Automation.Portals.Pages.DtcOneApp.HomePages;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Handles the step definition methods for Home page of DTC OneApp portal
    /// </summary>
    [Binding]
    public class DtcOneAppHomeSteps
    {
        private DtcOneAppHomePage HomePage;

        public DtcOneAppHomeSteps()
        {
            HomePage = new DtcOneAppHomePage();
        }

        [Then(@"the Home page in DTC OneApp portal should be displayed")]
        public void TheHomePageInDTCOneAppPortalShouldBeDisplayed()
        {
            Assert.True(HomePage.IsHomePage(), "Error: The Home page of DTC OneApp portal is not displayed");
        }
    }
}
