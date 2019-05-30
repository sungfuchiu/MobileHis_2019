using MobileHis.Data;
using MobileHis.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
    public class EducationModel : BaseSearchModel, IGetCodeFileSelectList
    {
        public event GetCodeFileSelectList CodeFileSelectListEvent;
        public EducationModel(GetCodeFileSelectList selectListEvent)
        {
            CodeFileSelectListEvent = selectListEvent;
        }
        public EducationModel() { }
        DateTime? modifiedDate;
        DateTime? createDate;
        public IPagedList<HealthEdu> EducationPageList { get; set; }
        public List<SelectListItem> AddCategory { get => CodeFileSelectListEvent(itemType: "GD", selectedValue: HealthEdu_Type_CodeFile.ToString() ); }

        public int ID { get; set; }
        [Required]
        public int HealthEdu_Type_CodeFile { get; set; }
        [MaxLength(50)]
        public string HealthEdu_Name { get; set; }
        public bool IsUsed { get; set; }
        public bool IsForLobbyUsed { get; set; }
        public string QueueMsg { get; set; }
        public string CategoryName { get; set; }
        public IList<HttpPostedFileBase> UploadFiles { get; set; }
        public IList<HealthEdu_File> EducationFiles { get; set; }
        public DateTime CreateDate
        {
            get => createDate ?? DateTime.Now;
            set => createDate = value;
        }
        public DateTime ModDate
        {
            get => modifiedDate ?? DateTime.Now;
            set => modifiedDate = value;
        }
        public string ModUser
        {
            get => "Admin";
        }
    }
    //public class EducationPageMdoel
    //{
    //    public int ID { get; set; }
    //    [Required]
    //    public int HealthEdu_Type_CodeFile { get; set; }
    //    [MaxLength(50)]
    //    public string HealthEdu_Name { get; set; }
    //    public bool IsUsed { get; set; }
    //    public bool IsForLobbyUsed { get; set; }
    //    public string QueueMsg { get; set; }
    //    public DateTime? CreateDate { get; set; }
    //    public DateTime? ModDate { get; set; }
    //    [MaxLength(100)]
    //    public string ModUser { get; set; }
    //    public string CategoryName { get; set; }
    //    public IList<HealthEdu_File> EducationFile { get; set; }
    //}
}
