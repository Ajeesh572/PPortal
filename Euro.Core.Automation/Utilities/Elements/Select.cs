// <copyright file="Select.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Class represents a Select element.
    /// </summary>
    public class Select
    {
        private SelectElement select;

        public IWebElement Element { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Select"/> class.
        /// </summary>
        /// <param name="element">Base element.</param>
        public Select(IWebElement element)
        {
            Element = element;
            this.select = new SelectElement(element);
        }

        protected virtual IEnumerable<IWebElement> Options => Element.FindElements(By.CssSelector("option"));

        /// <summary>
        /// Select value from Select.
        /// </summary>
        /// <param name="item">String item.</param>
        /// <param name="equals">Equals or not.</param>
        /// <exception cref="Exception">Throw an exception if not found.</exception>
        public virtual void SelectValue(string item, bool equals = true)
        {
            var firstOrDefault = Options.FirstOrDefault(option => equals ? option.Text.Equals(item) : option.Text.Contains(item));
            if (firstOrDefault != null)
            {
                select.SelectByText(firstOrDefault.Text);
            }
            else
            {
                throw new Exception($"No {item} value was found in {nameof(Element)}");
            }
        }

        /// <summary>
        /// Select value from dropdown by index.
        /// </summary>
        /// <param name="itemIndex">Index.</param>
        /// <exception cref="Exception">Throw an exception if not found.</exception>
        public void SelectValue(int itemIndex)
        {
            var elementOrDefault = Options.ElementAtOrDefault(itemIndex);
            if (elementOrDefault != null)
            {
                select.SelectByIndex(itemIndex);
            }
            else
            {
                throw new Exception($"No index '{itemIndex}' was found in {nameof(Element)}");
            }
        }

        /// <summary>
        /// Get Selected value.
        /// </summary>
        /// <returns>First selected value.</returns>
        public virtual string GetSelectedValue()
        {
            var firstSelected = Options.FirstOrDefault(option => option.Selected);
            var val = firstSelected?.Text;

            return val;
        }

        /// <summary>
        /// Get Selected value by value.
        /// </summary>
        /// <param name="attribute">Attribute name. By default attribute is value</param>
        /// <returns>First selected value.</returns>
        public string GetSelectedValueByAttribute(string attribute = "value")
        {
            var firstSelected = Options.FirstOrDefault(option => option.Selected);
            var value = firstSelected?.GetAttribute(attribute);

            return value;
        }

        /// <summary>
        /// Get all possible text values.
        /// </summary>
        /// <returns>List of possible values.</returns>
        public IEnumerable<string> GetPossibleValues()
        {
            var options = Options.Select(option => option.Text.Trim());
            return options;
        }

        public IEnumerable<string> GetNonSelectedValues()
        {
            var selectedValue = GetSelectedValue();
            return GetPossibleValues().Where(value => value != selectedValue);
        }

        /// <summary>
        /// Get all possible values for some attribute for the option elements
        /// </summary>
        /// <param name="attributeName">The attribute on the OPTION element to add to the list, default = value</param>
        /// <returns>List of possible values</returns>
        public IEnumerable<string> GetPossibleValuesByAttribute(string attributeName = "value")
        {
            var options = Options.Select(option => option.GetAttribute(attributeName));
            return options;
        }

        /// <summary>
        /// Check if dropdown has a provided option.
        /// </summary>
        /// <param name="item">String item to check.</param>
        /// <param name="equals">Bool if equals or not.</param>
        /// <returns>Bool if a dropdown has value.</returns>
        public bool HasValue(string item, bool equals = true)
        {
            var hasOption = Options.Any(option => equals ? option.Text.Equals(item) : option.Text.Contains(item));

            return hasOption;
        }
    }
}
