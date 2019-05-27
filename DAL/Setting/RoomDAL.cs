using Common;
using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomDAL : IDDALBase<Room>
    {
        public IEnumerable<Room> GetList(string keyword = "")
        {
            Reads(a => a.Dept2Room);
            Entity = Entity
                .OrderBy(a => a.RoomNo)
                .Select(a => a)
                .WhereIf(
                !string.IsNullOrEmpty(keyword), 
                a => a.RoomNo.Contains(keyword)
                    || a.RoomName.Contains(keyword));
            
            //var data = GetAllWithNoTracking().Include("Dept2Room.Dept").OrderBy(x => x.RoomNo).Select(x => x);
            //if (!string.IsNullOrEmpty(keyword))
            //    data = data.Where(x =>
            //        x.RoomNo.Contains(keyword)
            //            || x.RoomName.Contains(keyword)
            //        );
            foreach(var item in Entity)
            {
                yield return item;
            }
            //return data.ToList();

        }
    }
}
