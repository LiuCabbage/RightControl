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
    public class MenuRoleActionController : BaseController
    {
        private readonly IMenuRoleActionService service;
        public MenuRoleActionController(IMenuRoleActionService _service)
        {
            service = _service;
        }
        [HttpPost]
        public ActionResult InsertBatch(IEnumerable<MenuRoleActionModel> list, int roleId)
        {
            var result = service.SavePermission(list, roleId) > 0 ? SuccessTip() : ErrorTip();
            return Json(result);
        }
    }
}