using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class KitView
    {
        public KitView()
        {
            OrderKitList = new List<OrderKitView>();
        }

       // private Guid _ID;
        /// <summary>
        /// 套件ID
        /// </summary>
        public Guid ID
        {
            get;
            set;
        }
        /// <summary>
        /// 套件代碼
        /// </summary>
        public string KitCode { get; set; }
        /// <summary>
        /// 套件說明
        /// </summary>
        public string KitDescription { get; set; }

        /// <summary>
        /// 主題
        /// </summary>
        [System.Web.Mvc.AllowHtml]
        public string Subjective { get; set; }

        /// <summary>
        /// 目的
        /// </summary>
        [System.Web.Mvc.AllowHtml]
        public string Objective { get; set; }

        /// <summary>
        /// ICD10 
        /// </summary>
        public string ICD10Code1 { get; set; }

        public string ICD10CodeName1 { get; set; }

        public string ICD10Code2 { get; set; }
        public string ICD10CodeName2 { get; set; }

        public string ICD10Code3 { get; set; }

        public string ICD10CodeName3 { get; set; }
        public string ICD10Code4 { get; set; }
        public string ICD10CodeName4 { get; set; }

        public List<OrderKitView> OrderKitList { get; set; }

    }
    public class OrderKitView
    {
        /// <summary>
        /// 醫令ID
        /// </summary>
        public int ID { get; set; }

        public Guid KitID { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public double Dose { get; set; }

        /// <summary>
        /// 單位
        /// </summary>
        public KeyValueOptions Unit { get; set; }

        /// <summary>
        /// 頻率
        /// </summary>
        public KeyValueOptions Frequency { get; set; }

        public KeyValueOptions Route { get; set; }

        /// <summary>
        /// 天數
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// 總數
        /// </summary>
        public double Quantity { get; set; }

        public Guid DrugID { get; set; }
    }

    public class KeyValueOptions
    {
        public string itemType { get; set; }
        public string text { get; set; }
        public int value { get; set; }
    }
}