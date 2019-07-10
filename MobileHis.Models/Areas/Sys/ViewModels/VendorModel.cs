using MobileHis.Data;
using MobileHis.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
    public class VendorModel : BaseAPIModel<Vendor>//, IGetCodeFileSelectList
    {
        //public VendorModel(GetCodeFileSelectList getList)
        //{
        //    CodeFileSelectListEvent = getList;
        //}
        //public VendorModel() { }
        //public event GetCodeFileSelectList CodeFileSelectListEvent;
        public List<SelectListItem> PayTypeList { get => DependencyResolver.Current.GetService<GetCodeFileSelectList>()(itemType:"PY",hasEmpty:true); }
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string ShortName { get; set; }
        public int? PayType { get; set; }
        [MaxLength(20)]
        public string Contact1 { get; set; }
        [MaxLength(20)]
        public string Contact2 { get; set; }
        [MaxLength(20)]
        public string Phone1 { get; set; }
        [MaxLength(20)]
        public string Phone2 { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string Fax { get; set; }
        [Required]
        public int Creator { get; set; }
        [Required]
        public bool Deleted { get; set; }

    }
}
