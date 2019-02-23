
using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class PatientReportView
    {
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public string RegisteredDate { get; set; }
        public string RegisterBy { get; set; }

        public string HospitalNumber { get; set; }
        public string PatientHomeAddress { get; set; }
        public string Zone { get; set; }
        public string Religion { get; set; }
        public string Citizenship { get; set; }
        public string Ethnicity { get; set; }
        public string PermanentAddress { get; set; }
        public string Relationship { get; set; }
        public string LocationOfMajuro { get; set; }
        public string DateOfBirth { get; set; }
        public string Marital_Status { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public string BirthPlace { get; set; }
        public string NameOfFatherorMother { get; set; }
        public string PatientAddress { get; set; }

        public string SocialSecurityNo { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonPhone { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportExpiredDate { get; set; }

        public string Allergic { get; set; }
        public string AllergicDesc { get; set; }
        public string Disability { get; set; }
        public string Smoking { get; set; }
        public string Diabetes { get; set; }
        public string Alcohol { get; set; }
        public string HIV { get; set; }
        public string TB { get; set; }
        public string Paternity { get; set; }
        public string Race { get; set; }
        public string Mobile { get; set; }
        public string LandLine { get; set; }
        public string Email { get; set; }
        public string pobox { get; set; }
        public string landmark { get; set; }


    }


}