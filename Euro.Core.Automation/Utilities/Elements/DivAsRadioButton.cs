// <copyright file="DivAsRadiobutton.cs" company="Eurofins">
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
    /// Class represents Wrapper for a Div Radiobutton instance.
    /// </summary>
   public class DivAsRadioButton : IRadioButton
    {
        private RadioButton wrappedInput;
        private readonly IWebElement element;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivAsRadioButton"/> class. 
        /// </summary>
        /// <param name="element">Div element of a checbox.</param>
        public DivAsRadioButton(IWebElement element)
        {
            this.element = element;
        }

        protected RadioButton WrappedInput => wrappedInput ?? (wrappedInput = new RadioButton(element.FindElement(By.CssSelector("input[type='radio']"))));

        /// <summary>
        /// Click Wrapper radiobutton.
        /// </summary>
        public void Click()
        {
            Logging.Debug($"Clicking Div '{nameof(element)}'");
            element.FindElement(By.CssSelector("label")).Click();
        }

        /// <summary>
        /// Scrolling into view.
        /// </summary>
        /// <returns>Returns <see cref="DivAsRadioButton"/>> instance.</returns>
        public DivAsRadioButton ScrollIntoView()
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
        public IWebElement GetWebElement()
        {
            return element;
        }

        /// <inheritdoc />
        public bool IsChecked()
        {
            return WrappedInput.IsChecked();
        }

        /// <inheritdoc />
        public bool IsDisabled()
        {
            return WrappedInput.IsDisabled();
        }
    }
}
