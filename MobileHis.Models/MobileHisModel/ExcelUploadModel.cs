using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.MobileHisModel
{
    public class ExcelMemberModel
    {
        public string Member { get; set; }
        public string MemberType { get; set; }
    }
    public class ExcelQuestionModel
    {
        public string type { get; set; }
        public string Question { get; set; }
        public string A { get; set; }
    }
    public class ExcelAccountModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CardNumber { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Role { get; set; }
        public string IsDoctor { get; set; }
    }
    public class ExcelDepartmentModle
    {
        public string DepartmentNo { get; set; }
        public string Category { get; set; }
        public string DepartmentName { get; set; }
    }
    public class ExcelJobTitle
    {
        public string code { get; set; }
    }
    public class ExcelPatientModel
    {
        public string HospitalNo { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string MidName { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
    }

    public class ExcelDrugModel
    {
        public string DrugName { get; set; }
        public string DrugCode { get; set; }
        public string OrderCode { get; set; }
    }
}
