// <copyright file="IOasisComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis.Components
{
    /// <summary>
    /// Interface for Oasis Components
    /// </summary>
    public interface IOasisComponent
    {
        /// <summary>
        /// Clicks over a Item inside a Component
        /// </summary>
        /// <param name="item">Is the item name</param>
        void ClickOnItem(string item);

        /// <summary>
        /// Clicks over an item in a submenu of a component
        /// </summary>
        /// <param name="item">The menu to hover over</param>
        /// <param name="subitem">The submenu to click</param>
        void ClickOnSubItem(string item, string subitem);
    }
}
