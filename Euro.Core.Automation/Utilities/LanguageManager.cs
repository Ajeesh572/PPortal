// <copyright file="LanguageManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using Euro.Core.Automation.Portals.Pages.Retailers.Components;
    using Euro.Core.Automation.Utilities.Helpers.DialogModalMessageHelper;
    using Euro.Core.Automation.Utilities.Logger;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// This class is in charge to get the language for execution of all test.
    /// </summary>
    public class LanguageManager
    {
        private static LanguageManager _instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageManager"/> class.
        /// </summary>
        private LanguageManager()
        {
            if (!string.IsNullOrWhiteSpace(TestContext.Parameters.Get("Language")))
            {
                // Gets the language from system property.
                Language = TestContext.Parameters.Get("Language");
            }
            else if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Language"]))
            {
                // Gets the language from app.config file.
                Language = ConfigurationManager.AppSettings["Language"].ToLower();
            }
            else
            {
                Language = "english";
            }
        }

        /// <summary>
        /// Gets a new instance of class if it doesn't exist yet.
        /// </summary>
        public static LanguageManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LanguageManager();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Get text in english and translate this text in the language for execution.
        /// </summary>
        /// <param name="text">Text in english language.</param>
        /// <returns>Translated text in the language for execution.</returns>
        public string TranslateTextIfNeed(string text)
        {
            try
            {
                return GetValue(GetKey("english", text));
            }
            catch (Exception exception)
            {
                if (exception is KeyNotFoundException || exception is NullReferenceException)
                {
                    Logging.Error($"For text '{text}' can not find key in Language file");
                    return text;
                }

                throw;
            }
        }

        /// <summary>
        /// Verifies if it change Language.
        /// </summary>
        public void VerifyLanguageInRetailerPortal()
        {
            TopMenuComponent topMenuComponent = new TopMenuComponent();
            string currentLanguage = topMenuComponent.GetSelectLanguage();
            DialogMessageHelper.CloseMessageDetailsModalOpened();
            if (!currentLanguage.Equals(Language, StringComparison.InvariantCultureIgnoreCase))
            {
                Logging.Debug($"Select {Language} langauge because the current language is {currentLanguage}");
                topMenuComponent.SelectLanguage(Language);
            }
        }

        /// <summary>
        /// Gets the language for execution.
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// Gets the value through key name in Language file.
        /// </summary>
        /// <param name="key">The key name of Language file.</param>
        /// <returns>The value that to be in the Language file.</returns>
        public string GetValue(string key)
        {
            return GetValue(Language, key);
        }

        /// <summary>
        /// Gets the value through key name in Language file.
        /// </summary>
        /// <param name="language">Language for execution.</param>
        /// <param name="key">The key name of Language file.</param>
        /// <returns>The value that to be in the Language file.</returns>
        public string GetValue(string language, string key)
        {
            string portal = FeatureContext.Current["Portal"].ToString();
            return ResourceReader.GetValue($"Language_{portal}_{language}", key);
        }

        /// <summary>
        /// Gets the key name through value in Language file.
        /// </summary>
        /// <param name="value">The value of Language file.</param>
        /// <returns>The key name that to be in the Language file.</returns>
        public string GetKey(string value)
        {
            return GetKey(Language, value);
        }

        /// <summary>
        /// Gets the key name through value in Language file.
        /// </summary>
        /// <param name="language">Language for execution.</param>
        /// <param name="value">The value of Language file.</param>
        /// <returns>The key name that to be in the Language file.</returns>
        public string GetKey(string language, string value)
        {
            string portal = FeatureContext.Current["Portal"].ToString();
            return ResourceReader.GetKey($"Language_{portal}_{language}", value);
        }
    }
}
