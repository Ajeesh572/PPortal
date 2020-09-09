// <copyright file="IDistributorComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Distributor.Components
{
    /// <summary>
    /// Interface for Distributor Components
    /// </summary>
    public interface IDistributorComponent
    {
        /// <summary>
        /// Method to click over a Item inside a Component
        /// </summary>
        /// <param name="item"></param>
        void ClickOnItem(string item);
    }
}
