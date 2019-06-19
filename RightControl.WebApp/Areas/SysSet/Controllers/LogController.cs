using RightControl.IService;
using RightControl.Model;
using RightControl.WebApp.Areas.Admin.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;

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
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var result = service.DeleteModel(Id) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
        [HttpPost]
        public ActionResult BatchDel(IEnumerable<LogModel> list)
        {
            string where = "";
            List<LogModel> logModelList = list as List<LogModel>;
            foreach (var item in list)
            {
                where += item.Id + ",";
            }
            where = "Where Id in (" + where.Substring(0, where.Length-1)+")";
            var result = service.DeleteByWhere(where) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
    }
}