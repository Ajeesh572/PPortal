namespace Euro.PatientPortal.PatientPortalAPI.Main.API.Common
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Euro.Core.Automation.Utilities.JsonManager;
    using Newtonsoft.Json;

    public class PPCommmon
    {
        public static string pdfFilePath = $"{Directory.GetCurrentDirectory()}{"\\"}{Assembly.GetExecutingAssembly().GetName().Name}{"\\TestPdfs\\"}";

        /// <summary>
        /// Function to convert pdf to byteArray
        /// </summary>
        /// <param name="pdfName">PDF name</param>
        /// <returns>Pdf to byte Array</returns>
        public static string GetPdfInBytes(string pdfName)
        {
            byte[] bytes = System.IO.File.ReadAllBytes($"{pdfFilePath}{pdfName}");
            string report = JsonConvert.SerializeObject(bytes);
            return report.Substring(1).Replace('"', ' ').Trim();
        }
    }
}
