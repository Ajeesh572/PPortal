namespace Euro.PatientPortal.PatientPortalAPI.Main.API.JSONObject
{
    using System;
    public class ForgotPassword
    {
        public string objectId { get; set; }

        public string email { get; set; }

        public string newPassword { get; set; }

        public string confirmPassword { get; set; }

        public string userCode { get; set; }

        public string verificationCode { get; set; }

        public DateTime sentDateTime { get; set; }
    }
}
