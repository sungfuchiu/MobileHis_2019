using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dept2RoomDAL : IDDALBase<Dept2Room>
    {
        public void Insert(string allowDept, int roomId)
        {
             foreach (var item in allowDept.Split(','))
             {
                 Add(new Dept2Room()
                 {
                     Dept_id = int.Parse(item),
                     Room_id = roomId
                 });

             }
             Save();
        }
    }
}
