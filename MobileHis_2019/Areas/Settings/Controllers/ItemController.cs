using BLL;
using Common;
using MobileHis.Data;
using MobileHis.Misc;
using MobileHis.Models.ApiModel;
using MobileHis.Models.Areas.Drug.ViewModels;
using MobileHis.Models.ViewModels;
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
        private DrugBLL _drugBLL;
        private DrugCostBLL _drugCostBLL;
        private DrugAppearanceBLL _drugAppearanceBLL;
        private CodeFileBLL _codeFileBLL;
        private ModelStateWrapper _modelState;
        DrugsFilter _drugsFilter;
        public DrugsFilter DrugsFilter
        {
            get
            {
                if(_drugsFilter == null)
                {
                    return _drugAppearanceBLL.NewFilter();
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
        public ItemController()
        {
            _modelState = new ModelStateWrapper(ModelState);
            _drugBLL = new DrugBLL(_modelState);
            _drugCostBLL = new DrugCostBLL();
            _drugAppearanceBLL = new DrugAppearanceBLL();
            _codeFileBLL = new CodeFileBLL();
        }
        // GET: Settings/Item
        public ActionResult Index([Bind(Prefix = "Item2")] DrugsFilter filter)//, int? page)
        {
            DrugsFilter = filter;
            //int current_page = 0;
            //filter = filter ?? drugAppearanceBLL.NewFilter();
            //current_page = (page ?? filter.page ?? 1) - 1;

            var entity = _drugBLL.Filter(DrugsFilter);
            return View(new 
                Tuple<IPagedList<DrugViewModel>, DrugsFilter>(
                entity,
                DrugsFilter));
            
        }
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(DrugSettingModelView model)
        //{
        //    return View();
        //}
        public ActionResult Edit(Guid? id)
        {
            if (id.HasValue)
            {
                var drug = _drugBLL.Read(id.Value);
                if (drug == null)
                {
                    return RedirectToAction("Index");
                }
                var cost = _drugCostBLL.GetByDrugID(id.Value);
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
                _drugBLL.CreateOrUpdate(model);

                if (ModelState.Any())
                    return View(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        //[HttpPost]
        //public ActionResult Edit(DrugSettingModelView model)
        //{
        //    return View();
        //}
        public ActionResult Setting(Guid? id)
        {
            if (id.HasValue)
            {
                DrugSettingModelView model = _drugBLL.GetSettingByDrugID(id.Value);
                model.SelectListEvent += _codeFileBLL.GetDropDownList;
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
                return View(new DrugSettingModelView(_codeFileBLL.GetDropDownList)); 
            }

            //Guid _Id = Guid.Empty;
            //if (Guid.TryParse(Id, out _Id))
            //{
            //    using (DrugSettingDal dal = new DrugSettingDal())
            //    {
            //        if (_Id != Guid.Empty)
            //        {
            //            DrugSettingModelView model = dal.GetOneSettingByDrugID(_Id);
            //            if (model != null)
            //            {
            //                if (Request.IsAjaxRequest())
            //                {
            //                    return Json(model, JsonRequestBehavior.AllowGet);
            //                }
            //                else
            //                {
            //                    ViewData.Model = model;

            //                }
            //            }
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index");
            //        }
            //    }
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
        }
        [HttpPost]
        public ActionResult Delete(Guid drugID)
        {
            _drugBLL.Delete(drugID);
            return Json(new BaseApiModel()
            {
                success = _modelState.IsValid(),
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpGet]
        public ActionResult Photo(Guid? id, int? download)
        {
            var storage = MobileHis.Misc.Storage.GetStorage(StorageScope.Drug);//Storage.GetDrugAppearanceStorage;// DrugViewModel.AppearanceStorage;
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
    }
}