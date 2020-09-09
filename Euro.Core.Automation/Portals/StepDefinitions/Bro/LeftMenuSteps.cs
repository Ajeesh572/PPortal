// <copyright file="LeftMenuSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.Bro
{
    using Euro.Core.Automation.Portals.Pages.Bro.Components;
    using Euro.Core.Automation.Utilities.Context;
    using TechTalk.SpecFlow;

    /// <summary>
    /// The steps definitions for the LeftMenuSteps.
    /// </summary>
    [Binding]
    public class LeftMenuSteps
    {
        [StepDefinition(@"I select ""(.*)"" option from Left Menu in Bro portal")]
        public void WhenISelectOptionFromLeftMenuInBroPortal(string menu)
        {
            LeftMenuComponent leftMenu = new LeftMenuComponent();
            leftMenu.GoToLeftOption(menu);
        }

        [StepDefinition(@"I select ""(.*)"" option of ""(.*)"" left Menu in Bro portal")]
        public void WhenISelectOptionOfLeftMenuInBroPortal(string subMenu, string menu)
        {
            ScenarioContextManager.SetScenarioContextEntity(subMenu, "submenuName");
            LeftMenuComponent leftMenu = new LeftMenuComponent();
            leftMenu.GoToSubMenuOption(menu, subMenu);
        }
    }
}
