using Common;
using MobileHis.Data;
using MobileHis.Models.ViewModel;
using MobileHis_2019.Repository.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MobileHis_2019.Service.Service
{
    public interface IAccountService
    {
        Account LogOn(string mail, string password);
        JObject AuthRole(List<string> r_key, string url);
        List<Account> GetList(string keyword);
        void Create(AccountCreateView data);
    }
    public class AccountService : GenericService<Account>, IAccountService
    {
        public AccountService( IUnitOfWork indb ) : base(indb)
        {
        }
        public List<Account> GetList(string keyword = "")
        {
            var data = db.Repository<Account>().ReadAll()
                        .Where(a => a.Name!=null)
                        .OrderByDescending(x => x.Name)
                        .ThenByDescending(a => a.CreateDate)
                        .Select(x => x);
            if (!string.IsNullOrEmpty(keyword))
                data = data.Where(x => x.Name.Contains(keyword)
                        || x.Email.Contains(keyword)
                        || x.Tel.Contains(keyword)
                    );
            return data.ToList();
        }
        public Account LogOn(string mail, string password)
        {
            string hashMd5 = Config.Md5Salt(password);
            var acc = db.Repository<Account>().Read(x => 
                x.Email.Equals(mail) &&
                 x.Password == hashMd5 && 
                 x.IsLockedOut != "Y"
                );
            if (acc != null)
            {
                //更新最後登錄時間
                acc.LastLoginDate = System.DateTime.Now;
                Save();
            }
            return acc;
        }
        public void Create(AccountCreateView data)
        {
            try{ 
                data.Email = data.Email + Config.AppSetting("EmailDomain");
                if (db.Repository<Account>().ReadAll()
                    .Any(x => x.Email.Equals(data.Email, StringComparison.InvariantCultureIgnoreCase)
                        || x.UserNo.Equals(data.UserNo, StringComparison.InvariantCultureIgnoreCase)))
                    ValidationDictionary.AddGeneralError("Email Duplicated");
                else
                {
                    var account = data.MapFrom<AccountCreateView, Account>();
                    account.Password = Config.Md5Salt(data.Password);
                    Array.ForEach(
                        data.DepartmentIDs.Concat(data.BureauDepartmentIDs).ToArray()
                        ,a => account.Account2Dept.Add(
                            new Account2Dept() { DeptId = Convert.ToInt32(a) }));
                    Create(account);
                    db.Repository<Account2Role>().Create(
                        data.Roles.Select(a => 
                            new Account2Role(account.ID, Convert.ToInt32(a))).ToList());
                    Save();
                }
            }catch(Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        public AccountEditView Edit(int id)
        {
            //return db.Repository<Account>().ReadAll()
            //       .Where(a => a.ID == id)
            //       .Include(a => a.Account2Dept)
            //       .SelectMany(a => a.Account2Dept, (a, b) => new AccountEditView()
            //       {
            //           ID = a.ID.ToString(),
            //           UserNo = a.UserNo,
            //           Name = a.Name,
            //           Email = a.Email.Replace(Config.AppSetting("EmailDomain"), ""),
            //           Tel = a.Tel,
            //           Card = a.Card,
            //           IsLockedOut = a.IsLockedOut,
            //           IsDoctor = a.IsDoctor,
            //           Title = a.Title,
            //           Comment = a.Comment,
            //           Experience = a.Experience,
            //           Status = a.Status,
            //           Major = a.Major,
            //           Birthday = a.Birthday,
            //           LastLoginDate = a.LastLoginDate,
            //           Gender = a.Gender,
            //           CreateDate = a.CreateDate.Value,
            //           ModDate = a.ModDate,
            //           ModUser = a.ModUser,
            //           Roles = a.Account2Role.Select(x => Convert.ToString(x.Role_id)).ToArray(),
            //           ImagePath = a.ImagePath,
            //           Acc2Dept = a.Account2Dept.Where(x => string.IsNullOrEmpty(x.Dept.IsRegistered)).Select(x => x.DeptId).ToArray(),
            //           RegAcc2Dept = a.Account2Dept.Where(x => x.Dept.IsRegistered == "Y").Select(x => x.DeptId).ToArray(),
            //           Expertise = a.Expertise
            //       }).Where(a => a.Acc2Dept .FirstOrDefault();

            //db.Repository<Account>().ReadAll()
            //       .Where(a => a.ID == id)
            //       .SelectMany(a => a.Account2Dept, (a, b)
            //       => new
            //       {
            //           account = a,
            //           isRegistered = b.Dept.IsRegistered
            //       }).Where(a => a.is.FirstOrDefault();
            var result =    from a in db.Repository<Account>().ReadAll() 
                        from dept in (from dep in a.Account2Dept
                                    where string.IsNullOrEmpty(dep.Dept.IsRegistered)
                                    select dep.DeptId).ToArray()
                            
                    from deptIsRegistered in (from dd in a.Account2Dept
                                              where dd.Dept.IsRegistered == "Y"
                                              select dd.DeptId).ToArray()
                    select new AccountEditView()
                    {
                        ID = a.ID.ToString(),
                        UserNo = a.UserNo,
                        Name = a.Name,
                        Email = a.Email.Replace(Config.AppSetting("EmailDomain"), ""),
                        Tel = a.Tel,
                        Card = a.Card,
                        IsLockedOut = a.IsLockedOut,
                        IsDoctor = a.IsDoctor,
                        Title = a.Title,
                        Comment = a.Comment,
                        Experience = a.Experience,
                        Status = a.Status,
                        Major = a.Major,
                        Birthday = a.Birthday,
                        LastLoginDate = a.LastLoginDate,
                        Gender = a.Gender,
                        CreateDate = a.CreateDate.Value,
                        ModDate = a.ModDate,
                        ModUser = a.ModUser,
                        Roles = a.Account2Role.Select(x => Convert.ToString(x.Role_id)).ToArray(),
                        ImagePath = a.ImagePath,
                        Acc2Dept = dept,
                        RegAcc2Dept = deptIsRegistered.Select(x => x.DeptId).ToArray(),
                        Expertise = a.Expertise
                    }
                            //   (from a in db.Repository<Account>().ReadAll()
                            //  select a.Account2Dept join t1 in db.Repository<Dept>().ReadAll() on account.Account2Dept equals t1.Account
                            //where t1.

                            //db.Repository<Account>().ReadAll()
                            //       .Where(a => a.ID == id)
                            //       .Select(a => new
                            //       {
                            //           account = a,
                            //           accTodept = a.Account2Dept,
                            //           accToRegisterDept = a.Account2Dept
                            //       }).Where(a => a.accToRegisterDept.SelectMany(a => a.accToRegisterDept, (a,b)
                            //       => new
                            //       {
                            //           deptdd = b.DeptId
                            //       })
                            //       .FirstOrDefault();
        }
        public JObject AuthRole(List<string> r_key, string url)
        {

            var _data = (from d in db.Repository<Role>().ReadAll()
                         join d1 in db.Repository<Ap2Role>().ReadAll()
                         on d.ID equals d1.role_id into ps
                         from o in ps.DefaultIfEmpty()
                         where r_key.Contains(d.name) && o.ID != null
                         select o).ToList();

            var xdoc = XDocument.Load(url);

            var linqTree = (from item in xdoc.Descendants("module")
                            select new MenuXML
                            {
                                moduleKey = item.Attribute("key").Value,
                                moduleName = item.Attribute("name").Value,
                                items = (from c in item.Descendants("items")
                                         select new XMLItem
                                         {
                                             id = c.Attribute("id").Value,
                                             name = c.Attribute("name").Value,
                                             Area = c.Attribute("Area").Value,
                                             ResourceKey = c.Attribute("ResourceKey").Value,
                                             iconClass = c.Attribute("iconClass").Value,
                                             item = (from c1 in c.Descendants("item")
                                                     select new XMLSubItem
                                                     {
                                                         Area = c.Attribute("Area").Value,
                                                         key = c1.Attribute("key").Value,
                                                         name = c1.Attribute("name").Value,
                                                         Control = c1.Attribute("Control").Value,
                                                         Action = c1.Attribute("Action").Value,
                                                         ResourceKey = c1.Attribute("ResourceKey").Value,
                                                         isRead = _data.Where(x =>
                                                                x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase)
                                                                && x.isRead == "Y"
                                                                ).Any() ? "Y" : "",
                                                         isAdd = _data.Where(x =>
                                                                x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase)
                                                                && x.isAdd == "Y"
                                                                ).Any() ? "Y" : "",
                                                         isUpdate = _data.Where(x =>
                                                                x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase)
                                                                && x.isUpdate == "Y"
                                                                ).Any() ? "Y" : "",
                                                         isDelete = _data.Where(x =>
                                                                x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase)
                                                                && x.isDelete == "Y"
                                                                ).Any() ? "Y" : "",
                                                         isPrint = _data.Where(x =>
                                                                x.ap_key.Equals(c1.Attribute("key").Value, StringComparison.InvariantCultureIgnoreCase)
                                                                && x.isPrint == "Y"
                                                                ).Any() ? "Y" : ""

                                                     }).ToList()
                                         }).ToList()
                            });
            //var obj = (from p in linqTree
            //           select new MenuModel
            //           {
            //               module = new MenuData
            //               {
            //                   moduleKey = p.moduleKey,
            //                   moduleName = p.moduleName,
            //                   parent = (from p1 in p.items.Where(x => x.item.Where(y => y.isRead == "Y").Count() >= 1)
            //                             select new MenuParent
            //                             {
            //                                 parent_id = p1.id,
            //                                 parent_name = p1.name,
            //                                 parent_area = p1.Area,
            //                                 iconClass = p1.iconClass,
            //                                 ResourceKey = p1.ResourceKey,
            //                                 items = (from p2 in p1.item.Where(x => x.isRead == "Y")
            //                                          select new MenuItem
            //                                          {
            //                                              Area = p2.Area,
            //                                              key = p2.key,
            //                                              Action = p2.Action,
            //                                              isAdd = p2.isAdd,
            //                                              isDelete = p2.isDelete,
            //                                              isPrint = p2.isPrint,
            //                                              isUpdate = p2.isUpdate,
            //                                              name = p2.name,
            //                                              ResourceKey = p2.ResourceKey
            //                                          }).ToList()
            //                             }).ToList()
            //               }
            //           }).ToList();
            JObject obj =
            new JObject(
                    new JProperty("module", new JArray(
                        from p in linqTree
                        select new JObject(
                              new JProperty("moduleKey", p.moduleKey),
                              new JProperty("moduleName", p.moduleName),
                                     new JProperty("parent",
                                          new JArray(
                                               from p1 in p.items.Where(x => x.item.Where(y => y.isRead == "Y").Count() >= 1)
                                               select new JObject(
                                                      new JProperty("parent_id", p1.id),
                                                      new JProperty("parent_name", p1.name),
                                                      new JProperty("parent_area", p1.Area),
                                                       new JProperty("iconClass", p1.iconClass),
                                                       new JProperty("ResourceKey", p1.ResourceKey),
                                                        new JProperty("items",
                                                            new JArray(
                                                            from p2 in p1.item.Where(x => x.isRead == "Y")
                                                            select new JObject(
                                                                 new JProperty("Area", p2.key == "E030" ? "Drug" : p2.Area),
                                                                 new JProperty("key", p2.key),
                                                                 new JProperty("name", p2.name),
                                                                 new JProperty("Control", p2.Control),
                                                                 new JProperty("Action", p2.Action),
                                                                 new JProperty("ResourceKey", p2.ResourceKey),
                                                                 new JProperty("isAdd", p2.isAdd),
                                                                 new JProperty("isUpdate", p2.isUpdate),
                                                                 new JProperty("isDelete", p2.isDelete),
                                                                 new JProperty("isPrint", p2.isPrint)
                                                             )
                                                        )
                                               )
                            )
                            )
                            ))
                            )));



            return obj;

        }
    }
}
