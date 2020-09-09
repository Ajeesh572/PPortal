// <copyright file="RadioButton.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements
{
    using Enums;
    using Interfaces;
    using Logger;
    using OpenQA.Selenium;

    public class RadioButton : IRadioButton
    {
        private readonly IWebElement element;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioButton"/> class.
        /// </summary>
        /// <param name="element">Checkbox element.</param>
        public RadioButton(IWebElement element)
        {
            this.element = element;
        }

        /// <inheritdoc />
        public IWebElement GetWebElement()
        {
            return element;
        }

        /// <inheritdoc />
        public bool IsChecked()
        {
            var isChecked = element.Selected;
            Logging.Debug($"'{nameof(element)}' is checked? - {isChecked}");
            return isChecked;
        }

        /// <inheritdoc />
        public bool IsDisabled()
        {
            var isDisabled = element.GetAttribute("disabled") == "true";
            Logging.Debug($"'{nameof(element)}' is disabled? - {isDisabled}");
            return isDisabled;
        }

        /// <summary>
        /// Sets the Radio Button state to checked.
        /// </summary>
        public void Check()
        {
            Logging.Debug("Clicking radio button element");
            element.Click();
        }
    }
}
