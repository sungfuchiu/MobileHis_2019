using Common;
using MobileHis.Models.ApiModel;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Service.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class EducationController : MobileHis_2019.Controllers.BaseAPIController<EducationModel>
    {
        IEducationService _educationService;
        public EducationController(IEducationService educationService, ISystemLogService systemLogService) : base(systemLogService)
        {
            educationService.InitialiseIValidationDictionary(
                new ModelStateWrapper(ModelState));
            _educationService = educationService;
            IService = educationService;
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public string GetGuardianList(int typeID)
        {
            return JsonConvert.SerializeObject(_educationService.GetEducationList(typeID));
        }

        public ActionResult Edit(int ID)
        {
            return View(_educationService.Edit(ID));
        }
        [HttpPost]
        public ActionResult Edit(EducationModel model)
        {
            ModelState.Clear();
            _educationService.Edit(model);
            if (ModelState.IsValid)
                EditSuccessfully();
            return View(model);
        }
        public ActionResult DeleteImg(int ID)
        {
            ModelState.Clear();
            _educationService.DeleteIMG(ID);
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
    }
}