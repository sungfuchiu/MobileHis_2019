using Common;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EducationDAL : IDDALBase<HealthEdu>
    {
        public IEnumerable<HealthEdu> GetList(string keyword= "")
        {
            Reads();
            var educations = Entity
                .Where(a => a.CodeFile.CheckFlag != "D");
            if (!keyword.IsNullOrEmpty())
            {
                educations = educations.Where(x =>
                        x.HealthEdu_Name.Contains(keyword)
                        || x.CodeFile.ItemDescription.Contains(keyword)
                    );
            }
            foreach (var item in educations.OrderBy(a => a.HealthEdu_Type_CodeFile))
            {
                yield return item;
            }
        }
        public IEnumerable<HealthEdu> GetEducationList(int TypeID)
        {
            Reads();
            foreach(var item in Entity
                .Where(a => a.HealthEdu_Type_CodeFile == TypeID)
                .OrderBy(a => a.HealthEdu_Type_CodeFile))
            {
                yield return item;
            }
        }
        public void DeleteIMG(int ID)
        {
            Reads();
            using (var tran = Entities.Database.BeginTransaction())
            {
                try
                {
                    var del = GetAll().FirstOrDefault(a => a.ID == id);

                    var files = del.Guardian.Guardian_File.Where(a => a.ID != del.ID).OrderByDescending(a => a.IsUsed).ThenBy(a => a.Show_Order).ToList();
                    Delete(del);
                    for (int i = 0; i < files.Count; i++)
                    {
                        var g = files[i];
                        g.Show_Order = i + 1;
                    }

                    var s = Storage.GetStorage(StorageScope.GuardianUpload);
                    s.Delete(del.FileName, del.Guardian_ID);
                    Save();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
            }
        }
    }
}
