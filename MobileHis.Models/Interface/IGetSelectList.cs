using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Interface
{
    public delegate List<System.Web.Mvc.SelectListItem> GetCodeFileSelectList(
        string itemType = "", 
        string selectedValue = "", 
        bool hasEmpty = false, 
        bool hasAll = false, 
        bool onlyRegistered = false, 
        int userID = 0);
    public delegate List<System.Web.Mvc.SelectListItem> GetDepartmentSelectList(
        string itemType = "", 
        string selectedValue = "", 
        bool hasEmpty = false, 
        bool hasAll = false, 
        bool onlyRegistered = false, 
        int userID = 0);
    interface IGetCodeFileSelectList
    {
        event GetCodeFileSelectList CodeFileSelectListEvent;
    }
    interface IGetDepartmentSelectList
    {
        event GetDepartmentSelectList DepartmentSelectListEvent;
    }
    //public abstract class SelectList : IGetSelectList
    //{
    //    public event GetSelectList SelectListEvent;
    //    public SelectList(GetSelectList selectListEvent)
    //    {
    //        SelectListEvent = selectListEvent;
    //    }
    //}
}
