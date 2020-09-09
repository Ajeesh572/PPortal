// <copyright file="DistributorCommonSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.Distributors
{
    using Euro.Core.Automation.Portals.Pages.Distributor.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class DistributorCommonSteps
    {
        private DistributorTabComponents distributorTabComponents;

        public DistributorCommonSteps()
        {
            distributorTabComponents = new DistributorTabComponents();
        }

        [StepDefinition(@"I select ""(.*)"" option of ""(Tools|Reports|BR University)"" tab in Distributor portal")]
        public void GivenSelectOptionOfTab(string item, string tab)
        {
            distributorTabComponents.ClickOnTapOption(tab);

            IDistributorComponent component = new DistributorFactory().CreateDistributorComponent(tab);
            component.ClickOnItem(item);
        }
    }
}
