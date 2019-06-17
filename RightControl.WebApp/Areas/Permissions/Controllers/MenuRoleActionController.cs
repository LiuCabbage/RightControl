using RightControl.IService;
using RightControl.Model;
using RightControl.WebApp.Areas.Admin.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

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