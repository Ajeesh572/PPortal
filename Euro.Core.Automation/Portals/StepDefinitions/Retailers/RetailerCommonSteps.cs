// <copyright file="RetailerCommonSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.Retailers
{
    using Euro.Core.Automation.Portals.Pages.Retailers.Components;
    using TechTalk.SpecFlow;

    [Binding]
    public class RetailerCommonSteps
    {
        private RetailerTabComponent TabRetailer;
        private RetailerVerticalTabComponent VerticalTabRetailer;

        public RetailerCommonSteps()
        {
            TabRetailer = new RetailerTabComponent();
            VerticalTabRetailer = new RetailerVerticalTabComponent();
        }

        [StepDefinition(@"I select ""(.*)"" option of ""(.*)"" tab in Retailer portal")]
        [StepDefinition(@"Select ""(.*)"" option of ""(.*)"" tab")]
        public void GivenSelectOptionOfTab(string item, string tab)
        {
            TabRetailer.ClickOnTapOption(tab);

            IRetailerComponent component = new RetailerFactory().CreateRetailerComponent(tab);
            component.ClickOnItem(item);
        }

        [StepDefinition(@"I select ""(.*)"" option for ""(.*)"" vertical tab in Retailer portal")]
        [StepDefinition(@"I select ""(.*)"" option in ""(.*)""")]
        public void ISelectAnOptionInATab(string item, string tab)
        {
            VerticalTabRetailer.ClickOnTapOption(tab);
            IRetailerComponent component = new RetailerFactory().CreateVerticalRetailerComponent(tab);
            component.ClickOnItem(item);
        }

        [Given(@"I select the ""(.*)"" option in retailers tab")]
        public void GivenISelectTheProductOptionInTopMenu(string tab)
        {
            TabRetailer.ClickOnTapOption(tab);
        }
    }
}
