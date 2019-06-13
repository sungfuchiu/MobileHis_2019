using AutoMapper;
using Common;
using MobileHis.Data;
using MobileHis.Misc;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace MobileHis_2019.Service.Service
{
    public class EducationService : GenericModelService<HealthEdu, EducationModel>, IAPIService<EducationModel>
    {
        ICodeFileService _codeFileService;
        public EducationService(IValidationDictionary validationDictionary, IUnitOfWork inDB, ICodeFileService codeFileService) : base(inDB)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _codeFileService = codeFileService;
        }


        public List<SelectListItem> GetEducationList(int TypeID)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach(var item in db.Repository<HealthEdu>().ReadAll()
                .Where(a => a.HealthEdu_Type_CodeFile == TypeID)
                .OrderBy(a => a.HealthEdu_Type_CodeFile))
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
            var educations = db.Repository<HealthEdu>().ReadAll()
                .Where(a => a.CodeFile.CheckFlag != "D");
            if (!model.Keyword.IsNullOrEmpty())
            {
                educations = educations.Where(x =>
                        x.HealthEdu_Name.Contains(model.Keyword)
                        || x.CodeFile.ItemDescription.Contains(model.Keyword)
                    );
            }
            model.EducationPageList = educations.ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileService.GetDropDownList;
        }
        public void Create(EducationModel model)
        {
            try
            {
                var education = ToCreateEntity(model);
                Create(education);
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

        public void Delete(int ID)
        {
                try
                {
                    var rooms = db.Repository<Room>().ReadAll();
                    var relatedRooms = rooms.Where(a => a.Guardian_ID == ID);
                    foreach (var room in relatedRooms)
                    {
                        room.Guardian_ID = null;
                    }
                    var educationFiles = db.Repository<HealthEdu_File>().ReadAll();
                    var relatedFiles = educationFiles.Where(a => a.HealthEdu_ID == ID);
                    foreach (var file in relatedFiles)
                    {
                        var s = Storage.GetStorage(StorageScope.GuardianUpload);
                        s.Delete(file.FileName, file.HealthEdu_ID);
                        db.Repository<HealthEdu_File>().Delete(file);
                    }
                    var education = db.Repository<HealthEdu>().Read(a => a.ID == ID);
                    db.Repository<HealthEdu>().Delete(education);
                    db.Save();
                }
                catch(Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            
        }
        public EducationModel Edit(int ID)
        {
            var data = db.Repository<HealthEdu>().Read(a => a.ID == ID);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HealthEdu, EducationModel>()
                .ForMember(a => a.CategoryName, opt => opt.MapFrom(o => o.CodeFile.ItemDescription)));
            var mapper = config.CreateMapper();
            var education = mapper.Map<EducationModel>(data);
            education.CodeFileSelectListEvent += _codeFileService.GetDropDownList;

            var GF_List = new List<HealthEdu_File>();

            education.EducationFiles = db.Repository<HealthEdu_File>().ReadAll()
                            .Where(a => a.HealthEdu_ID == ID)
                            .OrderByDescending(a => a.IsUsed)
                            .ThenBy(a => a.Show_Order)
                            .ThenBy(a => a.FileName).ToList();
            return education;
        }
        public void Edit(EducationModel model)
        {
                try
                {
                    model.CodeFileSelectListEvent += _codeFileService.GetDropDownList;
                    var education = db.Repository<HealthEdu>().Read(a => a.ID == model.ID);

                    if (education != null)
                    {
                        var storageAttach = Storage.GetStorage(StorageScope.GuardianUpload);

                        var educationFiles = db.Repository<HealthEdu_File>().ReadAll().Where(a => a.HealthEdu_ID == model.ID);

                        int showOrder = (educationFiles.Count() > 0) 
                            ? educationFiles.Max(a => a.Show_Order) + 1 
                            : 1;
                        int defaultShowSeconds = 5;

                        foreach (var file in model.UploadFiles.OrEmptyIfNull())
                        {
                            if (file != null && !file.FileName.IsNullOrEmpty())
                            {
                                var fileName = new System.IO.FileInfo(file.FileName).Name;
                                if (!storageAttach.FileExist(fileName, model.ID)
                                    && storageAttach.CheckExtensions(System.IO.Path.GetExtension(fileName)))
                                {
                                    fileName = storageAttach.Write(fileName, file, model.ID);
                                    var newFile = new HealthEdu_File
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
                                    db.Repository<HealthEdu_File>().Create(newFile);
                                    showOrder++;
                                }
                            }
                        }
                        foreach(var file in model.EducationFiles.OrEmptyIfNull())
                        {
                            var updatedFile = db.Repository<HealthEdu_File>().Read(a => a.ID == file.ID && a.HealthEdu_ID == file.HealthEdu_ID);
                            updatedFile.Show_Seconds = file.Show_Seconds;
                            updatedFile.IsUsed = file.IsUsed;
                            updatedFile.Show_Order = file.Show_Order;
                            updatedFile.ModDate = DateTime.Now;
                            updatedFile.ModUser = model.ModUser;
                        }

                        education.HealthEdu_Type_CodeFile = model.HealthEdu_Type_CodeFile;
                        education.HealthEdu_Name = model.HealthEdu_Name;
                        education.IsUsed = model.IsUsed;
                        education.IsForLobbyUsed = model.IsForLobbyUsed;
                        education.QueueMsg = model.QueueMsg;
                        education.ModDate = System.DateTime.Now;
                        education.ModUser = "Admin";

                        Save();
                    }
                }
                catch (Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
        }
        public void DeleteIMG(int ID)
        {
                try
                {
                    var file = db.Repository<HealthEdu_File>().Read(a => a.ID == ID);

                    var files = file.Guardian.HealthEdu_File
                        .Where(a => a.ID != file.ID)
                        .OrderByDescending(a => a.IsUsed)
                        .ThenBy(a => a.Show_Order).ToList();
                    db.Repository<HealthEdu_File>().Delete(file);
                    for (int i = 0; i < files.Count; i++)
                    {
                        var g = files[i];
                        g.Show_Order = i + 1;
                    }
                    var s = Storage.GetStorage(StorageScope.GuardianUpload);
                    s.Delete(file.FileName, file.HealthEdu_ID);
                    Save();
                }
                catch (Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
        }
    }
}
