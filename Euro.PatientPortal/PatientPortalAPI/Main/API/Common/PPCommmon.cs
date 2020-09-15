namespace Euro.PatientPortal.PatientPortalAPI.Main.API.Common
{
    using System.Collections.Generic;
    using System.Text;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Newtonsoft.Json;

    public class PPCommmon
    {
        /// <summary>
        /// Function to convert pdf to byteArray
        /// </summary>
        /// <param name="pdfName">PDF name</param>
        /// <returns>Pdf to byte Array</returns>
        public static string GetPdfInBytes(string pdfName)
        {
            string pdfFilePath = @"C:\CodeBases\Eurofins_PP\Euro\Euro.PatientPortal\TestPdfs\";
            byte[] bytes = System.IO.File.ReadAllBytes($"{pdfFilePath}{pdfName}");
            string report = JsonConvert.SerializeObject(bytes);
            return report.Substring(1).Replace('"', ' ').Trim();
        }
    }
}
