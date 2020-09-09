// <copyright file="TopMenuSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.DtcOneApp
{
    using Euro.Core.Automation.Portals.Pages.DtcOneApp.Components;
    using NUnit.Framework.Interfaces;
    using NUnit.Framework.Internal;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Handles the step definition methods for the top menu in DTC OneApp portal
    /// </summary>
    [Binding]
    public class TopMenuSteps
    {
        private TopMenuComponent TopMenuComponent;

        public TopMenuSteps()
        {
            TopMenuComponent = new TopMenuComponent();
        }

        [StepDefinition(@"I select (.*) option in the top menu of DTC portal")]
        public void GivenISelectTheProductOptionInTopMenu(string option)
        {
            TopMenuComponent.GoToTopOption(option);
        }

        [AfterScenario("LogoutDtcOneAppPortal")]
        public static void LogoutDtcOneAppPortal()
        {
            var status = TestExecutionContext.CurrentContext.CurrentResult.ResultState;
            if (!ResultState.Ignored.Equals(status))
            {
                new TopMenuComponent().GoToSignOutOption();
            }
        }

        [StepDefinition(@"I select ""(.*)"" option in ""(.*)"" tab of DTC portal")]
        public void WhenISelectOptionInTabOfDTCPortal(string option, string menu)
        {
            TopMenuComponent.GoToSubOption(menu);
            IDtcOneAppComponent component = new DtcOneAppFactory().CreateDtcOneAppComponent(menu);
            component.ClickOnItem(option);
        }
    }
}
