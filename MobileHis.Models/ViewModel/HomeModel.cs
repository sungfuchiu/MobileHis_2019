using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.ViewModel
{
    #region munu
    public struct MenuModel
    {
        public MenuData module { get; set; }
    }
    public struct MenuData
    {
        public string moduleKey { get; set; }
        public string moduleName { get; set; }
        public List<MenuParent> parent { get; set; }
    }
    public struct MenuParent
    {
        public string parent_id { get; set; }
        public string parent_name { get; set; }
        public string parent_area { get; set; }
        public string iconClass { get; set; }
        public string ResourceKey { get; set; }
        public List<MenuItem> items { get; set; }
    }
    public struct MenuItem
    {
        public string Area { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string Action { get; set; }
        public string ResourceKey { get; set; }
        public string isAdd { get; set; }
        public string isUpdate { get; set; }
        public string isDelete { get; set; }
        public string isPrint { get; set; }
    }
    #endregion
    #region xml
    public struct MenuXML
    {
        public string moduleKey { get; set; }
        public string moduleName { get; set; }
        public List<XMLItem> items { get; set; }
    }
    public struct XMLItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string Area { get; set; }
        public string ResourceKey { get; set; }
        public string iconClass { get; set; }
        public List<XMLSubItem> item { get; set; }
    }
    public struct XMLSubItem
    {
        public string Area { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string Control { get; set; }
        public string Action { get; set; }
        public string ResourceKey { get; set; }
        public string isRead { get; set; }
        public string isAdd { get; set; }
        public string isUpdate { get; set; }
        public string isDelete { get; set; }
        public string isPrint { get; set; }
    }
    #endregion
}
