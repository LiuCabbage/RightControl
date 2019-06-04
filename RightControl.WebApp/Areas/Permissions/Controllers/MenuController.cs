using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.Permissions.Controllers
{
    public class MenuController : Controller
    {
        // GET: Permissions/Menu
        public ActionResult Index()
        {
            return View();
        }
    }
}