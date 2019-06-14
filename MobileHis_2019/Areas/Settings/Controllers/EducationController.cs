using BLL;
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
        //private EducationBLL _educationBLL;
        //private ModelStateWrapper _modelState;
        IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            //_modelState = new ModelStateWrapper(ModelState);
            //_educationBLL = new EducationBLL(_modelState);
            //IBLL = _educationBLL;
            educationService.InitialiseIValidationDictionary(
                new ModelStateWrapper(ModelState));
            _educationService = educationService;
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public string GetGuardianList(int typeID)
        {
            return JsonConvert.SerializeObject(_educationService.GetEducationList(typeID));
            //return JsonConvert.SerializeObject(_educationBLL.GetEducationList(typeID));
        }

        public ActionResult Edit(int ID)
        {
            //return View(_educationBLL.Edit(ID));
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