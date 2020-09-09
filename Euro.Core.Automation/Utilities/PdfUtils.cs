// <copyright file="PdfUtils.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities
{
    using System.Text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;

    public static class PdfUtils
    {
        /// <summary>
        /// Get text from all pdf document.
        /// </summary>
        /// <param name="path">Path to pdf.</param>
        /// <returns>Text from all pdf document.</returns>
        public static string GetTextFromDocument(string path)
        {
            var reader = new PdfReader(path);
            var text = new StringBuilder();
            for (var page = 1; page <= reader.NumberOfPages; page++)
            {
                text.Append(PdfTextExtractor.GetTextFromPage(reader, page));
            }

            reader.Close();
            return text.ToString();
        }

        /// <summary>
        /// Get text from page of pdf document.
        /// </summary>
        /// <param name="path">Path to pdf.</param>
        /// <param name="pageNumber">Page number.</param>
        /// <returns>Text from page by page number of pdf document.</returns>
        public static string GetTextFromFromPage(string path, int pageNumber)
        {
            var reader = new PdfReader(path);
            var text = PdfTextExtractor.GetTextFromPage(reader, pageNumber);
            reader.Close();
            return text;
        }
    }
}
