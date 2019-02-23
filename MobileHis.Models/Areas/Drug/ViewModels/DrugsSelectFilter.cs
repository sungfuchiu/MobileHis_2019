
using MobileHis.Models.AbstractModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugsSelectFilter 
    {

        public string OrderCode;
        public string Title;
        public Guid? FilerDrugID;
        public string FilterType;
        //public override IQueryable<MobileHis.Data.Drug> Filter(IQueryable<MobileHis.Data.Drug> query)
        //{
        //    IQueryable<MobileHis.Data.Drug> Querydata = null;
        //    Querydata = base.Filter(query);
        //    if (!string.IsNullOrEmpty(OrderCode))
        //    {
        //        Querydata = Querydata.Where(x => x.OrderCode.Contains(OrderCode) || x.Title.Contains(Title));
        //        if (FilerDrugID.HasValue && FilerDrugID != Guid.Empty)
        //        {
        //            Querydata = Querydata.Where(x => x.GID != FilerDrugID);
        //            Querydata = GetAvailableDrug(Querydata);
        //        }

        //        return Querydata;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        //public override IOrderedQueryable<MobileHis.Data.Drug> Sort(IQueryable<MobileHis.Data.Drug> query)
        //{
        //    IQueryable<MobileHis.Data.Drug> Sortdata = null;
        //    Sortdata = base.Sort(query);

        //    return Sortdata.OrderBy(x => x.DrugCode);
        //}
        /// <summary>
        /// 取得可用的Drug
        /// </summary>
        /// <param name="DrugID"></param>
        //private IQueryable<MobileHis.Data.Drug> GetAvailableDrug(IQueryable<MobileHis.Data.Drug> Drug)
        //{
        //    List<Guid> DrugFilterList = new List<Guid>();
        //    using (RestrictionDal dal = new RestrictionDal())
        //    {
        //        DrugFilterList.AddRange(dal.GetRestrictionsListByID(FilerDrugID, "D"));
        //        DrugFilterList.AddRange(dal.GetRestrictionsListByID(FilerDrugID, "R"));
        //    }
        //    DrugFilterList = DrugFilterList.Distinct().ToList();
        //    foreach (var id in DrugFilterList)
        //    {
        //        Drug = Drug.Where(x => x.GID != id);
        //    }
        //    return Drug;
        //}
    }
}