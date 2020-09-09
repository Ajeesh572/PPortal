// <copyright file="RetailerFactory.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using System.Collections.Generic;

    /// <summary>
    /// Retailer Factory for Components
    /// </summary>
    public class RetailerFactory
    {
        /// <summary>
        /// Creates an instance of a Retailer Component
        /// </summary>
        /// <param name="tabOption">In an option in the tab component</param>
        /// <returns>An instance of IRetailerComponent</returns>
        public IRetailerComponent CreateRetailerComponent(string tabOption)
        {
            Dictionary<string, IRetailerComponent> component = new Dictionary<string, IRetailerComponent>
            {
                { "Products", new ProductComponent() },
                { "Reports", new ReportComponent() },
                { "BR University", new BRUniversityComponent() },
                { "Tools", new ToolsComponent() }
            };

            return component[tabOption];
        }

        /// <summary>
        /// Creates an instance of a vertical Retailer Component
        /// </summary>
        /// <param name="tabOption">In an option in the tab component</param>
        /// <returns>An instance of IRetailerComponent</returns>
        public IRetailerComponent CreateVerticalRetailerComponent(string tabOption)
        {
            Dictionary<string, IRetailerComponent> component = new Dictionary<string, IRetailerComponent>
            {
                { "Products", new ProductVerticalComponent() },
                { "Reports", new ReportVerticalComponent() },
                { "Tools", new ToolsComponent() }
            };

            return component[tabOption];
        }
    }
}
