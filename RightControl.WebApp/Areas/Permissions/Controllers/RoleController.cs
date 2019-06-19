using RightControl.IService;
using RightControl.Model;
using RightControl.WebApp.Areas.Admin.Controllers;
using System;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.Permissions.Controllers
{
    public class RoleController : BaseController
    {
        public IRoleService service { get; set; }
        // GET: Permissions/Role
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }
        [HttpGet]
        public JsonResult List(PageInfo pageInfo, RoleModel filter)
        {
            var result = service.GetListByFilter(filter, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int Id)
        {
            var model = service.ReadModel(Id);
            return View(model);
        }
        public ActionResult Edit(int Id)
        {
            var model = service.ReadModel(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(RoleModel model)
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
        public ActionResult Add(RoleModel model)
        {
            model.CreateOn = DateTime.Now;
            model.CreateBy = Operator.UserId;
            var result = service.CreateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            //删除角色时,同时删除菜单角色权限记录
            var result = service.DeleteRoleAllByRoleId(Id) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
        public ActionResult Assign(int Id)
        {
            ViewBag.RoleId = Id;
            return View();
        }
    }
}