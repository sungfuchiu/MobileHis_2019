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
    public class CodeFileViewModel : IGetSelectList
    {
        public event GetSelectList SelectListEvent;
        public CodeFileViewModel(GetSelectList selectListEvent)
        {
            SelectListEvent = selectListEvent;
        }
        public CodeFileViewModel() { }
        int? page;
        public IPagedList<CodeFile> CategoryPageList { get; set; }
        public List<SelectListItem> AddItemType { get => SelectListEvent(); }
        public List<SelectListItem> AddParentType { get => SelectListEvent(); }
        public List<SelectListItem> UDPParentType { get => SelectListEvent(); }
        public List<SelectListItem> ItemTypes { get => SelectListEvent(selectedValue:ItemType); }
        public string Keyword { get; set; }
        public int Page
        {   get => page ?? 1;
            set => page = value;
        }

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
        public DateTime CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }
        public int? ParentCodeFile { get; set; }
        public string UserName { get; set; }
    }
}
