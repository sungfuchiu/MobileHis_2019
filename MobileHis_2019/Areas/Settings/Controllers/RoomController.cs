using BLL;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class RoomController : BaseAPIController<RoomModel>
    {
        private RoomBLL _roomBLL;
        private ModelStateWrapper _modelState;
        public RoomController()
        {
            _modelState = new ModelStateWrapper(ModelState);
            _roomBLL = new RoomBLL(_modelState);
            IBLL = _roomBLL;
        }
        [HttpPost]
        public string GetOneByJson(int id)
        {
            return JsonConvert.SerializeObject(_roomBLL.ReadItem(id));
        }
    }
}