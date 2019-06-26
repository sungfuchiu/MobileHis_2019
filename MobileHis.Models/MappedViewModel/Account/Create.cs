using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.XpressionMapper;
using MobileHis.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.MappedViewModel.Account
{
    public class Create : IHaveCustomMapping
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

        public void CreateMappings(IConfigurationProvider configuration)
        {

            configuration.BuildExecutionPlan(typeof(Data.Account), typeof(Create));
            configuration.CreateMapper();
        }
    }
}
