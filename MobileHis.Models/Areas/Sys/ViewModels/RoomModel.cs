using MobileHis.Data;
using MobileHis.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
    public class RoomModel : BaseAPIModel<Room>
    {
        public RoomModel(GetSelectList selectListEvent) :base(selectListEvent)
        {
        }
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
