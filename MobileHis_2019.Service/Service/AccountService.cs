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
using System.Security.Principal;
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
        void Create(AccountCreateView model);
        AccountEditView Edit(int ID);
        void Edit(AccountEditView model);
        void ChangePassword(ChangePasswordView model);
    }
    public class AccountService : GenericService<Account>, IAccountService
    {
        private readonly WrappedPrincipal _principal;
        public AccountService(IUnitOfWork unitOfWork, WrappedPrincipal principal ) : base(unitOfWork)
        {
            _principal = principal;
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
            var account = Read(x => 
                x.Email.Equals(mail) &&
                 x.Password == hashMd5 && 
                 x.IsLockedOut != "Y"
                );
            if (account != null)
            {
                account.LastLoginDate = System.DateTime.Now;
                Save();
            }
            return account;
        }
        public void Create(AccountCreateView model)
        {
                try
                {
                    model.Email = model.Email + Config.AppSetting("EmailDomain");
                    if (db.Repository<Account>().ReadAll()
                        .Any(x => x.Email.Equals(model.Email, StringComparison.InvariantCultureIgnoreCase)
                            || x.UserNo.Equals(model.UserNo, StringComparison.InvariantCultureIgnoreCase)))
                        ValidationDictionary.AddPropertyError<AccountCreateView>(a => a.Email, "Email Duplicated.");
                    else
                    {
                        model.MapTo(out Account account);
                        account.Password = Config.Md5Salt(model.Password);
                        Array.ForEach(
                            model.DepartmentIDs.OrEmptyIfNull().Concat(model.BureauDepartmentIDs.OrEmptyIfNull()).ToArray()
                            , a => account.Account2Dept.Add(new Account2Dept(a)));
                        Array.ForEach(model.RoleIDs.OrEmptyIfNull().ToArray()
                            , a => account.Account2Role.Add(new Account2Role(a)));
                        Create(account);
                        Save();
                    }
                }
                catch (Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
        }
        public AccountEditView Edit(int ID)
        {
            var account = (from a in db.Repository<Account>().ReadAll()
                           where a.ID == ID
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
                            a.Gender,
                            Roles = a.Account2Role.Select(x => x.Role_id),
                            a.ImagePath,
                            Acc2Dept = from dep in a.Account2Dept
                                           where string.IsNullOrEmpty(dep.Dept.IsRegistered)
                                           select dep.DeptId,
                            RegAcc2Dept = from dd in a.Account2Dept
                                          where dd.Dept.IsRegistered == "Y"
                                          select dd.DeptId,
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
                             Gender = a.Gender,
                             RoleIDs = a.Roles.ToArray(),
                             ImagePath = a.ImagePath,
                             DepartmentIDs = a.Acc2Dept.ToArray(),
                              BureauDepartmentIDs = a.RegAcc2Dept.ToArray(),
                             Expertise = a.Expertise
                         }).Single();
            return account;
        }
        public void Edit(AccountEditView model)
        {
                try
                {
                    var account = Read(a => a.ID == model.ID);
                    if (!account.HasValue())
                    {
                        ValidationDictionary.AddPropertyError<Account>(a => a.ID, "ID not found.");
                        return;
                    }
                    if (ReadAll()
                        .Any(x => (x.Email.Equals(model.Email, StringComparison.InvariantCultureIgnoreCase)
                            || x.UserNo.Equals(model.UserNo, StringComparison.InvariantCultureIgnoreCase)
                            ) && x.ID != model.ID))
                        ValidationDictionary.AddPropertyError<AccountEditView>(a => a.Email, "Email Duplicated.");//.AddGeneralError("Email Duplicated");
                    else
                    {
                        model.MapTo(account);
                        db.Repository<Account2Dept>().Delete(a => a.AccountId == model.ID);
                        Array.ForEach(
                            model.DepartmentIDs.OrEmptyIfNull().Concat(model.BureauDepartmentIDs.OrEmptyIfNull()).ToArray()
                            , a => account.Account2Dept.Add( new Account2Dept(a)));
                        db.Repository<Account2Role>().Delete(a => a.Account_id == model.ID);
                        Array.ForEach(model.RoleIDs.OrEmptyIfNull().ToArray()
                            , a => account.Account2Role.Add(new Account2Role(a)));
                        Save();
                    }
                }
                catch (Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
        }
        public void Delete(int ID)
        {
            try
            {
                var account = Read(a => a.ID == ID);
                if (account != null)
                {
                    Delete(account);
                    Save();
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        public void ChangePassword(ChangePasswordView model)
        {
            try
            {
                string md5SaltPassword = Config.Md5Salt(model.Password);
                var account = Read(x => 
                    x.Email.Equals(_principal.Email, StringComparison.InvariantCultureIgnoreCase)
                    && x.Password == md5SaltPassword);

                //判斷是否存在
                if (account == null)
                    ValidationDictionary.AddGeneralError("Account ID or password error");
                else
                {
                    account.Password = Config.Md5Salt(model.newPassword);
                    account.ModDate = System.DateTime.Now;
                    Save();
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        public void ResetPassword(int id)
        {
            try
            {
                var account = Read(a => a.ID == id);
                if (account == null)
                    ValidationDictionary.AddGeneralError("Account ID error");
                else
                {
                    account.Password = Config.Md5Salt("12345");
                    Save();
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        public JObject AuthRole(List<string> r_key, string url)
        {

            var _data = (from d in db.Repository<Role>().ReadAll()
                         join d1 in db.Repository<Ap2Role>().ReadAll()
                         on d.ID equals d1.role_id into ps
                         from o in ps.DefaultIfEmpty()
                         where r_key.Contains(d.name)
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
