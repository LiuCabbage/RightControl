using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RightControl.IService;
using RightControl.Model;
using RightControl.WebApp.Areas.Admin.Controllers;

namespace RightControl.WebApp.Areas.Permissions.Controllers
{
    public class MenuActionController : BaseController
    {
        private readonly IMenuActionService service;
        public MenuActionController(IMenuActionService _service)
        {
            service = _service;
        }
        [HttpPost]
        public ActionResult InsertBatch(IEnumerable<MenuActionModel> list, int menuId)
        {
            var result = service.SavePermission(list, menuId) > 0 ? SuccessTip() : ErrorTip();
            return Json(result);
        }
    }
}