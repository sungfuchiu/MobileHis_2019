﻿using BLL;
using Common;
using MobileHis.Models.Areas.Sys.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class EducationController : MobileHis_2019.Controllers.APIBaseController<EducationModel>
    {
        private EducationBLL _educationBLL;
        private ModelStateWrapper _modelState;
        public EducationController()
        {
            _modelState = new ModelStateWrapper(ModelState);
            _educationBLL = new EducationBLL(_modelState);
            IBLL = _educationBLL;
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public string GetGuardianList(int typeID)
        {
            return JsonConvert.SerializeObject(_educationBLL.GetEducationList(typeID));
        }
        
        public ActionResult Edit(int ID)
        {
            return View(_educationBLL.Edit(ID));
        }
        [HttpPost]
        public ActionResult Edit(EducationModel model)
        {
            if (ModelState.IsValid)
            {
                _educationBLL.Edit(model);
                if (ModelState.IsValid)
                    EditSuccessfully();
            }
            return View(model);
        }
    }
}