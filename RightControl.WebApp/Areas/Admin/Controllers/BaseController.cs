using RightControl.Common;
using RightControl.IService;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.Admin.Controllers
{
    [HandlerLogin]
    public class BaseController : Controller
    {
        protected const string SuccessText = "操作成功！";
        protected const string ErrorText = "操作失败！";
        public ILogService logService { get; set; }
        public IActionService actionService { get; set; }
        public OperatorModel Operator
        {
            get
            {
                return OperatorProvider.Provider.GetCurrent();
            }
        }

        // GET: Admin/Base
        public virtual ActionResult Index(int? id)
        {
            var _menuId = id == null ? 0 : id.Value;
            var _roleId = Operator.RoleId;
            if (id != null)
            {
                ViewData["ActionList"] = actionService.GetActionListByMenuIdRoleId(_menuId, _roleId, PositionEnum.FormInside);
                ViewData["ActionFormRightTop"] = actionService.GetActionListByMenuIdRoleId(_menuId, _roleId, PositionEnum.FormRightTop);
            }
            return View();
        }
        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="message">提示文本</param>
        /// <returns></returns>
        protected virtual AjaxResult SuccessTip(string message = SuccessText)
        {
            return new AjaxResult { state = ResultType.success.ToString(), message = message };
        }
        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="message">提示文本</param>
        /// <returns></returns>
        protected virtual AjaxResult ErrorTip(string message = ErrorText)
        {
            return new AjaxResult { state = ResultType.error.ToString(), message = message };
        }
        protected WebSiteModel GetWebSiteInfo()
        {
            return new WebSiteModel
            {
                SiteName = Configs.GetValue("SiteName"),
                SiteDomain = Configs.GetValue("SiteDomain"),
                CacheTime = Configs.GetValue("CacheTime"),
                MaxFileUpload = Configs.GetValue("MaxFileUpload"),
                UploadFileType = Configs.GetValue("UploadFileType"),
                HomeTitle = Configs.GetValue("HomeTitle"),
                MetaKey = Configs.GetValue("MetaKey"),
                MetaDescribe = Configs.GetValue("MetaDescribe"),
                CopyRight = Configs.GetValue("CopyRight")
            };
        }
    }
}