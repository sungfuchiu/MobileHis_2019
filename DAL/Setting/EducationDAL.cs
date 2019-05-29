using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EducationDAL : IDDALBase<HealthEdu>
    {
        public IEnumerable<HealthEdu> GetEducationList(int TypeID)
        {
            Reads();
            return Entity
                .Where(a => a.HealthEdu_Type_CodeFile == TypeID)
                .OrderBy(a => a.HealthEdu_Type_CodeFile);
        }
    }
}
