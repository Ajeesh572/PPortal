namespace Euro.PatientPortal.PatientPortalAPI.Main.Hooks
{
    using System.IO;
    using System.Reflection;
    using TechTalk.SpecFlow;

    [Binding]
    public class CsvHooks
    {
        [BeforeTestRun(Order = 0)]
        public static void DeleteUsersCSV()
        {
            string usersCsvfile = $"{Directory.GetCurrentDirectory()}{"\\"}{Assembly.GetExecutingAssembly().GetName().Name}{"\\CsvFiles\\Users.csv"}";
            if (File.Exists(usersCsvfile))
            {
                File.Delete(usersCsvfile);
            }
        }
    }
}
