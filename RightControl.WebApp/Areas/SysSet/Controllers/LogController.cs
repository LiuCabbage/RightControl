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
            //批量删除传值有点问题
            //string ids = "";
            //foreach (var item in list)
            //{
            //    ids += "'" + item.Id + "',";
            //}
            //ids = ids.Substring(0, ids.Length - 1);@"(" + ids + ")"
            var result = service.BatchDeleteModel(list) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
    }
}