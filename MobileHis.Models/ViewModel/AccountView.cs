
using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class AccountCreateView
    {


        [Display(ResourceType = typeof(Resource), Name = "Account_UserNo")]
        [Required]
        public string UserNo { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Name")]
        [Required]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Comm_Account")]
        [Required]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Password")]
        [Required]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_confirm_password")]
        [Required]
        [CompareAttribute("Password")]
        public string confirm_password { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Dept")]
        public int[] Acc2Dept { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_RegDept")]
        public int[] RegAcc2Dept { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Account_JobTitle")]
        // public int? Title_id { get; set; }
        public string Title { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Account_Tel")]
        public string Tel { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_Card")]
        public string Card { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Gender")]
        public string Gender { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Birthday")]
        public DateTime? Birthday { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Comment")]
        public string Comment { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Experience")]
        public string Experience { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Major")]
        public string Major { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_Expertise")]
        public string Expertise { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Account_Status")]
        public string Status { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "IsLockedOut")]
        public string IsLockedOut { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "IsDoctor")]
        public string IsDoctor { get; set; }

        public string[] Roles { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "LastLoginDate")]
        public DateTime? LastLoginDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "CreateDate")]
        public DateTime? CreateDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "ModDate")]
        public DateTime? ModDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "ModUser")]
        public string ModUser { get; set; }

        public byte[] Pic { get; set; }
    }

    public class AccountEditView
    {

        public string ID { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_UserNo")]
        public string UserNo { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Name")]
        [Required]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Email")]
        [Required]
        public string Email { get; set; }



        [Display(ResourceType = typeof(Resource), Name = "Account_Dept")]
        public int[] Acc2Dept { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_RegDept")]
        public int[] RegAcc2Dept { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_JobTitle")]
        //public int? Title_id { get; set; }
        public string Title { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Tel")]
        public string Tel { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_Card")]
        public string Card { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Gender")]
        public string Gender { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Birthday")]
        public DateTime? Birthday { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Comment")]
        public string Comment { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Experience")]
        public string Experience { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Major")]
        public string Major { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_Expertise")]
        public string Expertise { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Status")]
        public string Status { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "IsLockedOut")]
        public string IsLockedOut { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "IsDoctor")]
        public string IsDoctor { get; set; }

        public string[] Roles { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "LastLoginDate")]
        public DateTime? LastLoginDate { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "ModDate")]
        public DateTime? ModDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "ModUser")]
        public string ModUser { get; set; }

        public byte[] Pic { get; set; }
        public string ImagePath { get; set; }


    }

    public class myProfileEditView
    {

        public string ID { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_UserNo")]
        public string UserNo { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Name")]

        public string Name { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Email")]
        public string Email { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Account_Dept")]
        public string DeptName { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_JobTitle")]
        //public int? Title_id { get; set; }
        public string Title { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Tel")]
        public string Tel { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Gender")]
        public string Gender { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Birthday")]
        public DateTime? Birthday { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Comment")]
        public string Comment { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Experience")]
        public string Experience { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Major")]
        public string Major { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_Expertise")]
        public string Expertise { get; set; }
        public byte[] Pic { get; set; }
        public string ImgName { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "ModDate")]
        public DateTime? ModDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "ModUser")]
        public string ModUser { get; set; }


    }

    public class ChangepasswordView
    {
        [Display(ResourceType = typeof(Resource), Name = "Changepassword_Password")]
        [Required]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Changepassword_newPassword")]
        [Required]
        public string newPassword { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Changepassword_confirm_newPassword")]
        [Required]
        [CompareAttribute("newPassword")]
        public string confirm_newPassword { get; set; }

    }
}