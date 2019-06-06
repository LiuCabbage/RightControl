using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RightControl.WebApp.Areas.Admin.Controllers;
using System.IO;
using RightControl.Model;
using RightControl.Common;
using RightControl.IService;

namespace RightControl.WebApp.Areas.SysSet.Controllers
{
    public class InfoController : BaseController
    {
        public IUserService userService { get; set; }
        // GET: SysSet/Info
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            ViewBag.MaxFileUpload = Configs.GetValue("MaxFileUpload");
            ViewBag.UploadFileType = Configs.GetValue("UploadFileType");
            var _userId = Operator.UserId;
            var model = userService.GetDetail(_userId);
            return View(model);
        }



    }
}