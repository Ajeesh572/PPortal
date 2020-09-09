namespace Euro.PatientPortal.PatientPortalAPI.Main.API.Common
{
    using Euro.Core.Automation.Utilities.JsonManager;
    public class PPCommmon
    {
        /// <summary>
        /// Function to convert pdf to byteArray
        /// </summary>
        /// <param name="pdfName">PDF name</param>
        /// <returns>Pdf to byte Array</returns>
        public static string GetPdfInBytes(string pdfName)
        {
            string pdfFilePath = FileManager.GetFilePath(pdfName);
            byte[] bytes = System.IO.File.ReadAllBytes(pdfFilePath);
            var array = Newtonsoft.Json.JsonConvert.SerializeObject(bytes);
            return array;
        }
    }
}
