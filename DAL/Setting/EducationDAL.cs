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
        public IEnumerable<HealthEdu> GetList(string keyword)
        {
            Reads();
            var educations = Entity
                .Where(a => a.CodeFile.CheckFlag != "D");
            if (keyword.IsNullOrEmpty())
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
    }
}
