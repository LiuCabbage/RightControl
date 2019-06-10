using RightControl.Common;
using RightControl.IService;
using RightControl.Model;
using RightControl.WebApp.Areas.Admin.Controllers;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.SysSet.Controllers
{
    public class PassWordController : BaseController
    {
        public IUserService userService { get; set; }
        // GET: SysSet/PassWord
        public override ActionResult Index(int? id)
        {
            ViewBag.UserName = Operator.UserName;
            base.Index(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PassWordModel model)
        {
            ViewBag.UserName = model.UserName;
            if (userService.CheckLogin(model.UserName, Md5.md5(model.OldPassword, 32)) == null)
            {
                ViewBag.Msg = "原始密码输入错误";
                return View();
            }
            LogModel logEntity = new LogModel
            {
                ModuleName = "修改密码",
                LogType = DbLogType.Update.ToString(),
                UserName = Operator.UserName,
                RealName = Operator.RealName
            };
            if (userService.ModifyPwd(model))
            {
                logEntity.Status = true;
                logEntity.Description = "密码修改成功";
                logService.WriteDbLog(logEntity);
                ViewBag.Msg = "密码修改成功";
            }
            else
            {
                logEntity.Status = false;
                logEntity.Description = "密码修改失败";
                logService.WriteDbLog(logEntity);
                ViewBag.Msg = "密码修改失败";
            }
            return View();
        }
    }
}