// <copyright file="RadioButtonActions.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Component
{
    using Euro.Core.Automation.Utilities.Elements;

    /// <summary>
    /// Abstract partial base component to work with radio button
    /// </summary>
    public abstract partial class BaseComponent
    {
        /// <summary>
        /// Get and create <see cref = "RadioButton"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="radioButtonName">RadioButton name from attribute IDTFieldName</param>
        /// <returns>Instance of class <see cref = "RadioButton"/></returns>
        public RadioButton GetRadioButton(string radioButtonName) => new RadioButton(GetWebElementByFieldName(radioButtonName));

        /// <summary>
        /// Get state for <see cref = "RadioButton"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="radioButtonName">RadioButton name from attribute IDTFieldName</param>
        /// <returns>Bool value true if checked</returns>
        public bool IsRadioButtonChecked(string radioButtonName) => GetRadioButton(radioButtonName).IsChecked();

        /// <summary>
        /// Get state disabled for <see cref = "RadioButton"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="radioButtonName">RadioButton name from attribute IDTFieldName</param>
        /// <returns>Bool value true if disabled</returns>
        public bool IsRadioButtonDisabled(string radioButtonName) => GetRadioButton(radioButtonName).IsDisabled();

        /// <summary>
        /// Checks the radio button.
        /// </summary>
        /// <param name="radioButtonName">Name of Radio Button.</param>
        public void CheckRadioButton(string radioButtonName) => GetRadioButton(radioButtonName).Check();
    }
}
