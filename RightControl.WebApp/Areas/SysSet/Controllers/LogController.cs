using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RightControl.WebApp.Areas.Admin.Controllers;
using RightControl.Model;
using RightControl.IService;

namespace RightControl.WebApp.Areas.SysSet.Controllers
{
    public class LogController : BaseController
    {
        private readonly ILogService service;
        public LogController(ILogService _service)
        {
            service = _service;
        }
        // GET: SysSet/Log
        public override ActionResult Index(int? id)
        {
            return View();
        }
        /// <summary>
        /// 加载数据列表
        /// </summary>
        /// <param name="filter">页面实体信息</param>
        /// <param name="pageInfo">日志查询条件</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult List(LogModel filter, PageInfo pageInfo)
        {
            var result = service.GetListByFilter(filter, pageInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}