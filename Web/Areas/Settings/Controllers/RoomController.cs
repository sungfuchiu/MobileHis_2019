using Common;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Controllers;
using MobileHis_2019.Service.Service;
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
        IRoomService _roomService;
        public RoomController(IRoomService roomService, ISystemLogService systemLogService) : base(systemLogService)
        {
            roomService.InitialiseIValidationDictionary(
                new ModelStateWrapper(ModelState));
            _roomService = roomService;
            IService = roomService;
        }
        [HttpPost]
        public string GetOneByJson(int id)
        {
            return JsonConvert.SerializeObject(_roomService.ReadItem(id));
        }
    }
}