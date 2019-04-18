
using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class PatientCreateView
    {

        [Display(ResourceType = typeof(Resource), Name = "Patient_ID")]
        public string PatientID { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "National_ID")]
        public string NationalID { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_First_Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_SurName")]
        [Required]
        public string SurName { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Language")]
        public string Language { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Gender")]
        public string Gender { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Birthday")]
        [Required]
        public DateTime? Birthday { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailFormatError")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Married")]
        public int? Married { get; set; }

        public HttpPostedFileBase Avatar { get; set; }
        public string[] imgAttachment { get; set; }
        public string CamAvatar { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Mobile_Phone")]
        public string MobilePhone { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Ground_Line")]
        public string Tel { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Address")]
        public string Address { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_AddressZipcode")]
        public string AddressZipcode { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_PostAddress")]
        public string PostAddress { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_PostAddressZipcode")]
        public string PostAddressZipcode { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_NextOfKinAddress")]
        public string NextOfKinAddress { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_NextOfKinAddressZipcode")]
        public string NextOfKinAddressZipcode { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_District")]
        public int? District { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_TA")]
        public int? TA { get; set; }
        public string TA_Others { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Village")]
        public int? Village { get; set; }
        public string Village_Others { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Occupation")]
        public int? Occupation { get; set; }
        public string Occupation_Others { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Nationality")]
        [Required]
        public int? Nationality { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Guardian_Name")]
        public string GuardiansName { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Relationship")]
        public int? GuardiansRelation { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Patient_Guardian_Phone")]
        public string GuardiansPhone { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Insurance")]
        public int? Insurance { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_InsuranceCategory")]
        public int? InsuranceCategory { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_FirstVisitDate")]
        public DateTime? FirstVisitDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_LastVisitDate")]
        public DateTime? LastVisitDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_FirstAdmission")]
        public DateTime? FirstAdmission { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_LastAdmission")]
        public DateTime? LastAdmission { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_ArrearsTimes")]
        public int? ArrearsTimes { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_BloodType")]
        public string BloodType { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Allergic")]
        public bool Allergic { get; set; }

        public string AllergicDesc { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_HIV")]
        public bool HIV { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_TB")]
        public bool TB { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Disability")]
        public bool Disability { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Status")]
        public string Status { get; set; }

        public string Patient_FingerData { get; set; }
        public string Patient_FingerImageData { get; set; }

        #region Marshall Island



        [Display(ResourceType = typeof(Resource), Name = "Patient_RegAtoll")]
        public int? RegAtoll { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Mid_Name")]
        public string MidName { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Ethnicity")]
        [Required]
        public int? Ethnicity { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Race")]
        public int? Race { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_PovertyLevel")]
        public int? PovertyLevel { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Birth_country")]
        [Required]
        public int Birth_Country { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Birth_Atoll")]
        public int? Birth_Atoll { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Birth_Village")]
        public int? Birth_Village { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Religion")]
        public int? Religion { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Marshall_Zone")]
        public int? Marshall_Zone { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Marshall_Village")]
        public int? Marshall_Village { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Marshall_Atoll")]
        public int? Marshall_Atoll { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Country")]
        public int? Country { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_MotherFName")]
        public string MotherFName { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_MotherMName")]
        public string MotherMName { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_MotherLName")]
        public string MotherLName { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_FatherFName")]
        public string FatherFName { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_FatherMName")]

        public string FatherMName { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_FatherLName")]
        public string FatherLName { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_HomeAtoll")]
        public int? HomeAtoll { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_NameOfSchool")]
        public int? NameOfSchool { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_LevelinSchool")]
        public int? LevelInSchool { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Company")]

        public string Company { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Employer")]
        public string Employer { get; set; }
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Patient_From")]
        public MobileHis.Data.PatientFrom PatientFrom { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "StateCityAtoll")]
        public int? StateCityAtoll { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_SocialSecurityNo")]
        public string SocialSecurityNo { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_ContactPerson")]
        public string ContactPerson { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_ContactPersonPhone")]
        public string ContactPersonPhone { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_ContactPersonRelationship")]
        public int? ContactPersonRelationship { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_PassportIssueDate")]
        public DateTime? PassportIssueDate { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_PassportExpiredDate")]
        public DateTime? PassportExpiredDate { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Smoking")]
        public bool Smoking { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Diabetes")]
        public bool Diabetes { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Alcohol")]
        public bool Alcohol { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Patient_Pobox")]
        public string POBOXNo { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_LandMark")]
        public string Landmark { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Longitude")]
        public float? Longitude { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Latitude")]
        public float? Latitude { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Weto")]
        public int? Household_Weto { get; set; }
        public string Household_Text { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Household_Address")]
        public string Household_Address { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Household_Head")]
        [MaxLength(50)]
        public string Household_Head { get; set; }
        public string Household_Head_PatientId { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Patient_Alab")]
        [MaxLength(50)]
        public string Alab { get; set; }
        #endregion

    }


}