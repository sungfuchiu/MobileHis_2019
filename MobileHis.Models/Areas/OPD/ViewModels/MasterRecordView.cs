
using MobileHis.Data;
using System.Collections.Generic;
namespace MobileHis.Models.Areas.OPD.ViewModels
{
    public class MasterRecordView
    {
        public OpdRegister Register { get; set; }

        public Patient Patient { get; set; }

        public OpdRecordView Record { get; set; }
        public List<OpdRecord> HistoryRecord { get; set; }
    }

}