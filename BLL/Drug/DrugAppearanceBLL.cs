using DAL;
using MobileHis.Models.Areas.Drug.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DrugAppearanceBLL
    {
        public DrugsFilter NewFilter()
        {
            List<string> colorIDs;
            List<string> shapeIDs;
            List<string> majorTypeIDs;
            using (DrugAppearanceDAL dal = new DrugAppearanceDAL())
            {
                colorIDs = dal.GetIDs(DrugAppearanceDAL.Appearance.Color);
                shapeIDs = dal.GetIDs(DrugAppearanceDAL.Appearance.Shape);
                majorTypeIDs = dal.GetIDs(DrugAppearanceDAL.Appearance.MajorType);
            }
            using (CodeFileDAL dal = new CodeFileDAL())
            {
                List<SelectDrugColor> color_list = dal.GetListByIds( colorIDs, 
                    a => new SelectDrugColor
                    {
                        Description = a.ItemDescription,
                        ID = a.ID.ToString(),
                        IsSelected = false
                    }).ToList();

                List<SelectDrugShape> shape_list = dal.GetListByIds( shapeIDs, 
                    a => new SelectDrugShape
                    {
                        Description = a.ItemDescription,
                        ID = a.ID.ToString(),
                        IsSelected = false
                    }).ToList();
                List<SelectDrugType> type_list = dal.GetListByIds( majorTypeIDs, 
                    a => new SelectDrugType
                    {
                        Description = a.ItemDescription,
                        ID = a.ID.ToString(),
                        IsSelected = false
                    }).ToList();

                return new DrugsFilter()
                {
                    DrugColor = color_list,
                    DrugMajorType = type_list,
                    DrugShape = shape_list,
                    DrugTitle = "",
                    DrugType = ""
                };
            }
        }
    }
}
