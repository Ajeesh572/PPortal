// <copyright file="ChromePrintPdfPageSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions
{
    using Pages.Common;
    using TechTalk.SpecFlow;
    using Utilities.Context;

    [Binding]
    public class ChromePrintPdfPageSteps
    {
        private ChromePrintPdfPage chromePrintPdfPage;

        public ChromePrintPdfPageSteps()
        {
            chromePrintPdfPage = new ChromePrintPdfPage();
        }

        [StepDefinition(@"I download pdf file on Chrome Print Pdf Page")]
        public void DownloadPdfFile()
        {
            chromePrintPdfPage.DownloadPdfFile();
            chromePrintPdfPage.WaitUntilPdfFileLoaded();
        }

        [StepDefinition(@"I save downloaded file path by key ""(.*)"" on Chrome Print Pdf Page")]
        public void SaveDownlodedFilePathByKey(string key)
        {
            ScenarioContextManager.SetStringValue(key, chromePrintPdfPage.DefaultDownloadedFilePath);
        }

        [StepDefinition(@"I switch to Chrome Print Pdf Page")]
        public void SwitchToChromePrintPdfPage()
        {
            chromePrintPdfPage.SwitchToCurrentPage();
        }
    }
}
