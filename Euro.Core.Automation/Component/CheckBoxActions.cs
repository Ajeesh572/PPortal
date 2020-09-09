// <copyright file="CheckBoxActions.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Component
{
    using Euro.Core.Automation.Utilities.Elements;
    using Euro.Core.Automation.Utilities.Elements.Enums;

    /// <summary>
    /// Abstract partial base component to work with check box
    /// </summary>
    public abstract partial class BaseComponent
    {
        /// <summary>
        /// Get and create <see cref = "CheckBox"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="checkBoxName">CheckBox name from attribute IDTFieldName</param>
        /// <returns>Instance of class <see cref = "CheckBox"/></returns>
        public CheckBox GetCheckBox(string checkBoxName) => new CheckBox(GetWebElementByFieldName(checkBoxName));

        /// <summary>
        /// Set state <see cref = "CheckBox"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="checkBoxName">CheckBox name from attribute IDTFieldName</param>
        /// <param name="state">CheckBox state (checked or unchecked)</param>
        public void SetCheckBoxState(string checkBoxName, CheckBoxStateEnum state) => GetCheckBox(checkBoxName).SetState(state);

        /// <summary>
        /// Get state for <see cref = "CheckBox"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="checkBoxName">CheckBox name from attribute IDTFieldName</param>
        /// <returns>CheckBox state of class (checked or unchecked)</returns>
        public CheckBoxStateEnum GetCheckBoxState(string checkBoxName) => GetCheckBox(checkBoxName).GetState();
    }
}
