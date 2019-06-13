using Common;
using MobileHis.Data;
using MobileHis.Models.Areas.Drug.ViewModels;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Service
{
    public interface IDrugAppearanceService
    {
        DrugsFilter NewFilter();
    }
    public class DrugAppearanceService : GenericService<DrugAppearance>, IDrugAppearanceService
    {
        private IQueryable<CodeFile> _codeFile;
        private IQueryable<DrugAppearance> _drugAppearance;
        private IQueryable<string> _IDList;
        public DrugAppearanceService(IValidationDictionary validationDictionary, IUnitOfWork inDB) : base(inDB)
        {
            InitialiseIValidationDictionary(validationDictionary);
        }
        public enum Appearance
        {
            Color,
            Shape,
            MajorType
        }
        public DrugsFilter NewFilter()
        {
            List<string> colorIDs;
            List<string> shapeIDs;
            List<string> majorTypeIDs;
            colorIDs = GetIDs(Appearance.Color);
            shapeIDs = GetIDs(Appearance.Shape);
            majorTypeIDs = GetIDs(Appearance.MajorType);
            List<SelectDrugColor> color_list = GetListByIds(colorIDs,
                    a => new SelectDrugColor(a.ItemDescription, a.ID)).ToList();
            List<SelectDrugShape> shape_list = GetListByIds(shapeIDs,
                    a => new SelectDrugShape(a.ItemDescription, a.ID)).ToList();
            List<SelectDrugType> type_list = GetListByIds(majorTypeIDs,
                    a => new SelectDrugType(a.ItemDescription, a.ID)).ToList();

                return new DrugsFilter()
                {
                    DrugColor = color_list,
                    DrugMajorType = type_list,
                    DrugShape = shape_list,
                    DrugTitle = "",
                    DrugType = ""
                };
        }
        private List<T> GetListByIds<T>(List<string> list, Expression<Func<CodeFile, T>> expression)
        {
            _codeFile = db.Repository<CodeFile>().ReadAll();
            List<int> intList = new List<int>();
            list.ForEach(a => intList.Add(int.Parse(a)));
            _codeFile = _codeFile.Where(a => intList.Contains(a.ID));
            return _codeFile.Select(expression).ToList();
        }
        private List<string> GetIDs(Appearance appearance)
        {
            _drugAppearance = db.Repository<DrugAppearance>().ReadAll();
            SelectAppearance(appearance);
            return _IDList.Distinct().ToList();
        }
        private void SelectAppearance(Appearance appearance)
        {
            switch (appearance)
            {
                case Appearance.Color:
                    IsColorExist();
                    _IDList = _drugAppearance.Select(a => a.Color);
                    break;
                case Appearance.Shape:
                    IsShapeExist();
                    _IDList = _drugAppearance.Select(a => a.Shape);
                    break;
                default:
                    IsMajorTypeExist();
                    _IDList = _drugAppearance.Select(a => a.MajorType);
                    break;
            }
        }
        private void IsColorExist()
        {
            _drugAppearance = _drugAppearance.Where(a => a.Color != null && a.Color.Length > 0);
        }
        private void IsShapeExist()
        {
            _drugAppearance = _drugAppearance.Where(a => a.Shape != null && a.Shape.Length > 0);
        }
        private void IsMajorTypeExist()
        {
            _drugAppearance = _drugAppearance.Where(a => a.MajorType != null && a.MajorType.Length > 0);
        }
    }
}
