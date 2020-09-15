namespace Euro.PatientPortal.PatientPortalAPI.Main.API.JSONObject
{
    public class CreateUser
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string dob { get; set; }

        public string phone { get; set; }

        public string ZipCode { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string addressLine1 { get; set; }

        public string addressLine2 { get; set; }

        public string testedLab { get; set; }

        public bool privacyPolicy { get; set; }

        public bool termsOfUse { get; set; }
    }
}
