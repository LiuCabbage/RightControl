using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RightControl.Common;
using RightControl.IService;

namespace RightControl.WebApp.Areas.Admin.Controllers
{
    [HandlerLogin]
    public class BaseController : Controller
    {
        protected const string SuccessText = "操作成功！";
        protected const string ErrorText = "操作失败！";
        // GET: Admin/Base
        public ActionResult Index()
        {
            return View();
        }
    }
}