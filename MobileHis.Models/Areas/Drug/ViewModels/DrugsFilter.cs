
using System.Collections.Generic;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugsFilter //: MobileHis.Models.PageFilter, MobileHis.Models.IFilterableFilter<MobileHis.Data.Drug>, MobileHis.Models.ISortableFilter<MobileHis.Data.Drug>
    {
        public int? page { get; set; }
        List<SelectDrugColor> _drugColor;
        List<SelectDrugShape> _drugShape;
        List<SelectDrugType> _drugType;

        public DrugsFilter()
        {
            _drugColor = new List<SelectDrugColor>();
            _drugShape = new List<SelectDrugShape>();
            _drugType = new List<SelectDrugType>();
        }
        //public DrugsFilter()
        //{
        //    AddFilerCodit();
        //}
        public string DrugTitle { get; set; }
        public string DrugType { get; set; }
        public string DrugCode { get; set; }
        public List<SelectDrugColor> DrugColor { get { return _drugColor; } set { _drugColor = value; } }
        public List<SelectDrugType> DrugMajorType { get { return _drugType; } set { _drugType = value; } }
        public List<SelectDrugShape> DrugShape { get { return _drugShape; } set { _drugShape = value; } }

        //public void AddFilerCodit()
        //{
        //    if (this != null)
        //    {
        //        Reflection[] refarray = Reflection.GetInstanceInfo(this);
        //        foreach (Reflection r in refarray) {
        //            CodeFileDal dal = new CodeFileDal();
        //            switch (r.ObjName)
        //            {
        //                case "DrugColor":
        //                    this.DrugColor = dal.GetListByitemType("CO").Select(x => new SelectDrugColor
        //                    {
        //                        IsSelected = false,
        //                        ID = x.ID,
        //                        Description = x.ItemDescription

        //                    }).ToList();
        //                    break;
        //                case "DrugMajorType":
        //                    this.DrugMajorType = dal.GetListByitemType("TP").Select(x => new SelectDrugType
        //                    { 
        //                            IsSelected =false,
        //                            ID = x.ID,
        //                            Description = x.ItemDescription
        //                    }).ToList();
        //                    break;
        //                case "DrugShape":
        //                    this.DrugShape = dal.GetListByitemType("SP").Select(x => new SelectDrugShape
        //                    {
        //                        IsSelected = false,
        //                        ID = x.ID,
        //                        Description = x.ItemDescription
        //                    }).ToList();
        //                    break;

        //            }
        //        }

        //    } 
        //}

        //public IQueryable<MobileHis.Data.Drug> Filter(IQueryable<MobileHis.Data.Drug> query)
        //{
        //    if (!string.IsNullOrEmpty(DrugType))
        //    {
        //        query = query.Where(x => x.DrugType==DrugType);
        //    }
        //    if (!string.IsNullOrEmpty(DrugTitle))
        //    {
        //        query = query.Where(x => x.Title.Contains(DrugTitle));
        //    }
        //    if (DrugColor.Any(x => x.IsSelected))
        //    {
        //        var ColorConditions = DrugColor.Where(x => x.IsSelected).Select(x => x.ID).ToList();
        //        var IDList = ColorConditions.ConvertAll(x => x.ToString());
        //        query = query.Where(x => IDList.Contains(x.DrugAppearance.Color));
        //    }
        //    if (DrugMajorType.Any(x => x.IsSelected))
        //    {
        //        var TypeConditions = DrugMajorType.Where(x => x.IsSelected).Select(x => x.ID).ToList();
        //        var IDList = TypeConditions.ConvertAll(x => x.ToString());
        //        query = query.Where(x => IDList.Contains(x.DrugAppearance.MajorType));
        //    }
        //    if (DrugShape.Any(x => x.IsSelected))
        //    {
        //        var ShapeConditions = DrugShape.Where(x => x.IsSelected).Select(x => x.ID).ToList();
        //        var IDList = ShapeConditions.ConvertAll(x => x.ToString());
        //        query = query.Where(x => IDList.Contains(x.DrugAppearance.Shape));
        //    }
        //    return query;
        //}

        //public IOrderedQueryable<MobileHis.Data.Drug> Sort(IQueryable<MobileHis.Data.Drug> query)
        //{

        //    return query.OrderBy(d => d.DrugCode);
        //}
    }
    public class SelectDrugColor
    {
        public bool IsSelected { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }
    }
    public class SelectDrugType
    {
        public bool IsSelected { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }
    }
    public class SelectDrugShape
    {
        public bool IsSelected { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }
    }
}