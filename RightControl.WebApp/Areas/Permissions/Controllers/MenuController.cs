using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RightControl.Model;
using RightControl.IService;
using RightControl.WebApp.Areas.Admin.Controllers;

namespace RightControl.WebApp.Areas.Permissions.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuService service;
        public MenuController(IMenuService _service)
        {
            service = _service;
        }

        // GET: Permissions/Menu
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMenuList(bool isIndex = false)
        {
            object result = service.GetMenusList(isIndex, Operator.RoleId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }



    }
}