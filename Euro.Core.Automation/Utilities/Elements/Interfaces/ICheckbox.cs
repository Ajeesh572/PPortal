// <copyright file="ICheckbox.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements.Interfaces
{
    using Enums;

    /// <summary>
    /// Represents a checbox class.
    /// </summary>
    public interface ICheckbox : IGetWebElement
    {
        /// <summary>
        /// Check a checkbox.
        /// </summary>
        void Check();

        /// <summary>
        /// Uncheck a checkbox.
        /// </summary>
        void UnCheck();

        /// <summary>
        /// Clicking a checkbox.
        /// </summary>
        void Toggle();

        /// <summary>
        /// Check if a checbox is checked.
        /// </summary>
        /// <returns>Is checkbox is checked.</returns>
        bool IsChecked();

        /// <summary>
        /// Set a checkbox state.
        /// </summary>
        /// <param name="state">State of a checkbox.</param>
        void SetState(bool state);

        /// <summary>
        /// Set a checkbox state.
        /// </summary>
        /// <param name="state">Checkbox state <see cref="CheckBoxStateEnum"/></param>
        void SetState(CheckBoxStateEnum state);
    }
}