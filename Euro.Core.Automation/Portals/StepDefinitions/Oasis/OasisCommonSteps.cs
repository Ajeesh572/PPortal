// <copyright file="OasisCommonSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.Oasis
{
    using System.Collections.Generic;
    using Euro.Core.Automation.Portals.Pages.Oasis;
    using Euro.Core.Automation.Portals.Pages.Oasis.Components;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class that handles common steps on Oasis portal.
    /// </summary>
    [Binding]
    public sealed class OasisCommonSteps
    {
        TopMenuComponent OasisTopMenu;
        OasisRouteTopMenuComponent OasisRouteTopMenu;
        BrbBillsPage BrbBillsPage;
        SetFilterPopUp SetFilterPopUp;

        public OasisCommonSteps()
        {
            OasisTopMenu = new TopMenuComponent();
            OasisRouteTopMenu = new OasisRouteTopMenuComponent();
        }

        [StepDefinition(@"I select ""(.*)"" option of ""(.*)"" tab in Oasis Portal")]
        public void SelectOptionOfTabInOasisPortal(string item, string tab)
        {
            OasisTopMenu.ClickOnTapOption(tab);
            IOasisComponent component = OasisFactory.CreateOasisComponent(tab);
            component.ClickOnItem(item);
        }

        [StepDefinition(@"I select ""([^""]*)"" tab in Oasis Route Portal")]
        public void SelectTabInOasisRoutePortal(string tab)
        {
            OasisRouteTopMenu.ClickOnTabOption(tab);
        }

        [StepDefinition(@"I select ""([^""]*)"" option of ""(.*)"" tab in Oasis Route Portal")]
        public void SelectOptionOfTabInOasisRoutePortal(string item, string tab)
        {
            OasisRouteTopMenu.HoverOverElement(tab);
            IOasisComponent component = OasisFactory.CreateOasisRouteComponent(tab);
            component.ClickOnItem(item);
        }

        [StepDefinition(@"I select ""([^""]*)"" suboption of ""(.*)"" option of ""(.*)"" tab in Oasis Route Portal")]
        public void SelectSubOptionOfTabInOasisRoutePortal(string subitem, string item, string tab)
        {
            OasisRouteTopMenu.HoverOverElement(tab);
            IOasisComponent component = OasisFactory.CreateOasisRouteComponent(tab);
            component.ClickOnSubItem(item, subitem);
        }

        [StepDefinition(@"I click on Set Filter button")]
        public void ClickOnSetFilterButton()
        {
            BrbBillsPage = new BrbBillsPage();
            BrbBillsPage.ClickOnSetFilterButton();
        }

        [StepDefinition(@"I filter invoices according TNUM obtained in BILL HEADER table")]
        public void FilterInvoicesAccordingTnumObtainedInBillHeader()
        {
            SetFilterPopUp = new SetFilterPopUp();
            SetFilterPopUp.FillFilterForm(new Dictionary<string, string>() { { "InvoiceCM", ScenarioContext.Current["TNum"].ToString() } });
        }

        [StepDefinition(@"The invoice row should be displayed in the result with the correct data")]
        public void TheInvoiceRowShouldBeDisplayedInTheResultWithTheCorrectData()
        {
            Assert.Multiple(() =>
            {
                Assert.True(BrbBillsPage.IsInvoiceLinkDisplayed(ScenarioContext.Current["TNum"].ToString()), $"Expected Invoice TNUM link: {ScenarioContext.Current["TNum"].ToString()}, is not displayed insisde the result");
                Assert.True(BrbBillsPage.IsInfoDisplayedInFirstElementFound(ScenarioContext.Current["BillHeaderId"].ToString()), $"Expected Bill Header Id data: {ScenarioContext.Current["BillHeaderId"].ToString()}, is not displayed insisde the result");
                Assert.True(BrbBillsPage.IsInfoDisplayedInFirstElementFound(ScenarioContext.Current["RetailerPIN"].ToString()), $"Expected Retailer PIN data: {ScenarioContext.Current["RetailerPIN"].ToString()}, is not displayed insisde the result");
                Assert.True(BrbBillsPage.IsInfoDisplayedInFirstElementFound(ScenarioContext.Current["TotalInBillHeader"].ToString()), $"Expected Total data: {ScenarioContext.Current["TotalInBillHeader"].ToString()}, is not displayed insisde the result");
            });
        }
    }
}
