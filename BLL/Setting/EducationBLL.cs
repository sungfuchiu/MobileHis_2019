using AutoMapper;
using BLL.Interface;
using Common;
using DAL;
using MobileHis.Data;
using MobileHis.Misc;
using MobileHis.Models.Areas.Sys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;
using X.PagedList;

namespace BLL
{
    public class EducationBLL : IDBLLBase<HealthEdu>, IAPIBLL<EducationModel>
    {

        private EducationDAL _educationDAL;
        private CodeFileBLL _codeFileBLL;
        private RoomDAL _roomDAL;
        private EducationFileDAL _educationFileDAL;
        private IMapper _mapper;
        public EducationBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _educationDAL = new EducationDAL();
            _codeFileBLL = new CodeFileBLL(validationDictionary);
            _roomDAL = new RoomDAL();
            _educationFileDAL = new EducationFileDAL();
            IDAL = _educationDAL;
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.CreateMap<EducationModel, HealthEdu>());
            _mapper = mapperConfiguration.CreateMapper();
        }


        public List<SelectListItem> GetEducationList(int TypeID)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach(var item in _educationDAL.GetEducationList(TypeID))
            {
                items.Add(new SelectListItem()
                {
                    Text = item.HealthEdu_Name + "(" + LocalRes.Resource.Guardian_IsUsed + ":" + (item.IsUsed ? "Y" : "N") + ")",
                    Value = item.ID.ToString()
                });
            }
            if (items.Count() != 0)
            {
                items.Insert(0, new SelectListItem() { Text = LocalRes.Resource.Comm_Select, Value = "" });
            }
            return items;
        }

        public void Index(EducationModel model)
        {
            model.EducationPageList = _educationDAL.GetList(model.Keyword).ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;
        }
        public void Create(EducationModel model)
        {
            try
            {
                var education = _mapper.Map<HealthEdu>(model);
                Add(education);
                Save();
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }

        public void Update(EducationModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int ID)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    _roomDAL.Reads();
                    var relatedRooms = _roomDAL.Entity.Where(a => a.Guardian_ID == ID);
                    foreach (var room in relatedRooms)
                    {
                        room.Guardian_ID = null;
                    }
                    _educationFileDAL.Reads();
                    var relatedFiles = _educationFileDAL.Entity.Where(a => a.HealthEdu_ID == ID);
                    foreach (var file in relatedFiles)
                    {
                        var s = Storage.GetStorage(StorageScope.GuardianUpload);
                        s.Delete(file.FileName, file.HealthEdu_ID);
                        _educationFileDAL.Delete(file);
                    }
                    base.Delete(ID);
                    scope.Complete();
                }
                catch(Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            }
            
        }
        public EducationModel Edit(int ID)
        {
            var data = _educationDAL.Read(a => a.ID == ID);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HealthEdu, EducationModel>()
                .ForMember(a => a.CategoryName, opt => opt.MapFrom(o => o.CodeFile.ItemDescription)));
            var mapper = config.CreateMapper();
            var education = mapper.Map<EducationModel>(data);
            education.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;

            var GF_List = new List<HealthEdu_File>();

            _educationFileDAL.Reads();
            education.EducationFiles = _educationFileDAL.Entity
                            .Where(a => a.HealthEdu_ID == ID)
                            .OrderByDescending(a => a.IsUsed)
                            .ThenBy(a => a.Show_Order)
                            .ThenBy(a => a.FileName).ToList();
            return education;
        }
        public void Edit(EducationModel model)
        {
            using (var trans = new TransactionScope())
            {
                try
                {
                    model.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;
                    var education = _educationDAL.Read(model.ID);

                    if (education != null)
                    {
                        var s_attach = Storage.GetStorage(StorageScope.GuardianUpload);

                        _educationFileDAL.Reads();
                        var educationFiles = _educationFileDAL.Entity.Where(a => a.HealthEdu_ID == model.ID);

                        int showOrder = (educationFiles.Count() > 0) 
                            ? educationFiles.Max(a => a.Show_Order) + 1 
                            : 1;
                        int defaultShowSeconds = 5;

                        foreach (var file in model.UploadFiles.OrEmptyIfNull())
                        {
                            if (file != null && !file.FileName.IsNullOrEmpty())
                            {
                                var fileName = new System.IO.FileInfo(file.FileName).Name;
                                if (!s_attach.FileExist(fileName, model.ID)
                                    && s_attach.CheckExtensions(System.IO.Path.GetExtension(fileName)))
                                {
                                    fileName = s_attach.Write(fileName, file, model.ID);
                                    var att = new HealthEdu_File
                                    {
                                        HealthEdu_ID = model.ID,
                                        FileName = fileName,
                                        Show_Order = showOrder,
                                        Show_Seconds = defaultShowSeconds,
                                        IsUsed = true,
                                        UploadDate = System.DateTime.Now,
                                        ModDate = System.DateTime.Now,
                                        ModUser = model.ModUser
                                    };
                                    _educationFileDAL.Add(att);
                                    showOrder++;
                                }
                            }
                        }
                        _educationFileDAL.Save();

                        education.HealthEdu_Type_CodeFile = model.HealthEdu_Type_CodeFile;
                        education.HealthEdu_Name = model.HealthEdu_Name;
                        education.IsUsed = model.IsUsed;
                        education.IsForLobbyUsed = model.IsForLobbyUsed;
                        education.QueueMsg = model.QueueMsg;
                        education.ModDate = System.DateTime.Now;
                        education.ModUser = "Admin";

                        Save();
                        trans.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            }
        }
        public void DeleteIMG(int ID)
        {
            using (var trans = new TransactionScope())
            {
                try
                {
                    var file = _educationFileDAL.Read(ID);

                    var files = file.Guardian.HealthEdu_File
                        .Where(a => a.ID != file.ID)
                        .OrderByDescending(a => a.IsUsed)
                        .ThenBy(a => a.Show_Order).ToList();
                    _educationFileDAL.Delete(file);
                    for (int i = 0; i < files.Count; i++)
                    {
                        var g = files[i];
                        g.Show_Order = i + 1;
                    }
                    var s = Storage.GetStorage(StorageScope.GuardianUpload);
                    s.Delete(file.FileName, file.HealthEdu_ID);
                    Save();
                    trans.Complete();
                }
                catch (Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            }
        }
    }
}
