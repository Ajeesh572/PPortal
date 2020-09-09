// <copyright file="SelectActions.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Component
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Euro.Core.Automation.Utilities.Elements;

    /// <summary>
    /// Abstract partial base component to work with select ations
    /// </summary>
    public abstract partial class BaseComponent
    {
        /// <summary>
        /// Get and create <see cref = "Select"/> element by name in attribute IDTFieldName.
        /// </summary>
        /// <param name="selectName">Select name from attribute IDTFieldName</param>
        /// <returns>Instance of class <see cref = "Select"/></returns>
        public Select GetSelect(string selectName) => new Select(GetWebElementByFieldName(selectName));

        /// <summary>
        /// Get bool state.
        /// </summary>
        /// <param name="selectName">Select name from attribute IDTFieldName</param>
        /// <param name="value">Value which checked</param>
        /// <returns>Bool state if value presented return true</returns>
        public bool IsValuePresentedInSelect(string selectName, string value) => GetSelect(selectName).HasValue(value);

        /// <summary>
        /// Get selected value from Select.
        /// </summary>
        /// <param name="selectName">Select name from attribute IDTFieldName</param>
        /// <returns>Choosen value in Select element</returns>
        public string GetSelectedValueFromSelect(string selectName) => GetSelect(selectName).GetSelectedValue();

        /// <summary>
        /// Get List non selected values from Select.
        /// </summary>
        /// <param name="selectName">Select name from attribute IDTFieldName</param>
        /// <returns>List non selected values</returns>
        public IEnumerable<string> GetNonSelectedValuesFromSelect(string selectName) => GetSelect(selectName).GetNonSelectedValues();

        /// <summary>
        /// Get List all values from Select.
        /// </summary>
        /// <param name="selectName">Select name from attribute IDTFieldName</param>
        /// <returns>List all values</returns>
        public IEnumerable<string> GetPossibleValuesFromSelect(string selectName) => GetSelect(selectName).GetPossibleValues();

        /// <summary>
        /// Get selected attribute value from Select.
        /// </summary>
        /// <param name="selectName">Select name from attribute IDTFieldName</param>
        /// <param name="attributeName">Attribute name</param>
        /// <returns>Choosen attribute value in Select element</returns>
        public string GetSelectedValueByAttributeFromSelect(string selectName, string attributeName = "value") => GetSelect(selectName).GetSelectedValueByAttribute(attributeName);

        /// <summary>
        /// Select value in Select element.
        /// </summary>
        /// <param name="selectName">Select name from attribute IDTFieldName</param>
        /// <param name="value">Value for select</param>
        /// <param name="equals">Equals or not.</param>
        public void SelectValueForSelect(string selectName, string value, bool equals = true) => GetSelect(selectName).SelectValue(value, equals);

        /// <summary>
        /// Select random value in Select element.
        /// </summary>
        /// <param name="selectName">Select name from attribute IDTFieldName</param>
        /// <param name="equals">If true,checks for exact string else check contains</param>
        /// <param name="minRandomIndex">Min start index for random interval</param>
        public void SelectRandomValue(string selectName, bool equals = true, int minRandomIndex = 1)
        {
            var values = GetPossibleValuesFromSelect(selectName);
            var maxRandomIndex = values.Count() - 1;
            var randomIndex = new Random().Next(minRandomIndex, maxRandomIndex);
            SelectValueForSelect(selectName, values.ElementAt(randomIndex), equals);
        }
    }
}
