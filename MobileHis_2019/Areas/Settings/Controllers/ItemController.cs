using BLL;
using Common;
using MobileHis.Models.Areas.Drug.ViewModels;
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
        private DrugBLL drugBLL;
        private DrugCostBLL drugCostBLL;
        private DrugAppearanceBLL drugAppearanceBLL = new DrugAppearanceBLL();
        private ModelStateWrapper modelState;
        public ItemController()
        {
            modelState = new ModelStateWrapper(ModelState);
            drugBLL = new DrugBLL(modelState);
        }
        // GET: Settings/Item
        public ActionResult Index([Bind(Prefix = "Item2")] DrugsFilter filter)//, int? page)
        {
            //int current_page = 0;
            //filter = filter ?? drugAppearanceBLL.NewFilter();
            //current_page = (page ?? filter.page ?? 1) - 1;

            //var entity = drugBLL.Filter(filter);
            return View(new 
                Tuple<IPagedList<DrugViewModel>, DrugsFilter>(
                drugBLL.Filter(filter), 
                filter));
            
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
                var drug = drugBLL.GetDrugByID(id.Value);
                if (drug == null)
                {
                    return RedirectToAction("Index");
                }
                var cost = drugCostBLL.GetByDrugID(id.Value);
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
                drugBLL.CreateOrUpdate(model);

                if (ModelState.Any())
                    return View(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DrugSettingModelView model)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Guid DrugID)
        {
            return View();
        }
    }
}