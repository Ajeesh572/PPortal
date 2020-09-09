// <copyright file="DivAsCheckbox.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements
{
    using Enums;
    using Interfaces;
    using Logger;
    using OpenQA.Selenium;
    using WebDriver;

    /// <summary>
    /// Class represents Wrapper for a Div Checbox instance.
    /// </summary>
    public class DivAsCheckbox : ICheckbox
    {
        private CheckBox wrappedInput;
        private readonly IWebElement element;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivAsCheckbox"/> class. 
        /// </summary>
        /// <param name="element">Div element of a checbox.</param>
        public DivAsCheckbox(IWebElement element)
        {
            this.element = element;
        }

        protected CheckBox WrappedInput => wrappedInput ?? (wrappedInput = new CheckBox(element.FindElement(By.CssSelector("input[type='checkbox']"))));

        /// <summary>
        /// Click Wrapper checkbox.
        /// </summary>
        public void Click()
        {
            Logging.Debug($"Clicking Div '{nameof(element)}'");
            element.FindElement(By.CssSelector("label")).Click();
        }

        /// <summary>
        /// Scrolling into view.
        /// </summary>
        /// <returns>Returns <see cref="DivAsCheckbox"/>> instance.</returns>
        public DivAsCheckbox ScrollIntoView()
        {
            Logging.Debug($"Scrolling into view for {nameof(element)}");
            ((IJavaScriptExecutor)WebDriverManager.Instance.GetWebDriver).ExecuteScript("arguments[0].scrollIntoView();", element);
            return this;
        }

        /// <summary>
        /// Gets text.
        /// </summary>
        /// <returns>Text.</returns>
        public string GetCaption()
        {
            return element.Text.Trim();
        }

        /// <inheritdoc />
        public void Check()
        {
            if (!WrappedInput.IsChecked())
            {
                Click();
            }
        }

        /// <inheritdoc />
        public void UnCheck()
        {
            if (WrappedInput.IsChecked())
            {
                Click();
            }
        }

        /// <inheritdoc />
        public void Toggle()
        {
            Click();
        }

        /// <inheritdoc />
        public bool IsChecked()
        {
            return WrappedInput.IsChecked();
        }

        /// <inheritdoc />
        public void SetState(bool state)
        {
            if (state != IsChecked())
                Toggle();
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

        /// <inheritdoc />
        public IWebElement GetWebElement()
        {
            return element;
        }

        public CheckBoxStateEnum GetState()
        {
            return IsChecked() ? CheckBoxStateEnum.Checked : CheckBoxStateEnum.Unchecked;
        }
    }
}