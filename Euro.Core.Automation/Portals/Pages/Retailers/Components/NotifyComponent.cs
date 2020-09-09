// <copyright file="NotifyComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Retailers.Components
{
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class represent  Notify with his respective operations.
    /// </summary>
    public class NotifyComponent : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "div[class='ui-pnotify-text']")]
        private IWebElement LblMessage;

        [IDTFindBy(How = How.CssSelector, Using = ".ui-pnotify")]
        private IWebElement LblNotifyMessage;

        [IDTFindBy(How = How.CssSelector, Using = ".blockMsg.blockElement")]
        private IWebElement LblBossRevolutionLoadingSign;

        /// <summary>
        /// Clicks on Close button.
        /// </summary>
        public void ClickOnBtnClose()
        {
            CommonActions.ClickElementByJavaScript(By.CssSelector("span[title='Close']"));
            CommonActions.WaitUntilElementIsInvisible(By.CssSelector("div.ui-pnotify"));
        }

        /// <summary>
        /// Clicks on Play or Pause button.
        /// </summary>
        public void ClickOnBtnAction()
        {
            CommonActions.ClickElementByLocator(By.XPath("//span[contains(@title,'Stick')]"));
        }

        /// <summary>
        ///  Waits until Notification message is Invisible.
        /// </summary>
        public void WaitUntilNotificationMessageIsInvisible()
        {
            LblBossRevolutionLoadingSign.WaitUntilElementIsInvisible();
            LblNotifyMessage.WaitUntilElementIsInvisible();
        }

        /// <summary>
        /// Gets a message.
        /// </summary>
        /// <returns>A message in string format.</returns>
        public string GetMessage()
        {
            LblMessage.WaitUntilElementIsDisplayed();
            return LblMessage.Text;
        }
    }
}
