using Euro.Core.Automation.Page.Base;
using Euro.Core.Automation.Portals.Pages.Common;
using Euro.Core.Automation.Portals.Pages.Common.LoginPages;
using Euro.Core.Automation.Selenium;
using Euro.Core.Automation.Utilities.CommonAction;
using Euro.Core.Automation.Utilities.JsonManager;
using Euro.Core.Automation.Utilities.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Euro.Core.Automation.Portals.Pages.Oasis
{
    /// <summary>
    /// Handles the login page in OasisUTA portal
    /// </summary>
    public class OasisUTALoginPage : BasePage, ILoginPage
    {
        [IDTFindBy(How = How.Id, Using = "loginName")]
        private IWebElement TxtIdUsername;

        [IDTFindBy(How = How.Id, Using = "password")]
        private IWebElement TxtPassword;

        [IDTFindBy(How = How.CssSelector, Using = ".oasis")]
        private IWebElement BtnLogin;

        [IDTFindBy(How = How.CssSelector, Using = ".whitebig")]
        private IWebElement LblWelcomeOasis;

        /// <summary>
        /// Verifies if login in OasisUTA Portal Web.
        /// </summary>
        /// <returns>True if login in OasisUTA Portal Web</returns>
        public bool IsLoginPage()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(LblWelcomeOasis));
                result = true;
            }
            catch (WebDriverTimeoutException e)
            {
                Logging.Debug("Cannot find to web element." + e);
            }

            return result;
        }

        /// <summary>
        /// Logs in according to the given user type.
        /// </summary>
        /// <param name="userType">Type of user required.</param>
        /// <param name="portal">Type of portal required.</param>
        public void LoginAsUserType(UserType userType, PortalWeb portal)
        {
            var user = EnvironmentManager.GetUser(portal.ToString(), userType.ToString());
            CommonActions.SendKeys(TxtIdUsername, user.Name);
            CommonActions.SendKeys(TxtPassword, user.Password);
            CommonActions.ClickElement(BtnLogin);
        }
    }
}
