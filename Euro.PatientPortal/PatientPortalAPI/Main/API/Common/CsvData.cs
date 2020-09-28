namespace Euro.PatientPortal.PatientPortalAPI.Main.API.Common
{
    using System;
    using System.IO;
    using System.Reflection;
    using Euro.Core.Automation.Utilities.JsonManager;

    public class CsvData
    {

        public static string file = $"{Directory.GetCurrentDirectory()}{"\\"}{Assembly.GetExecutingAssembly().GetName().Name}{"\\CsvFiles\\Users.csv"}";

        public static StreamWriter csvwriter = null;
        public static string csvFilePath = string.Empty;

        public static void LogCsvSummary(string content)
        {
            if (!File.Exists(file))
            {
                csvwriter = File.CreateText(file);
                csvwriter.WriteLine($"CreatedAt,{DateTime.Now}");
                csvwriter.Close();
            }

            csvwriter = new StreamWriter(file, true);
            if (csvwriter != null)
            {
                csvwriter.WriteLine(content);
                csvwriter.Close();
            }
        }
    }
}
