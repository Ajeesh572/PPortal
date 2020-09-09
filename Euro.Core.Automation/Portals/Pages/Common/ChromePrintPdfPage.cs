// <copyright file="ChromePrintPdfPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Common
{
    using System.IO;
    using OpenQA.Selenium;
    using Page.Base;
    using Utilities;
    using Utilities.CommonAction;
    using Utilities.Context;
    using WebDriver;

    /// <summary>
    /// This class represent print pdf page for chrome browser (testing under 73 version).
    /// </summary>
    public class ChromePrintPdfPage : BasePage
    {
        public string DefaultDownloadedFilePath => Path.Combine(WebDriverUtils.GetBrowserDownloadFolder(), "print.pdf");

        private const string PageUrl = "chrome://print/";
        private const string DefaultBrowserWindow = "DefaultBrowserWindow";

        /// <summary>
        /// Download pdf file.
        /// </summary>
        public void DownloadPdfFile()
        {
            WaitUntilPageLoaded();
            WebDriverUtils.SwitchToFrame(GetPdfFrame());
            var url = CommonActions.GetWebElementBy(By.XPath("//embed")).GetAttribute("src");
            WebDriverUtils.GoToUrl(url);
        }

        /// <summary>
        /// Wait until pdf file loaded.
        /// </summary>
        public void WaitUntilPdfFileLoaded()
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(driver => File.Exists(DefaultDownloadedFilePath));
        }

        /// <summary>
        /// Switch webdriver on chrome pdf print page.
        /// </summary>
        public void SwitchToCurrentPage()
        {
            var defaultWindowName = WebDriverManager.Instance.GetWebDriver.CurrentWindowHandle;
            ScenarioContextManager.SetStringValue(DefaultBrowserWindow, defaultWindowName);
            string currentPageWindowName = null;
            WebDriverManager.Instance.GetWebDriverWait.Until(driver => (currentPageWindowName = GetWindowByUrl(PageUrl)) != null);
            WebDriverUtils.SwitchToWindowByName(currentPageWindowName);
        }

        /// <summary>
        /// Get frame with pdf document.
        /// </summary>
        /// <returns>Return Frame element with pdf.</returns>
        public IWebElement GetPdfFrame()
        {
            var shadowElement = CommonActions.GetShadowElementBySelector("print-preview-app");
            var innerShadowElement = shadowElement.GetShadowElementBySelector("print-preview-preview-area");
            return innerShadowElement.GetElementBySelector("iframe");
        }

        /// <summary>
        /// Click on close button on pdf page and switch to default window.
        /// </summary>
        public void ClosePdfPage()
        {
            var btnCancel = GetCancelButton();
            btnCancel.ClickElement();
            var defaultWindow = ScenarioContextManager.GetStringValue(DefaultBrowserWindow);
            WebDriverManager.Instance.GetWebDriver.SwitchTo()
                .Window(defaultWindow);
        }

        /// <summary>
        /// Get cancel button.
        /// </summary>
        /// <returns>Return Cancel button.</returns>
        public IWebElement GetCancelButton()
        {
            var shadowElement = CommonActions.GetShadowElementBySelector("print-preview-app");
            var innerShadowElement = shadowElement.GetShadowElementBySelector("print-preview-header");
            return innerShadowElement.GetElementBySelector(".cancel-button");
        }

        /// <summary>
        /// Get print button.
        /// </summary>
        /// <returns>Return Print button.</returns>
        public IWebElement GetPrintButton()
        {
            var shadowElement = CommonActions.GetShadowElementBySelector("print-preview-app");
            var innerShadowElement = shadowElement.GetShadowElementBySelector("print-preview-header");
            return innerShadowElement.GetElementBySelector(".action-button");
        }

        public override void WaitUntilPageLoaded()
        {
            WebDriverManager.Instance.GetWebDriverWait.Until(driver => GetPdfFrame() != null);
            WaitUntilAjaxInactive();
        }
    }
}
