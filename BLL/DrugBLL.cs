using Common;
using DAL;
using MobileHis.Data;
using MobileHis.Models.Areas.Drug.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DrugBLL : BaseBLL<Drug>
    {
        public DrugBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
        }
        public List<DrugViewModel> Filter(DrugsFilter filter)
        {
            using (DrugDAL dal = new DrugDAL())
            {
                dal.Reads(x => x.DrugStock);
                dal.DrugTypeIs(filter.DrugType);
                if(IsDrugHasAppearance(filter))
                {
                    dal.DrugHasAppearance();
                    dal.DrugColorContains(filter.DrugColor.Where(a => a.IsSelected).Select(a => a.ID));
                    dal.DrugMajorTypeContains(filter.DrugMajorType.Where(a => a.IsSelected).Select(a => a.ID));
                    dal.DrugShapeContains(filter.DrugShape.Where(a => a.IsSelected).Select(a => a.ID));
                }
                return dal.ReadsResult().ToList().OrderBy(a => a.Title).Select(a => DrugViewModel.Load(a, null)).ToList();
            }
        }
        private bool IsDrugHasAppearance(DrugsFilter filter)
        {
            return filter.DrugShape.Any(a => a.IsSelected) || 
                filter.DrugColor.Any(a => a.IsSelected) || 
                filter.DrugMajorType.Any(a => a.IsSelected);
        }
    }
}
