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
    //public class ICD10ViewModel
    //{
    //    [Required]
    //    [MaxLength(10)]
    //    public string ICD10Code { get; set; }
    //    [Required]
    //    [MaxLength]
    //    public string StdName { get; set; }
    //    [Required]
    //    [MaxLength(8)]
    //    public string Type { get; set; }
    //}

    public class ICD10ViewModel : BaseSearchModel//, IGetCodeFileSelectList
    {
        //public event GetCodeFileSelectList CodeFileSelectListEvent;
        public string Type { get; set; }
        public IPagedList<ICD10> ICD10PageList { get; set; }
        public List<SelectListItem> AddType { get => DependencyResolver.Current.GetService<GetCodeFileSelectList>()(itemType: "CD"); }
        public List<SelectListItem> SearchType { get => DependencyResolver.Current.GetService<GetCodeFileSelectList>()(itemType: "CD", hasEmpty: true); }
        public string ICD10Code { get; set; }
    }
}
