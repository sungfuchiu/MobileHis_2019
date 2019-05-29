using MobileHis.Data;
using MobileHis.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public IPagedList<HealthEdu> CategoryPageList { get; set; }
        public List<SelectListItem> AddItemType { get => CodeFileSelectListEvent(); }
        public List<SelectListItem> AddParentType { get => CodeFileSelectListEvent(hasEmpty: true); }
        public List<SelectListItem> UDPParentType { get => CodeFileSelectListEvent(hasEmpty: true); }

        public int ID { get; set; }
        [Required]
        public int HealthEdu_Type_CodeFile { get; set; }
        [MaxLength(50)]
        public string Guardian_Name { get; set; }
        public bool IsUsed { get; set; }
        public bool IsForLobbyUsed { get; set; }
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
    }
}
