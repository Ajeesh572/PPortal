// <copyright file="IRadioButton.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Interfaces
{
    /// <summary>
    /// Represents a radiobutton class.
    /// </summary>
    public interface IRadioButton : IGetWebElement
    {
        /// <summary>
        /// Check if a radiobutton is selected.
        /// </summary>
        /// <returns>Is radiobutton is selected.</returns>
        bool IsChecked();

        /// <summary>
        /// Check if a radiobutton is disabled.
        /// </summary>
        /// <returns>Is radiobutton is disabled.</returns>
        bool IsDisabled();
    }
}
