using RightControl.IService;
using RightControl.Model;
using RightControl.WebApp.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.Permissions.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuService service;
        public IMenuActionService menuActionService { get; set; }
        public IMenuRoleActionService menuRoleActionService { get; set; }
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
            bool isOk = service.CreateModel(model);
            if (isOk)
            {
                //获取新增的菜单ID
                //在t_menu_role_action新增一行(菜单ID,0,0)记录,即新增的菜单没有角色和权限按钮
                //在t_menu_role_action新增一行(菜单ID,1,0)记录,即新增的菜单超级管理员有菜单权限但没按钮权限
                string where = " where MenuName=@MenuName";
                string orderby = " ORDER BY Id DESC";
                IEnumerable<MenuModel> modelList = service.GetByWhere(where, new { MenuName = model.MenuName }, "Id", orderby);
                int menuId = 0;
                foreach (var item in modelList)
                {
                    menuId = item.Id;
                }
                MenuRoleActionModel menuRoleActionModel = new MenuRoleActionModel()
                {
                    MenuId = menuId,
                    RoleId = 0,
                    ActionId = 0
                };
                menuRoleActionService.CreateModel(menuRoleActionModel);
                MenuRoleActionModel menuRoleActionTwoModel = new MenuRoleActionModel()
                {
                    MenuId = menuId,
                    RoleId = 1,
                    ActionId = 0
                };
                menuRoleActionService.CreateModel(menuRoleActionTwoModel);
            }
            var result = isOk ? SuccessTip() : ErrorTip();
            return Json(result);
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            //删除菜单时,同时删除菜单权限,菜单角色权限记录
            var result = service.DeleteMenuAllByMenuId(Id) ? SuccessTip() : ErrorTip();
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