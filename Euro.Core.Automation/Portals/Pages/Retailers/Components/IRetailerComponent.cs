// <copyright file="TopMenuComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    /// <summary>
    /// Interface for Retailer Components
    /// </summary>
    public interface IRetailerComponent
    {
        /// <summary>
        /// Method to click over a Item inside a Component
        /// </summary>
        /// <param name="item"></param>
        void ClickOnItem(string item);
    }
}
