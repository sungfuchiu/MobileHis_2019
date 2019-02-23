using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Report
{
    public struct ReportsDoctorScheduleModel//醫生排班報表
    {
        public string SchDate { get; set; }//看診日期時間
        public DateTime SchDateTime { get; set; }
        public string shift { get; set; }//時段
        public string deptname { get; set; }//科別名稱(小科別)
        public string roomname { get; set; }//診間名稱
        public string doctorname { get; set; }//醫師姓名
        public string Canceled { get; set; } //是否被取消
    }
}