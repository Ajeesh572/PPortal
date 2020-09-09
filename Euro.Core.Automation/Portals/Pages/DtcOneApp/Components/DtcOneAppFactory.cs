// <copyright file="DtcOneAppFactory.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.DtcOneApp.Components
{
    using System.Collections.Generic;

    /// <summary>
    /// DtcOneApp Factory for Components
    /// </summary>
    public class DtcOneAppFactory
    {
        /// <summary>
        /// Creates an instance of a DtcOneApp Component
        /// </summary>
        /// <param name="tabOption">In an option in the tab component</param>
        /// <returns>An instance of IDtcOneAppComponent</returns>
        public IDtcOneAppComponent CreateDtcOneAppComponent(string tabOption)
        {
            Dictionary<string, IDtcOneAppComponent> component = new Dictionary<string, IDtcOneAppComponent>
            {
                { "SERVICES", new ServicesMenuComponent() },
                { "MY ACCOUNT", new MyAccountMenuComponent() }
            };
            return component[tabOption.ToUpper()];
        }
    }
}
