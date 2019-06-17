using RightControl.IService;
using RightControl.Model;
using RightControl.WebApp.Areas.Admin.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.Permissions.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuService service;
        public MenuController(IMenuService _service)
        {
            service = _service;
        }
        [HttpGet]
        public JsonResult List(PageInfo pageInfo, MenuModel filter)
        {
            var list = service.GetAll();
            var result = new { code = 0, count = list.Count(), data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMenuList(bool isIndex = false)
        {
            object result = service.GetMenusList(isIndex, Operator.RoleId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int Id)
        {
            var model = service.ReadModel(Id);
            ViewBag.ParentMenuName = service.GetParentMenuName(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(MenuModel model)
        {
            model.UpdateOn = DateTime.Now;
            model.UpdateBy = Operator.UserId;
            var result = service.UpdateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(MenuModel model)
        {
            model.CreateOn = DateTime.Now;
            model.CreateBy = Operator.UserId;
            var result = service.CreateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var result = service.DeleteModel(Id) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
        [HttpGet]
        public JsonResult MenuActionList(PageInfo pageInfo, MenuModel filter, int roleId)
        {
            var list = service.GetAvailableMenuList(roleId);
            var result = new { code = 0, count = list.Count(), data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}