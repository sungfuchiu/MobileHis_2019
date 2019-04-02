using MobileHis.Data;
using MobileHis.Models.Areas.Drug.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DrugAppearanceDAL : DALBase<DrugAppearance>
    {
        private IQueryable<string> IDList;
        public enum Appearance
        {
            Color,
            Shape,
            MajorType
        }
        public List<string> GetIDs(Appearance appearance)
        {
            Reads();
            SelectAppearance(appearance);
            Distinct(IDList);
            return ReadsResult(IDList).ToList();
        }
        private void SelectAppearance(Appearance appearance)
        {
            switch (appearance)
            {
                case Appearance.Color:
                    IsColorExist();
                    IDList = Select(a => a.Color);
                    break;
                case Appearance.Shape:
                    IsShapeExist();
                    IDList = Select(a => a.Shape);
                    break;
                default:
                    IsMajorTypeExist();
                    IDList = Select(a => a.MajorType);
                    break;
            }
        }
        private void IsColorExist()
        {
            Entity = Entity.Where(a => a.Color != null && a.Color.Length > 0);
        }
        private void IsShapeExist()
        {
            Entity = Entity.Where(a => a.Shape != null && a.Shape.Length > 0);
        }
        private void IsMajorTypeExist()
        {
            Entity = Entity.Where(a => a.MajorType != null && a.MajorType.Length > 0);
        }
    }
}
