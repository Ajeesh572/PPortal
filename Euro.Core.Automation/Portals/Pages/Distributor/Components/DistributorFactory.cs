// <copyright file="DistributorFactory.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Distributor.Components
{
    using System.Collections.Generic;

    /// <summary>
    /// Distributor Factory for Components
    /// </summary>
    public class DistributorFactory
    {
        /// <summary>
        /// Creates an instance of a Distributor Component
        /// </summary>
        /// <param name="tabOption">In an option in the tab component</param>
        /// <returns>An instance of IDistributorComponent</returns>
        public IDistributorComponent CreateDistributorComponent(string tabOption)
        {
            Dictionary<string, IDistributorComponent> component = new Dictionary<string, IDistributorComponent>
            {
                { "Tools", new ToolComponent() },
                { "Reports", new ReportComponent() },
                { "BR University", new BRUniversityComponent() }
            };

            return component[tabOption];
        }

        /// <summary>
        /// Creates an instance of a vertical Distributor Component
        /// </summary>
        /// <param name="tabOption">In an option in the tab component</param>
        /// <returns>An instance of IDistributorComponent</returns>
        public IDistributorComponent CreateVerticalDistributorComponent(string tabOption)
        {
            Dictionary<string, IDistributorComponent> component = new Dictionary<string, IDistributorComponent>
            {
                { "Tools", new ToolVerticalComponent() },
                { "Reports", new ReportVerticalComponent() },
                { "BR University", new BRUniversityVerticalComponent() }
            };

            return component[tabOption];
        }
    }
}
