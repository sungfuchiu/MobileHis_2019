using LocalRes;
using MobileHis.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugSettingModelView : IGetSelectList
    {
        private string _DrugName;
        private int _Days = 0;
        private double _Quantity = 0.0;
        private double _Dose = 0.0;
        //public delegate List<System.Web.Mvc.SelectListItem> _GetSelectList(string itemType, string selectedValue = "", bool hasEmpty = false);
        public event GetSelectList SelectListEvent;

        public DrugSettingModelView(GetSelectList selectListEvent)
        {
            SelectListEvent = selectListEvent;
        }
        public DrugSettingModelView()
        {
        }
        public List<System.Web.Mvc.SelectListItem> FrequencyList { get => SelectListEvent("FQ"); }
        public List<System.Web.Mvc.SelectListItem> RouteList { get => SelectListEvent("RU"); }

        [Required]
        public Guid DrugID { get; set; }
        public string OrderCode { get; set; }
        public string Title { get; set; }

        public string DrugName
        {
            get
            {
                return _DrugName;
            }
            set
            {
                _DrugName = string.Format("[{0}]{1}", OrderCode, Title);
            }
        }

        //public string DrugCode { get; set; }

        [RegularExpression(@"[0-9]+", ErrorMessage = "Dose must be number format.")]
        [Display(ResourceType = typeof(Resource), Name = "Drug_Dose")]
        public double? Dose
        {
            get;
            set;
        }

        [Display(ResourceType = typeof(Resource), Name = "Drug_Formulation")]
        public string Formulation { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Drug_Frequency")]
        public string Frequency { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Drug_Route")]
        public string Route { get; set; }

        //[RegularExpression(@"[0-9]+", ErrorMessage = "Dose Days be number format.")]
        [Display(ResourceType = typeof(Resource), Name = "Drug_Days")]
        public int? Days
        {
            get;
            set;
        }
        [Display(ResourceType = typeof(Resource), Name = "Drug_Total")]
        //[RegularExpression(@"[0-9]+", ErrorMessage = "Quantity must be number format.")]       
        public double? Quantity
        {
            get; set;

        }

        public string Direction { get; set; }
        public string AlertMessage { get; set; }
    }
}