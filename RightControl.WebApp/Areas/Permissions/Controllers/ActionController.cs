using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RightControl.WebApp.Areas.Admin.Controllers;
using RightControl.Common;
using RightControl.Common.Extend;
using RightControl.IService;
using RightControl.Model;

namespace RightControl.WebApp.Areas.Permissions.Controllers
{
    public class ActionController : BaseController
    {
        private IActionService service;
        public ActionController(IActionService _service)
        {
            service = _service;
        }
        /// <summary>
        /// 加载数据列表
        /// </summary>
        /// <param name="pageInfo">页面实体信息</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult List(ActionModel filter, PageInfo pageInfo)
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
            ViewData["Position"] = EnumExt.GetSelectList(typeof(PositionEnum));
            var model = service.ReadModel(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ActionModel model)
        {
            model.UpdateOn = DateTime.Now;
            model.UpdateBy = Operator.UserId;
            var result = service.UpdateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
        public ActionResult Add()
        {
            ViewData["Position"] = EnumExt.GetSelectList(typeof(PositionEnum));
            return View();
        }
        [HttpPost]
        public ActionResult Add(ActionModel model)
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


    }
}