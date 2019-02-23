using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.ApiModel
{
    public class CallNumberResponseModel
    {
        public bool success { get; set; }
        public string message { get; set; }

        public List<CallNumberModel> list { get; set; }
    }
    public class CallNumberModel
    {
        public string shift { get; set; }//時段
        public string shiftrange { get; set; }//時段區間

        public List<ParentDept> parentdept { get; set; }//大科別陣列
    }

    public class ParentDept
    {
        public string parentdeptname { get; set; } //大科別名稱(CodeFile)
        public List<smallDept> dept { get; set; }//小科別陣列
    }

    public class smallDept
    {
        public string deptname { get; set; }//科別名稱
        public List<opdroom> roomlist { get; set; }//每一個診間
    }
    public class opdroom
    {
        public string doctorname { get; set; }//醫師姓名
        public string roomname { get; set; }//診間名稱
        public int callnumber { get; set; }//看診號碼
    }

    public class opdroomShowPatientList : opdroom
    {
        public List<PatientList> patientlist;//取得該診間掛號清單
    }

    public class PatientList
    {
        public int seq { get; set; }//病患掛號號碼
        public string name { get; set; }//病患姓名
        public string status { get; set; }//病患目前看診狀態(W等待、I正在看、F已看完)
    }

    public class CallGuardianResponseModel
    {
        public bool success { get; set; }
        public string message { get; set; }
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string updatedDate { get; set; }

        public List<GuardianModel> guardian_list { get; set; }
    }
    public class GuardianModel
    {
        public string file_url { get; set; }//檔案網址路徑
        public string show_seconds { get; set; }//顯示秒數
        public string show_order { get; set; }//顯示順序
    
    }
}
