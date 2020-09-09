// <copyright file="CheckBox.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements
{
    using Enums;
    using Interfaces;
    using Logger;
    using OpenQA.Selenium;

    /// <summary>
    /// Class represents CheckBox instance.
    /// </summary>
    public class CheckBox : ICheckbox
    {
        private readonly IWebElement element;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class.
        /// </summary>
        /// <param name="element">Checkbox element.</param>
        public CheckBox(IWebElement element)
        {
            this.element = element;
        }

        /// <inheritdoc />
        public void Check()
        {
            SetState(true);
        }

        /// <inheritdoc />
        public void UnCheck()
        {
            SetState(false);
        }

        /// <inheritdoc />
        public virtual void Toggle()
        {
            Logging.Debug($"Clicking '{nameof(element)}'");
            element.Click();
        }

        /// <inheritdoc />
        public virtual bool IsChecked()
        {
            var isChecked = element.GetAttribute("checked") != null;
            Logging.Debug($"'{nameof(element)}' is checked? - {isChecked}");
            return isChecked;
        }

        /// <inheritdoc />
        public void SetState(bool state)
        {
            if (state != IsChecked())
            {
                Toggle();
            }
        }

        /// <inheritdoc />
        public void SetState(CheckBoxStateEnum state)
        {
            switch (state)
            {
                case CheckBoxStateEnum.Checked:
                    SetState(true);
                    break;
                case CheckBoxStateEnum.Unchecked:
                    SetState(false);
                    break;
            }
        }

        public CheckBoxStateEnum GetState()
        {
            return IsChecked() ? CheckBoxStateEnum.Checked : CheckBoxStateEnum.Unchecked;
        }

        /// <inheritdoc />
        public IWebElement GetWebElement()
        {
            return element;
        }
    }
}