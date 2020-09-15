namespace Euro.PatientPortal.PatientPortalAPI.Main.API.Common
{
    using System;
    using System.IO;

    public class CsvData
    {

        public static string file = @"C:\CodeBases\Eurofins_PP\Euro\Euro.PatientPortal\CsvFiles\Users.csv";

        public static StreamWriter csvwriter = null;
        public static string csvFilePath = string.Empty;

        public static void LogCsvSummary(string content)
        {
            if (!File.Exists(file))
            {
                csvwriter = File.CreateText(file);
                csvwriter.Close();
            }

            csvwriter = new StreamWriter(file, true);
            if (csvwriter != null)
            {
                csvwriter.WriteLine(string.Format("{0}", content));
                csvwriter.Close();
            }
        }
    }
}
