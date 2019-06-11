using RightControl.IService;
using RightControl.Model;
using RightControl.WebApp.Areas.Admin.Controllers;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.SysSet.Controllers
{
    public class LogController : BaseController
    {
        private readonly ILogService service;
        public LogController(ILogService _service)
        {
            service = _service;
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