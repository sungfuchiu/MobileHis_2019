using Common;
using MobileHis.Data;
using MobileHis.Misc;
using MobileHis.Models.ApiModel;
using MobileHis.Models.Areas.Drug.ViewModels;
using MobileHis.Models.ViewModels;
using MobileHis_2019.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class ItemController : MobileHis_2019.Controllers.BaseController
    {
        //private DrugBLL _drugBLL;
        //private DrugCostBLL _drugCostBLL;
        //private DrugAppearanceBLL _drugAppearanceBLL;
        //private DrugSettingBLL _drugSettingBLL;
        //private CodeFileBLL _codeFileBLL;
        private ModelStateWrapper _modelState;
        IDrugService _drugService;
        IDrugSettingService _drugSettingService;
        IDrugCostService _drugCostService;
        IDrugAppearanceService _drugAppearanceService;
        ICodeFileService _codeFileService;
        DrugsFilter _drugsFilter;
        public DrugsFilter DrugsFilter
        {
            get
            {
                if(_drugsFilter == null)
                {
                    return _drugAppearanceService.NewFilter();
                }
                else
                {
                    return _drugsFilter;
                }
            }
            set
            {
                _drugsFilter = value;
            }
        }
        public ItemController(
            IDrugService drugService, 
            IDrugSettingService drugSettingService, 
            IDrugCostService drugCostService, 
            IDrugAppearanceService drugAppearanceService, 
            ICodeFileService codeFileService,
            ISystemLogService systemLogService) : base(systemLogService)
        {
            _modelState = new ModelStateWrapper(ModelState);
            drugService.InitialiseIValidationDictionary(_modelState);
            drugSettingService.InitialiseIValidationDictionary(_modelState);
            drugCostService.InitialiseIValidationDictionary(_modelState);
            drugAppearanceService.InitialiseIValidationDictionary(_modelState);
            codeFileService.InitialiseIValidationDictionary(_modelState);
            _drugService = drugService;
            _drugSettingService = drugSettingService;
            _drugCostService = drugCostService;
            _drugAppearanceService = drugAppearanceService;
            _codeFileService = codeFileService;
        }
        // GET: Settings/Item
        public ActionResult Index([Bind(Prefix = "Item2")] DrugsFilter filter)
        {
            DrugsFilter = filter;

            var entity = _drugService.Filter(DrugsFilter);
            return View(new 
                Tuple<IPagedList<DrugViewModel>, DrugsFilter>(
                entity,
                DrugsFilter));
            
        }
        public ActionResult Edit(Guid? id)
        {
            if (id.HasValue)
            {
                var drug = _drugService.Read(a => a.GID == id.Value);
                if (drug == null)
                {
                    return RedirectToAction("Index");
                }
                var cost = _drugCostService.GetByDrugID(id.Value);
                return View(DrugViewModel.Load(drug, cost));
            }
            else
            {
                return View(new DrugViewModel());
            }
        }
        [HttpPost]
        public ActionResult Edit(DrugViewModel model)
        {
            if (ModelState.IsValid)
            {
                _drugService.CreateOrUpdate(model);
                if(ModelState.IsValid)
                    EditSuccessfully();
            }
            return View(model);
        }
        public ActionResult Setting(Guid? id)
        {
            if (id.HasValue)
            {
                DrugSettingModelView model = _drugSettingService.GetSettingByDrugID(id.Value);
                if (Request.IsAjaxRequest())
                {
                    return Json(model);
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(new DrugSettingModelView()); 
            }
        }
        [HttpPost]
        public ActionResult Setting(DrugSettingModelView model)
        {
            if (ModelState.IsValid)
            {
                _drugSettingService.CreateOrUpdate(model);
                EditSuccessfully();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Guid drugID)
        {
            _drugService.Delete(drugID);
            return Json(new BaseApiModel()
            {
                success = _modelState.IsValid(),
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpGet]
        public ActionResult Photo(Guid? id, int? download)
        {
            var storage = MobileHis.Misc.Storage.GetStorage(StorageScope.Drug);
            if (id.HasValue && storage.FileExist(id.Value))
            {
                var file = storage.Open(id.Value);
                if (download.HasValue)
                    return File(file.Item3, file.Item2, file.Item1);
                else
                    return File(file.Item3, file.Item2);
            }
            return ImageNotFound();
        }

        [HttpGet]
        public ActionResult DrugBarCode(string DrugCode)
        {
            if (!string.IsNullOrEmpty(DrugCode))
            {
                return File(
                    ImageHelper.ImageToByte(
                        ImageHelper.GetCode128(
                            DrugCode,
                            height:59,
                            font:new System.Drawing.Font("Verdana", 6f)
                            )
                        ), "image/jpeg");
            }
            return ImageNotFound();
        }
    }
}