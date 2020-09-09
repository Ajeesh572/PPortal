// <copyright file="AbstractPopup.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Elements
{
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;

    /// <summary>
    /// Base class for popups.
    /// </summary>
    public abstract class AbstractPopup
    {
        public IWebElement PopupContainer { get; protected set; }

        protected By TitleLocator { get; set; }

        protected By TextLocator { get; set; }

        protected By BtnCloseLocator { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractPopup"/> class.
        /// </summary>
        /// <param name="popupContainer">Base popup element.</param>
        protected AbstractPopup(IWebElement popupContainer)
        {
            PopupContainer = popupContainer;
            InitLocators();
        }

        protected AbstractPopup()
        {
            var popupContainerLocator = By.XPath("//div[contains(@class,'ui-pnotify-container')]");
            CommonActions.WaitUntilElementIsDisplayed(popupContainerLocator);
            PopupContainer = CommonActions.GetWebElementBy(popupContainerLocator);
            InitLocators();
        }

        /// <summary>
        /// Get popup title.
        /// </summary>
        /// <returns>Return text title</returns>
        public virtual string GetTitle() => GetTitleElement().Text;

        /// <summary>
        /// Get popup text.
        /// </summary>
        /// <returns>Return popup text</returns>
        public virtual string GetText() => GetTextElement().Text;

        /// <summary>
        /// Get popup text element.
        /// </summary>
        /// <returns>Return popup text element</returns>
        public IWebElement GetTextElement() => PopupContainer.FindElement(TextLocator);

        /// <summary>
        /// Get popup title element.
        /// </summary>
        /// <returns>Return text title element</returns>
        public IWebElement GetTitleElement() => PopupContainer.FindElement(TitleLocator);

        /// <summary>
        /// Close popup title.
        /// </summary>
        public virtual void Close() => CommonActions.ClickElement(PopupContainer.FindElement(BtnCloseLocator));

        /// <summary>
        /// Initializes basic locators for popup.
        /// </summary>
        private void InitLocators()
        {
            TitleLocator = By.XPath(".//h4[contains(@class,'title')]");
            TextLocator = By.XPath(".//div[contains(@class,'text')]");
            BtnCloseLocator = By.XPath(".//span[contains(@title,'Close')]");
        }
    }
}