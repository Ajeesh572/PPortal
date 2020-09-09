// <copyright file="IHomePage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Common.HomePages
{
    /// <summary>
    /// This interface handles the methods to implement in the class of the type Home Page.
    /// </summary>
    public interface IHomePage
    {
        /// <summary>
        /// Verifys if to be in Home portal Web.
        /// </summary>
        /// <returns>True if to be in Home portal Web.</returns>
        bool IsHomePage();
    }
}
