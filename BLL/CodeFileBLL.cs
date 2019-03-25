using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL;

namespace BLL
{
    public class CodeFileBLL
    {
        /// <summary>
        /// 拿取下拉式選單
        /// </summary>
        /// <returns></returns>
        public List<System.Web.Mvc.SelectListItem> GetDropDownList(string itemType, string selectedValue = "", bool hasEmpty = false)
        {
            var list = new List<System.Web.Mvc.SelectListItem>();
            if (hasEmpty)
            {
                list.Add(new SelectListItem { Text = LocalRes.Resource.Comm_Select, Value = "" });
            }
            using (CodeFileDAL dal = new CodeFileDAL())
            {
                var datalist = dal.GetListByitemType(itemType).Select(a => new SelectListItem
                {
                    Value = a.ID.ToString(),
                    Text = a.ItemDescription,
                    Selected = string.IsNullOrEmpty(selectedValue) ? false : a.ID.ToString() == selectedValue
                });
                list.AddRange(datalist);
            }
            return list;
        }
    }
}
