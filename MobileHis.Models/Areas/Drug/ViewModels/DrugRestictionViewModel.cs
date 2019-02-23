
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    //public class DrugRestictionViewModel
    //{
    //    public MobileHis.Models.Drug Drug { get; set; }

    //    public string RestictName { get; set; }
    //    public object Restict { get; set; }
    //}
    public class RestictionDataViewmodel
    {
        public RestictionDataViewmodel()
        {
            data = new List<DrugRestictionMasterViewModel>();
        }
        public List<DrugRestictionMasterViewModel> data;
    }
    public class DrugRestictionMasterViewModel
    {
        public DrugRestictionMasterViewModel()
        {
            Restiction = new List<DrugRestictionDetail>();
            Drugmodel = new DrugViewModel();
        }
        public DrugViewModel Drugmodel { get; set; }
        public List<DrugRestictionDetail> Restiction { get; set; }

    }
    public class DrugRestictionDetail
    {
        public DrugRestictionDetail()
        {
            Drugmodel = new DrugViewModel();
        }
        public DrugViewModel Drugmodel { get; set; }
        public string Grade { get; set; }
        public int ID { get; set; }
    }

}