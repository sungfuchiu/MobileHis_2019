using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using MobileHis.Data;
using System.Web.Mvc;
using MobileHis.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
    public class CodeFileViewModel : BaseSearchModel, IGetSelectList
    {
        public event GetSelectList SelectListEvent;
        public CodeFileViewModel(GetSelectList selectListEvent)
        {
            SelectListEvent = selectListEvent;
        }
        public CodeFileViewModel() { }
        DateTime? modifiedDate;
        DateTime? createDate;
        public IPagedList<CodeFile> CategoryPageList { get; set; }
        public List<SelectListItem> AddItemType { get => SelectListEvent(); }
        public List<SelectListItem> AddParentType { get => SelectListEvent(hasEmpty: true); }
        public List<SelectListItem> UDPParentType { get => SelectListEvent(hasEmpty:true); }
        public List<SelectListItem> ItemTypes { get => SelectListEvent(selectedValue:ItemType, hasEmpty: true); }

        public int ID { get; set; }
        [MaxLength(2)]
        public string ItemType { get; set; }
        [MaxLength(8)]
        public string ItemCode { get; set; }
        [MaxLength(50)]
        public string ItemDescription { get; set; }
        [MaxLength(50)]
        public string Remark { get; set; }
        [MaxLength(1)]
        public string CheckFlag { get; set; }
        public DateTime CreateDate {
            get => createDate ?? DateTime.Now;
            set => createDate = value;
        }
        public DateTime ModDate {
            get => modifiedDate ?? DateTime.Now;
            set => modifiedDate = value;
        }
        [MaxLength(100)]
        public string ModUser { get; set; }
        public int? ParentCodeFile { get; set; }
    }
}
