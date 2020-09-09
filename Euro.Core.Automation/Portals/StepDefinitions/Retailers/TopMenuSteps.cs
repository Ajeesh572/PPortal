// <copyright file = "TopMenuSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.Retailers
{
    using Euro.Core.Automation.Portals.Pages.Retailers.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class TopMenuSteps
    {
        private TopMenuComponent TopMenuComponent;

        public TopMenuSteps()
        {
            TopMenuComponent = new TopMenuComponent();
        }

        [StepDefinition(@"I logout from boss revolution portal")]
        public void LogoutFromBossRevolutionPortal()
        {
            TopMenuComponent.ClickOnBtnLogOut();
        }
    }
}
