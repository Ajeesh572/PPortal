// <copyright file="IDtcOneAppComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.DtcOneApp.Components
{
    /// <summary>
    /// Interface for DtcOneApp Components
    /// </summary>
    public interface IDtcOneAppComponent
    {
        /// <summary>
        /// Method to click over an item inside a component
        /// </summary>
        /// <param name="item"></param>
        void ClickOnItem(string item);
    }
}