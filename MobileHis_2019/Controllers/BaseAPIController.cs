﻿using BLL.Interface;
using MobileHis.Models.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Controllers
{
    public class BaseAPIController<TModel> : BaseController
    {
        protected IAPIBLL<TModel> IBLL;
        // GET: Settings/Category
        [HttpGet]
        public virtual ActionResult Index(TModel model)
        {
            IBLL.Index(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.Create(model);
            }
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpPost]
        public ActionResult Update(TModel model)
        {
            ModelState.Clear();
            IBLL.Update(model);
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ModelState.Clear();
            IBLL.Delete(ID);
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
    }
}