// <copyright file="PPJsonObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Euro.Viracor.Labalert.PatientPortalAPI.Main
{
    using System;
    using System.Collections.Generic;

    //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AddPatientReportInfo
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string dob { get; set; }

        public string email { get; set; }

        public object phone { get; set; }

        public string zipCode { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string addressLine1 { get; set; }

        public object addressLine2 { get; set; }

        public string orderId { get; set; }

        public DateTime orderDate { get; set; }

        public string testName { get; set; }

        public string bu { get; set; }

        public object report { get; set; }
    }

    public class Root
    {
        public List<AddPatientReportInfo> AddPatientReportInfo(AddPatientReportInfo ddPatientReportInfo)
        {
            List<AddPatientReportInfo> list = new List<AddPatientReportInfo>();
            list.Add(ddPatientReportInfo);
            return list;
        }
    }
}
