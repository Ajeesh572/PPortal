// <copyright file="PdfSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions
{
    using Assert;
    using TechTalk.SpecFlow;
    using Transformation;
    using Transformation.Models;
    using Utilities;

    [Binding]
    public class PdfSteps
    {
        [Then(@"Verify pdf by path ""(.*)"" on page with number ""(.*)"" have following text:")]
        public void CheckPdfPageHaveText(StringValue pdfPath, int pageNumber, Table table)
        {
            var pageText = PdfUtils.GetTextFromFromPage(pdfPath.Value, pageNumber);
            table = table.TransformTable();
            foreach (var row in table.Rows)
            {
                var partText = row[0];
                SoftAssert.Contains(partText, pageText, "Pdf page is not contain text.");
            }
        }
    }
}
