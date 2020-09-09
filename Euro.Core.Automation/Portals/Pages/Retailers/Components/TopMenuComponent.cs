// <copyright file="TopMenuComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.Utilities.Helpers.DialogModalMessageHelper;
    using Euro.Core.Automation.Utilities.Logger;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class represent top menu element with his respective operations.
    /// </summary>
    public class TopMenuComponent : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "[class = 'navbar--link log-out']")]
        private IWebElement BtnLogOut;

        [IDTFindBy(How = How.CssSelector, Using = "[class = 'navbar--link dropdown-toggle']")]
        private IWebElement CboLanguage;

        [IDTFindBy(How = How.XPath, Using = "//*[starts-with(@class, 'visible-lg-inline-block')][text()= 'English']")]
        private IWebElement LblEnglish;

        [IDTFindBy(How = How.CssSelector, Using = "a[data-lang='en']")]
        private IWebElement EnglishOption;

        [IDTFindBy(How = How.XPath, Using = "//*[starts-with(@class, 'visible-lg-inline-block')][text()= 'Spanish']")]
        private IWebElement LblSpanish;

        [IDTFindBy(How = How.CssSelector, Using = "a[data-lang='es']")]
        private IWebElement SpanishOption;

        [IDTFindBy(How = How.CssSelector, Using = "[class='blockUI blockOverlay']")]
        private IWebElement BlockUiOverlay;

        /// <summary>
        /// Clicks on BtnLogOut.
        /// </summary>
        public void ClickOnBtnLogOut()
        {
            BtnLogOut.ClickElementByJavaScript();
        }

        /// <summary>
        /// Selects language option for the portal (English, Spanish)
        /// </summary>
        /// <param name="language">Is the language to set in the portal</param>
        public void SelectLanguage(string language)
        {
            BlockUiOverlay.WaitUntilElementIsInvisible();
            string languages = Utilities.Utils.GetAbbreviationLanguage(language);

            if (CboLanguage.Text.ToUpper() != language.ToUpper() && CboLanguage.Text.ToUpper() != languages.ToUpper())
            {
                Logging.Debug($"Changing the language option to: {language}");
                CommonActions.ClickElement(CboLanguage);
                if (language.ToUpper().Equals("SPANISH"))
                {
                    CommonActions.ClickElement(SpanishOption);
                }
                else
                {
                    CommonActions.ClickElement(EnglishOption);
                }

                BlockUiOverlay.WaitUntilElementIsInvisible();
            }
        }

        /// <summary>
        /// Gets the select language.
        /// </summary>
        /// <returns>The selected language.</returns>
        public string GetSelectLanguage()
        {
            string language = CboLanguage.Text.ToUpper().Trim();
            return language.Equals("ENGLISH") || language.Equals("EN") ? "english" : "spanish";
        }

        /// <summary>
        /// Gets the select language.
        /// </summary>
        /// <param name="codeI18n">Code realted to I18n Standar.</param>
        /// <returns>The selected language.</returns>
        public string GetSelectLanguage(string codeI18n)
        {
            return codeI18n.Equals("en_US") ? "ENGLISH" : "SPANISH";
        }
    }
}
