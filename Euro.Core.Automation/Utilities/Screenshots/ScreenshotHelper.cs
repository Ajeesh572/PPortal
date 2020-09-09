// <copyright file="ScreenshotHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Utilities.Screenshots
{
    using System;
    using System.IO;
    using System.Text;
    using JsonManager;
    using Logger;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Tracing;
    using WebDriver;

    /// <summary>
    /// A class to take screenshots
    /// </summary>
    public static class ScreenshotHelper
    {
        /// <summary>
        /// A method is used to take a screenshot
        /// </summary>
        /// <returns>Return the Path of </returns>
        public static string TakeScreenshot()
        {
            var screenshotFilePath = string.Empty;
            try
            {
                string fileNameBase =
                    $"error" +
                    $"_{FeatureContext.Current.FeatureInfo.Title.ToIdentifier()}" +
                    $"_{ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier()}" +
                    $"_{DateTime.Now:yyyyMMdd_HHmmss}";

                var artifactDirectory = Path.Combine(EnvironmentManager.AssemblyDirectoryPath, "Results");
                if (!Directory.Exists(artifactDirectory))
                {
                    Directory.CreateDirectory(artifactDirectory);
                }

                var pageSource = WebDriverManager.Instance.GetWebDriver.PageSource;
                var sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                var takesScreenshot = WebDriverManager.Instance.GetWebDriver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

                    Logging.Debug($"Screenshot: {new Uri(screenshotFilePath)}");
                }

                return screenshotFilePath;
            }
            catch (Exception ex)
            {
                Logging.Error($"Error while taking screenshot: {ex}");
                return screenshotFilePath;
            }
        }
    }
}
