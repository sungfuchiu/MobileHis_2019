using MobileHis_2019.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Controllers
{
    public class FileController : BaseController
    {
        IFileService _fileService;
        public FileController(IFileService fileService, ISystemLogService systemLogService) : base(systemLogService)
        {
            _fileService = fileService;
        }
        protected ActionResult BlankImage()
        {
            return File(_fileService.BlankImage(), "image/jpg");
        }
        [HttpGet]
        public ActionResult GetFile(string cat, string fileName, string ids = "", bool displayDefaultImage = true)
        {
            if(_fileService.GetFile(cat, fileName, out var fileTuple, ids))
            {
                return File(fileTuple.Item1, fileTuple.Item2);
            }
            if (!displayDefaultImage)
                return BlankImage();
            else
                return ImageNotFound();

        }
    }
}