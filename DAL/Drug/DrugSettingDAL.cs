using MobileHis.Data;
using MobileHis.Models.Areas.Drug.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DrugSettingDAL : DALBase<DrugSetting>
    {
        //public DrugSettingModelView GetOneSettingByDrugID(Guid DrugID)
        //{
        //    using (DrugDal dal = new DrugDal())
        //    {
        //        var SingleDrug = dal.GetOneDrugByID(DrugID);
        //        //db.Drug.Include("DrugSetting")
        //        //             .Where(x => x.GID == DrugID).FirstOrDefault();

        //        if (SingleDrug == null)
        //        {
        //            return null;
        //        }
        //        var SettingModel = new DrugSettingModelView()
        //        {
        //            Title = SingleDrug.Title,
        //            OrderCode = SingleDrug.OrderCode,
        //            DrugID = DrugID,
        //            Direction = SingleDrug.Direction,
        //            AlertMessage = SingleDrug.AlertMessage
        //        };
        //        using (CodeFileDal dal_c = new CodeFileDal())
        //        {
        //            if (SingleDrug.DrugSetting != null)
        //            {
        //                SettingModel.Days = SingleDrug.DrugSetting.Days;
        //                SettingModel.Dose = SingleDrug.DrugSetting.Dose;

        //                SettingModel.Route = SingleDrug.DrugSetting.Route;
        //                SettingModel.Frequency = SingleDrug.DrugSetting.Frequency;
        //                SettingModel.Quantity = SingleDrug.DrugSetting.Quantity;
        //            }
        //            SettingModel.Formulation = dal_c.GetName(SingleDrug.Formulation);
        //        }
        //        return SettingModel;
        //    }
        //}
    }
}
