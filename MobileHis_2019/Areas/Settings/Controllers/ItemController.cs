using BLL;
using MobileHis.Models.Areas.Drug.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class ItemController : MobileHis_2019.Controllers.BaseController
    {
        private DrugBLL drugBLL;
        private ModelStateWrapper modelState;
        public ItemController()
        {
            modelState = new ModelStateWrapper(ModelState);
            drugBLL = new DrugBLL(modelState);
        }
        // GET: Settings/Item
        public ActionResult Index([Bind(Prefix = "Item2")] DrugsFilter filter, int? page)
        {
            int current_page = 0;
            using (DrugAppearanceDal dal = new DrugAppearanceDal())
            {
                filter = filter ?? dal.NewFilter();
                current_page = (page ?? filter.page ?? 1) - 1;
            }

            //filter.AddFilerCodit();           
            
            var entity = drugBLL.Filter(filter);
            entity = dal.Sort(entity);
            var model = new Tuple<IPagedList<MobileHis.Data.Drug>, DrugsFilter>(entity.ToPagedList(current_page + 1, Config.PageSize), filter);
            return View(model);
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DrugSettingModelView model)
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
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