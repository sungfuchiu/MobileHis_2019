using MobileHis.Data;
using MobileHis.Models.Interface;
using MobileHis.Models.ViewModel;
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
    public class DepartmentIndexModel : BaseSearchModel, IGetSelectList
    {
        public event GetSelectList SelectListEvent;
        public DepartmentIndexModel(GetSelectList selectListEvent)
        {
            SelectListEvent = selectListEvent;
        }
        public DepartmentIndexModel() { }
        public IPagedList<DepartmentModel> DepartmentPageList { get; set; }
        public List<SelectListItem> AddUnit{ get => SelectListEvent(itemType:"DU"); }
        public List<SelectListItem> AddCategory { get => SelectListEvent(itemType: "DP"); }
        public List<SelectListItem> UDPUnit { get => SelectListEvent(itemType: "DU"); }
        DateTime? modifiedDate;
        DateTime? createDate;
        public int ID { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        [MaxLength(2)]
        [Required]
        public string DepNo { get; set; }
        [MaxLength(50)]
        [Required]
        public string DepName { get; set; }
        [MaxLength(20)]
        public string Clinic { get; set; }
        [MaxLength(1)]
        public string IsRegistered { get; set; }
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
        [MaxLength(100)]
        public string ModUser { get; set; }
    }
    public class DepartmentModel
    {
        public int ID { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        [Required]
        [MaxLength(2)]
        public string DepNo { get; set; }
        [Required]
        [MaxLength(50)]
        public string DepName { get; set; }
        [MaxLength(20)]
        public string Clinic { get; set; }
        [MaxLength(1)]
        public string IsRegistered { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }
    }
}
