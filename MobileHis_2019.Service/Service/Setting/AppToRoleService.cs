using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using LocalRes;
using MobileHis.Data;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;

namespace MobileHis_2019.Service.Service
{
    public interface IAppToRoleService : IService<Ap2Role>
    {
        string GenerateTable(int id);
        void SetTable(int id, string key, bool isSet);
    }
    public class AppToRoleService : GenericService<Ap2Role>, IAppToRoleService
    {
        public AppToRoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        /// <summary>
        /// 權限Grid表
        /// </summary>
        /// <returns></returns>
        public string GenerateTable(int id)
        {
            var authList = ReadAll().Where(a => a.role_id == id);//db.Ap2Role.Where(x => x.role_id == id).ToList();
            StringBuilder sb = new StringBuilder();
            var document = XDocument.Load(HttpContext.Current.Server.MapPath("~/menu_all.xml"));
            var linqTree = (from item in document.Descendants("module")
                            select new
                            {
                                moduleKey = item.Attribute("key").Value,
                                moduleName = item.Attribute("name").Value,
                                items = from c in item.Descendants("items")
                                        select new
                                        {
                                            id = c.Attribute("id").Value,
                                            name = c.Attribute("name").Value,
                                            ResourceKey = c.Attribute("ResourceKey").Value,
                                            item = from c1 in c.Descendants("item")
                                                   select new
                                                   {
                                                       Area = c.Attribute("Area").Value,
                                                       key = c1.Attribute("key").Value,
                                                       name = c1.Attribute("name").Value,
                                                       Control = c1.Attribute("Control").Value,
                                                       Action = c1.Attribute("Action").Value,
                                                       ResourceKey = c1.Attribute("ResourceKey").Value,
                                                       id = authList.Where(x => x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase))
                                                       .Select(x => x.ID).FirstOrDefault(),
                                                       isRead = authList.Where(x => x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase))
                                                             .Select(x => x.isRead).FirstOrDefault(),
                                                       isAdd = authList.Where(x => x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase))
                                                             .Select(x => x.isAdd).FirstOrDefault(),
                                                       isUpdate = authList.Where(x => x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase))
                                                             .Select(x => x.isUpdate).FirstOrDefault(),
                                                       isDelete = authList.Where(x => x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase))
                                                             .Select(x => x.isDelete).FirstOrDefault(),
                                                       isPrint = authList.Where(x => x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase))
                                                             .Select(x => x.isPrint).FirstOrDefault()
                                                   }
                                        }
                            });

            foreach (var item in linqTree)
            {
                sb.Append("<tr><td colspan=\"6\" style=\"background-color: #9fccff\">" + item.moduleName + "</td></tr>");
                foreach (var items in item.items)
                {
                    sb.Append("<tr><td colspan=\"6\" style=\"background-color:#E1F5C4;\">" + Resource.ResourceManager.GetString(items.ResourceKey) + "</td></tr>");
                    foreach (var detail in items.item)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>" + Resource.ResourceManager.GetString(detail.ResourceKey) + "</td>");
                        sb.Append("<td align=\"center\"><label class=\"position-relative\"><input type=\"checkbox\" class=\"ace\" id=\"" + detail.key + "_READ\" onchange=\"doUpdate(this.id);\" " + (detail.isRead == "Y" ? "checked" : "") + "><span class=\"lbl\"></span></label></td>");
                        sb.Append("<td align=\"center\"><label class=\"position-relative\"><input type=\"checkbox\" class=\"ace\" id=\"" + detail.key + "_ADD\" onchange=\"doUpdate(this.id);\"  " + (detail.isAdd == "Y" ? "checked" : "") + "><span class=\"lbl\"></span></label></td>");
                        sb.Append("<td align=\"center\"><label class=\"position-relative\"><input type=\"checkbox\" class=\"ace\" id=\"" + detail.key + "_Update\" onchange=\"doUpdate(this.id);\"  " + (detail.isUpdate == "Y" ? "checked" : "") + "><span class=\"lbl\"></span></label></td>");
                        sb.Append("<td align=\"center\"><label class=\"position-relative\"><input type=\"checkbox\" class=\"ace\" id=\"" + detail.key + "_Delete\" onchange=\"doUpdate(this.id);\"  " + (detail.isDelete == "Y" ? "checked" : "") + "><span class=\"lbl\"></span></label></td>");
                        sb.Append("<td align=\"center\"><label class=\"position-relative\"><input type=\"checkbox\" class=\"ace\" id=\"" + detail.key + "_Print\" onchange=\"doUpdate(this.id);\"  " + (detail.isPrint == "Y" ? "checked" : "") + "><span class=\"lbl\"></span></label></td>");
                        sb.Append("</tr>");
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 設定角色權限
        /// </summary>
        /// <returns></returns>
        public void SetTable(int id, string key, bool isSet)
        {
            string appKeys = key.Split('_')[0];
            string auth = key.Split('_')[1].ToLower();

            var role = Read(x => x.role_id == id
                && x.ap_key.Equals(appKeys, StringComparison.InvariantCultureIgnoreCase));
            if (role != null)
            {
                switch (auth)
                {
                    case "read": role.isRead = isSet ? "Y" : null; break;
                    case "add": role.isAdd = isSet ? "Y" : null; break;
                    case "delete": role.isDelete = isSet ? "Y" : null; break;
                    case "update": role.isUpdate = isSet ? "Y" : null; break;
                    case "print": role.isPrint = isSet ? "Y" : null; break;
                }
            }
            else
            {
                Ap2Role newRole = new Ap2Role()
                {
                    ap_key = appKeys,
                    role_id = id
                };
                switch (auth)
                {
                    case "read": newRole.isRead = isSet ? "Y" : null; break;
                    case "add": newRole.isAdd = isSet ? "Y" : null; break;
                    case "delete": newRole.isDelete = isSet ? "Y" : null; break;
                    case "update": newRole.isUpdate = isSet ? "Y" : null; break;
                    case "print": newRole.isPrint = isSet ? "Y" : null; break;
                }
                Create(newRole);
            }
            Save();
        }
    }
}
