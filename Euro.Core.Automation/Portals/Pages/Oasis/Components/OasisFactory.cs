// <copyright file="OasisFactory.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    using System.Collections.Generic;

    /// <summary>
    /// Oasis Factory for Components
    /// </summary>
    public class OasisFactory
    {
        /// <summary>
        /// Creates an instance of an Oasis Component for the Oasis UTA portal
        /// </summary>
        /// <param name="tabOption">In an option in the tab component</param>
        /// <returns>An instance of IOasisComponent</returns>
        public static IOasisComponent CreateOasisComponent(string tabOption)
        {
            Dictionary<string, IOasisComponent> component = new Dictionary<string, IOasisComponent>
            {
                { "CARD TRACKING", new CardTrackingComponent() },
                { "SALES", new SalesComponent() },
                { "ACTIVATIONS", new ActivationsComponent() },
                { "RECEIPTS", new ReceiptsComponents() },
                { "ADMIN", new AdminComponent() }
            };

            return component[tabOption.ToUpper()];
        }

        /// <summary>
        /// Creates an instance of an Oasis Component for the Oasis Route portal
        /// </summary>
        /// <param name="tabOption">The tab name containing the submenu</param>
        /// <returns>An instance of IOasisComponent</returns>
        public static IOasisComponent CreateOasisRouteComponent(string tabOption)
        {
            Dictionary<string, IOasisComponent> component = new Dictionary<string, IOasisComponent>
            {
                { "SALES", new OasisRouteSalesComponent() },
                { "PAYMENTS", new OasisRoutePaymentsComponent() },
                { "RETURNS", new OasisRouteReturnsComponent() },
                { "CONSIGNMENT", new OasisRouteConsigmentComponent() },
                { "NEW CUSTOMER", new OasisRouteNewCustomerComponent() },
                { "TOOLS", new OasisRouteToolsComponent() }
            };

            return component[tabOption.ToUpper()];
        }
    }
}
