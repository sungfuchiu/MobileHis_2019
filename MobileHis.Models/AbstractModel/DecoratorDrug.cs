
using System.Linq;

namespace MobileHis.Models.AbstractModel
{
    //public abstract class DecoratorDrug : PageFilter, IFilterableFilter<Drug>, ISortableFilter<Drug>
    //{
    //    private ISortableFilter<Drug> sort;
    //    private IFilterableFilter<Drug> filter;
    //    public void SetDecorator(ISortableFilter<Drug> sort, IFilterableFilter<Drug> filter)
    //    {
    //        this.sort = sort;
    //        this.filter = filter;
    //    }
    //    public virtual IQueryable<MobileHis.Data.Drug> Filter(IQueryable<MobileHis.Data.Drug> query)
    //    {
    //        IQueryable<MobileHis.Data.Drug> Querydata = null;
    //        if (filter != null)
    //        {
    //            Querydata = this.filter.Filter(query);
    //        }
    //        return Querydata;
    //    }
    //    public virtual IOrderedQueryable<MobileHis.Data.Drug> Sort(IQueryable<MobileHis.Data.Drug> query)
    //    {
    //        IOrderedQueryable<MobileHis.Data.Drug> SortData = null;
    //        if (sort != null)
    //        {
    //            SortData = this.sort.Sort(query);
    //        }
    //        return SortData;
    //    }
    //}
}