namespace Euro.CP.Main.Utils
{
    using Euro.Core.Automation.WebDriver;
    using log4net;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.iOS;

    /// <summary>
    /// Page-Interface abstract class to define the basic functionalities of pages
    /// </summary>
    public class DriverHandler
    {
        /// <summary>
        /// log file using log4net
        /// </summary>
        protected static ILog log;

        /// <summary>
        /// application list that can be saved to local in firefox
        /// </summary>
        private static string applicationList =
            "application/vnd.ms-excel;application/x-xpinstall;application/x-zip;application/x-zip-compressed;application/octet-stream;application/zip;application/x-pdf;application/pdf;application/msword;text/plain;application/octet;application/csv;text/csv";

        /// <summary>
        /// Initializes a new instance of the DriverHandler class
        /// </summary>
        public DriverHandler()
        {
            log = LogManager.GetLogger(this.GetType().ToString());
        }

        /// <summary>
        /// selenium driver
        /// </summary>
        public static IWebDriver Driver = WebDriverManager.Instance.GetWebDriver;

        public static IOSDriver<AppiumWebElement> IOSDriver { get; set; }

        /// <summary>
        /// firefox download path
        /// </summary>
        //public string FireFoxLocalDownloadPath { get { return GetPath(); } }

        /// <summary>
        /// take screenshot function. This function performs a binary check to make sure no duplicate images are saved in the folder.
        /// </summary>
        /// <param name="filePath">path to save the png file</param>
        /// <param name="imageFormatformat">Take gif by defaul</param>
        /// <returns>return saved png filename</returns>
        public static string TakeScreenShot(string filePath)
        {
            return ScreenShots.TakeScreenShot(filePath);
        }

        public static string TakeGrayscaleScreenShot(string filePath)
        {
            return ScreenShots.TakeGrayscaleScreenShot(filePath);
        }
    }
}
