// <copyright file="DivAsCheckboxActions.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Component
{
    using Euro.Core.Automation.Utilities.Elements;
    using Euro.Core.Automation.Utilities.Elements.Enums;

    /// <summary>
    /// Abstract partial base component to work with div as check box
    /// </summary>
    public abstract partial class BaseComponent
    {
        /// <summary>
        /// Click by <see cref = "DivAsCheckbox"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="checkBoxName">CheckBox name from attribute IDTFieldName</param>
        public void ClickOnDivAsCheckBox(string checkBoxName) => GetDivAsCheckBox(checkBoxName).Click();

        /// <summary>
        /// Get state for <see cref = "DivAsCheckbox"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="checkBoxName">CheckBox name from attribute IDTFieldName</param>
        /// <returns>Bool value true if checked</returns>
        public bool IsDivAsCheckBoxChecked(string checkBoxName) => GetDivAsCheckBox(checkBoxName).IsChecked();

        /// <summary>
        /// Set state <see cref = "DivAsCheckbox"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="checkBoxName">CheckBox name from attribute IDTFieldName</param>
        /// <param name="state">CheckBox state (checked or unchecked)</param>
        public void SetStateForDivAsCheckBox(string checkBoxName, CheckBoxStateEnum state) => GetDivAsCheckBox(checkBoxName).SetState(state);

        /// <summary>
        /// Get state for <see cref = "DivAsCheckbox"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="checkBoxName">CheckBox name from attribute IDTFieldName</param>
        /// <returns>CheckBox state of class (checked or unchecked)</returns>
        public CheckBoxStateEnum GetStateForDivAsCheckBox(string checkBoxName) => GetDivAsCheckBox(checkBoxName).GetState();

        /// <summary>
        /// Get and create <see cref = "DivAsCheckbox"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="checkBoxName">CheckBox name from attribute IDTFieldName</param>
        /// <returns>Instance of class <see cref = "CheckBox"/></returns>
        public DivAsCheckbox GetDivAsCheckBox(string checkBoxName) => new DivAsCheckbox(GetWebElementByFieldName(checkBoxName));
    }
}
