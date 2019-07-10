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
    public class RoomModel : BaseAPIModel<Room>//, IGetCodeFileSelectList, IGetDepartmentSelectList
    {
        //public event GetCodeFileSelectList CodeFileSelectListEvent;
        //public event GetDepartmentSelectList DepartmentSelectListEvent;
        //public RoomModel(GetCodeFileSelectList codeFileSelectListEvent, GetDepartmentSelectList departmentSelectListEvent)
        //{
        //    CodeFileSelectListEvent = codeFileSelectListEvent;
        //    DepartmentSelectListEvent = departmentSelectListEvent;
        //}
        public RoomModel() { }
        public List<SelectListItem> AddAllowDept { get => DependencyResolver.Current.GetService<GetDepartmentSelectList>()(onlyRegistered:true); }
        public List<SelectListItem> UpdAllowDept { get => DependencyResolver.Current.GetService<GetDepartmentSelectList>()(onlyRegistered: true); }
        public List<SelectListItem> AddGuardianCategory { get => DependencyResolver.Current.GetService<GetDepartmentSelectList>()(itemType: "GD", hasEmpty:true); }
        public List<SelectListItem> AddGuardian { get => DependencyResolver.Current.GetService<GetDepartmentSelectList>()(hasEmpty: true); }
        public List<SelectListItem> UpdGuardianCategory { get => DependencyResolver.Current.GetService<GetDepartmentSelectList>()(itemType: "GD", hasEmpty: true); }
        public List<SelectListItem> UpdGuardian { get => DependencyResolver.Current.GetService<GetDepartmentSelectList>()(hasEmpty: true); }
        public int ID { get; set; }
        [MaxLength(5)]
        public string RoomNo { get; set; }
        [MaxLength(50)]
        public string RoomName { get; set; }
        public int? RoomMax { get; set; }
        public string Remark { get; set; }
        public int? Guardian_ID { get; set; }
        public string AllowDept { get; set; }
    }
}
