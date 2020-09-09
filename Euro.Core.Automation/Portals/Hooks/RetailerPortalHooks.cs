// <copyright file="RetailerPortalHooks.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Hooks
{
    using Euro.Core.Automation.Portals.Pages.Retailers.Components;
    using Euro.Core.Automation.Utilities.Logger;
    using NUnit.Framework.Interfaces;
    using NUnit.Framework.Internal;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Hooks for actions to run after Scenarios related to with Retailer portal.
    /// </summary>
    [Binding]
    public class RetailerPortalHooks
    {
        private TopMenuComponent topMenuComponent;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetailerPortalHooks"/> class.
        /// </summary>
        public RetailerPortalHooks()
        {
            topMenuComponent = new TopMenuComponent();
        }

        /// <summary>
        /// Clicks on LogOut button of the Retailer portal.
        /// </summary>
        [AfterScenario]
        [Scope(Tag = "@LogoutRetailerPortal")]
        [AfterScenario(Order = 4)]
        public void LogoutRetailerPortal()
        {
            var status = TestExecutionContext.CurrentContext.CurrentResult.ResultState;
            if (!ResultState.Ignored.Equals(status))
            {
                Logging.Debug($"After Scenario - RetailerPortalHooks : LogoutRetailerPortal.");
                topMenuComponent.ClickOnBtnLogOut();
            }
        }

        /// <summary>
        /// Changes the language to English of Retailer portal.
        /// </summary>
        [AfterScenario(Order = 3)]
        [Scope(Tag = "@ChangeEnglishLanguage")]
        public void ChangeEnglishLanguage()
        {
            var status = TestExecutionContext.CurrentContext.CurrentResult.ResultState;
            if (!ResultState.Ignored.Equals(status))
            {
                Logging.Debug($"After Scenario - RetailerPortalHooks : ChangeEnglishLanguage.");
                topMenuComponent.SelectLanguage("English");
            }
        }
    }
}
