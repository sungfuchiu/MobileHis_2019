using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
    public class DrugDAL : GuidDALBase<Drug>
    {
        public void TitleContains(string words)
        {
            Entity = Entity.Where(a => a.Title.Contains(words));
        }
        public void DrugTypeIs(string drugType)
        {
            if (drugType.IsNullOrEmpty())
            {
                Entity = Entity.Where(a => string.IsNullOrEmpty(a.DrugType));
            }
            else
            {
                Entity = Entity.Where(a => a.DrugType == drugType);
            }
        }
        public void DrugHasAppearance()
        {
            Entity = Entity.Where(a => a.DrugAppearance != null);
        }
        public void DrugColorContains(IEnumerable<string> drugColors)
        {
            Entity = Entity.Where(
                a => a.DrugAppearance.Color != null 
                && drugColors.Contains(a.DrugAppearance.Color));
        }
        public void DrugMajorTypeContains(IEnumerable<string> drugMajorTypes)
        {
            Entity = Entity.Where(
                a => a.DrugAppearance.MajorType != null
                && drugMajorTypes.Contains(a.DrugAppearance.MajorType));
        }
        public void DrugShapeContains(IEnumerable<string> drugShapes)
        {
            Entity = Entity.Where(
                a => a.DrugAppearance.Shape != null
                && drugShapes.Contains(a.DrugAppearance.Shape));
        }
    }
}
