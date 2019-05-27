using RightControl.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            ViewBag.Title = Configs.GetValue("SiteName");
            ViewBag.CopyRight = Configs.GetValue("CopyRight");
            ViewBag.SiteDomain = Configs.GetValue("SiteDomain");
            return View();
        }
    }
}