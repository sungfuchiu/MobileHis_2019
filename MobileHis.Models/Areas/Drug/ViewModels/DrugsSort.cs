using System.Linq;
using MobileHis.Models.AbstractModel;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugsSort //: DecoratorDrug
    {
        public string DrugCode;
        
        //public override IOrderedQueryable<MobileHis.Data.Drug> Sort(IQueryable<MobileHis.Data.Drug> query)
        //{
        //    IQueryable<MobileHis.Data.Drug> Sortdata = null;
        //    Sortdata = base.Sort(query);

        //    if (!string.IsNullOrEmpty(DrugCode))
        //    {
        //        Sortdata = Sortdata.Where(x => x.DrugCode == DrugCode);
        //        return Sortdata.OrderBy(x => x.DrugCode);
        //    }
        //    else {
        //        return null;
        //    }
        //}
    }
}