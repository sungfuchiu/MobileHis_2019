using Common;
using MobileHis.Data;
using MobileHis.Models.ViewModel;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
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
    public interface IAccountService : IService<Account>
    {
        Account LogOn(string mail, string password);
        JObject AuthRole(List<string> r_key, string url);
        List<Account> GetList(string keyword);
        void Create(AccountCreateView data);
        AccountEditView Edit(int id);
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
            //using (var transaction = BeginTransaction())
            //{
                try
                {
                    data.Email = data.Email + Config.AppSetting("EmailDomain");
                    if (db.Repository<Account>().ReadAll()
                        .Any(x => x.Email.Equals(data.Email, StringComparison.InvariantCultureIgnoreCase)
                            || x.UserNo.Equals(data.UserNo, StringComparison.InvariantCultureIgnoreCase)))
                        //ValidationDictionary.AddGeneralError("Email Duplicated");
                        ValidationDictionary.AddPropertyError<AccountCreateView>(a => a.Email, "Email Duplicated.");
                    else
                    {
                        //var account = data.MapFrom<AccountCreateView, Account>();
                        data.MapTo(out Account account);
                        account.Password = Config.Md5Salt(data.Password);
                        //account.Account2Dept = new List<Account2Dept>();
                        Array.ForEach(
                            data.DepartmentIDs.OrEmptyIfNull().Concat(data.BureauDepartmentIDs.OrEmptyIfNull()).ToArray()
                            , a => account.Account2Dept.Add(new Account2Dept(a)));
                        Array.ForEach(data.RoleIDs.OrEmptyIfNull().ToArray()
                            , a => account.Account2Role.Add(new Account2Role(a)));
                        //db.Repository<Account2Role>().Create(
                        //    data.RoleIDs.OrEmptyIfNull().Select(a =>
                        //        new Account2Role(account.ID, Convert.ToInt32(a))).ToList());
                        Create(account);
                        Save();
                        //Save();
                        //transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            //}
        }
        public AccountEditView Edit(int id)
        {
            var account = (from a in db.Repository<Account>().ReadAll()
                           where a.ID == id
                        select new
                        {
                            a.ID,
                            a.UserNo,
                            a.Name,
                            a.Email,
                            a.Tel,
                            a.Card,
                            a.IsLockedOut,
                            a.IsDoctor,
                            a.Title,
                            a.Comment,
                            a.Experience,
                            a.Status,
                            a.Major,
                            a.Birthday,
                            //a.LastLoginDate,
                            a.Gender,
                            //CreateDate = a.CreateDate.Value,
                            //a.ModDate,
                            //a.ModUser,
                            Roles = a.Account2Role.Select(x => x.Role_id),
                            a.ImagePath,
                            Acc2Dept = from dd in a.Account2Dept
                                        where dd.Dept.IsRegistered == "Y"
                                        select dd.DeptId,
                            RegAcc2Dept = from dep in a.Account2Dept
                                           where string.IsNullOrEmpty(dep.Dept.IsRegistered)
                                           select dep.DeptId,
                            a.Expertise
                        }).AsEnumerable().Select(a =>
                          new AccountEditView()
                         {
                             ID = a.ID,
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
                             //LastLoginDate = a.LastLoginDate,
                             Gender = a.Gender,
                             //CreateDate = a.CreateDate,
                             //ModDate = a.ModDate,
                             //ModUser = a.ModUser,
                             RoleIDs = a.Roles.ToArray(),
                             ImagePath = a.ImagePath,
                             DepartmentIDs = a.Acc2Dept.ToArray(),
                              BureauDepartmentIDs = a.RegAcc2Dept.ToArray(),
                             Expertise = a.Expertise
                         }).Single();
            return account;
        }
        public void Edit(AccountEditView data)
        {
            //using (var transaction = BeginTransaction())
            //{
                try
                {
                    //int _id = Convert.ToInt32(data.ID);
                    //var acc = (from d in GetAll()
                    //           where d.ID == _id
                    //           select d).FirstOrDefault();
                    var account = Read(a => a.ID == data.ID);

                    if (!account.HasValue())
                    {
                        ValidationDictionary.AddPropertyError<Account>(a => a.ID, "ID not found.");
                        return;
                    }
                    if (ReadAll()
                        .Any(x => (x.Email.Equals(data.Email, StringComparison.InvariantCultureIgnoreCase)
                            || x.UserNo.Equals(data.UserNo, StringComparison.InvariantCultureIgnoreCase)
                            ) && x.ID != data.ID))
                        ValidationDictionary.AddPropertyError<AccountEditView>(a => a.Email, "Email Duplicated.");//.AddGeneralError("Email Duplicated");
                    else
                    {
                        data.MapTo(account);
                        //var depts = db.Repository<Account2Dept>().ReadAll().Where(a => a.AccountId == data.ID);
                        db.Repository<Account2Dept>().Delete(a => a.AccountId == data.ID);
                        Array.ForEach(
                            data.DepartmentIDs.OrEmptyIfNull().Concat(data.BureauDepartmentIDs.OrEmptyIfNull()).ToArray()
                            , a => account.Account2Dept.Add( new Account2Dept(a)));
                        db.Repository<Account2Role>().Delete(a => a.Account_id == data.ID);
                        Array.ForEach(data.RoleIDs.OrEmptyIfNull().ToArray()
                            , a => account.Account2Role.Add(new Account2Role(a)));
                        //Array.ForEach(
                        //    data.DepartmentIDs.OrEmptyIfNull().Concat(data.BureauDepartmentIDs.OrEmptyIfNull()).ToArray()
                        //    , a => account.Account2Dept.Add(
                        //         new Account2Dept() { DeptId = Convert.ToInt32(a) }));
                        //var roles = db.Repository<Account2Role>().ReadAll().Where(a => a.Account_id == data.ID);
                        //db.Repository<Account2Dept>().Delete(depts);
                        //Save();
                        //db.Repository<Account2Role>().Create(
                        //    data.RoleIDs.OrEmptyIfNull().Select(a =>
                        //        new Account2Role(account.ID, Convert.ToInt32(a))).ToList());
                        Save();
                        //Commit();
                        //transaction.Commit();
                    }

                    //if (acc != null)
                    //{
                    //    //判斷Email是否重複
                    //    data.Email = data.Email + Config.AppSetting("EmailDomain");
                    //    if (GetAllWithNoTracking().Any(x => x.Email.Equals(data.Email, StringComparison.InvariantCultureIgnoreCase) && x.ID != _id))
                    //        return Enums.DbStatus.Duplicate;
                    //    if (GetAllWithNoTracking().Any(x => x.UserNo.Equals(data.UserNo, StringComparison.InvariantCultureIgnoreCase) && x.ID != _id))
                    //        return Enums.DbStatus.Duplicate;
                    //    else
                    //    {
                    //        acc.UserNo = data.UserNo;
                    //        acc.Name = data.Name;
                    //        acc.Email = data.Email;
                    //        //acc.Dept_id = data.Dept_id;
                    //        acc.Title = data.Title;
                    //        acc.Gender = data.Gender;
                    //        acc.Birthday = data.Birthday;
                    //        acc.Comment = data.Comment;
                    //        acc.Experience = data.Experience;
                    //        acc.Major = data.Major;
                    //        acc.Expertise = data.Expertise;
                    //        // acc.CreateDate = data.CreateDate;
                    //        //    acc.LastLoginDate = data.LastLoginDate;
                    //        acc.ModDate = System.DateTime.Now;
                    //        acc.Tel = data.Tel;
                    //        acc.Card = data.Card;
                    //        acc.IsLockedOut = data.IsLockedOut == null ? "" : "Y";
                    //        acc.IsDoctor = data.IsDoctor == null ? "" : "Y";

                    //        acc.Status = data.Status;
                    //        acc.ModUser = User.Name;

                    //        //移除部門後,新增部門
                    //        var depts = db.Account2Dept.Where(x => x.AccountId.Equals(_id));
                    //        foreach (var r in depts)
                    //        {
                    //            db.Account2Dept.Remove(r);
                    //        }

                    //        if (data.Acc2Dept != null || data.RegAcc2Dept != null)
                    //        {
                    //            var arrSize = (data.Acc2Dept == null ? 0 : data.Acc2Dept.Length) + (data.RegAcc2Dept == null ? 0 : data.RegAcc2Dept.Length);
                    //            var dept = new int[arrSize];
                    //            if (data.Acc2Dept != null)
                    //                data.Acc2Dept.CopyTo(dept, 0);
                    //            if (data.RegAcc2Dept != null)
                    //                data.RegAcc2Dept.CopyTo(dept, data.Acc2Dept == null ? 0 : data.Acc2Dept.Length);
                    //            foreach (var r in dept)
                    //            {
                    //                var newAccount2DeptObj = new Account2Dept()
                    //                {
                    //                    AccountId = _id,
                    //                    DeptId = r
                    //                };
                    //                db.Account2Dept.Add(newAccount2DeptObj);
                    //            }
                    //        }

                    //        //移除角色
                    //        using (Account2RoleDal dal = new Account2RoleDal())
                    //        {
                    //            dal.Delete(dal.GetAllByAccountID(_id, true).AsQueryable());
                    //            dal.Save();
                    //        }
                    //        //var _Account2RoleObj = Account2Role.Where(x => x.Account_id == _id).Select(x => x);
                    //        //foreach (var item in _Account2RoleObj)
                    //        //    Account2Role.Remove(item);
                    //        //新增角色
                    //        if (data.Roles != null)
                    //        {
                    //            using (Account2RoleDal dal = new Account2RoleDal())
                    //            {
                    //                foreach (var item in data.Roles)
                    //                {
                    //                    var newAccount2RoleObj = new Account2Role()
                    //                    {
                    //                        Account_id = _id,
                    //                        Role_id = Convert.ToInt32(item)
                    //                    };

                    //                    dal.Add(newAccount2RoleObj);
                    //                }
                    //                //  Account2Role.Add(newAccount2RoleObj);
                    //                dal.Save();
                    //            }
                    //        }

                    //        Save();
                    //        trans.Commit();
                    //        return Enums.DbStatus.OK;
                    //    }
                    //}
                    //else
                    //    return Enums.DbStatus.Error;

                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    //RollBack();
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            //}
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
