namespace Euro.Core.Automation.Page.MobileBase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.PageObjects;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    public class MobileBasePage
    {
        public MobileBasePage()
        {
            this.Driver = WebDriver.MobileDriverManager.Instance.GetWebDriver;
            //this.Wait = WebDriver.MobileDriverManager.Instance.GetWebDriverWait;
            TimeOutDuration timeSpan = new TimeOutDuration(new TimeSpan(0, 0, 5));
           // PageFactory.InitElements(this.Driver, this, new AppiumPageObjectMemberDecorator(timeSpan));
        }

        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        protected IWebDriver Driver { get; set; }

        /// <summary>s
        /// Gets or sets the wait.
        /// </summary>
        protected WebDriverWait Wait { get; set; }
    }
}
