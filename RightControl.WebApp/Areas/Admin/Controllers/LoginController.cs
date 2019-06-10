using RightControl.Common;
using RightControl.IService;
using RightControl.Model;
using System;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;
        private ILogService logService;
        public LoginController(IUserService _userService, ILogService _logService)
        {
            userService = _userService;
            logService = _logService;
        }
        // GET: Admin/Login
        public ActionResult Index()
        {
            ViewBag.Title = Configs.GetValue("SiteName");
            ViewBag.CopyRight = Configs.GetValue("CopyRight");
            ViewBag.SiteDomain = Configs.GetValue("SiteDomain");
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            logService.WriteDbLog(new LogModel
            {
                LogType = DbLogType.Exit.ToString(),
                UserName = OperatorProvider.Provider.GetCurrent().UserName,
                RealName = OperatorProvider.Provider.GetCurrent().RealName,
                Status = true,
                Description = "安全退出系统",
            });
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            LogModel logEntity = new LogModel();
            logEntity.ModuleName = "系统登录";
            logEntity.LogType = DbLogType.Login.ToString();
            try
            {
                if (Session["nfine_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["nfine_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }
                UserModel userEntity = userService.CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.Id;
                    operatorModel.UserName = userEntity.UserName;
                    operatorModel.RealName = userEntity.RealName;
                    operatorModel.RoleId = userEntity.RoleId;
                    operatorModel.HeadShot = userEntity.HeadShot;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userEntity.UserName == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.UserName = userEntity.UserName;
                    logEntity.RealName = userEntity.RealName;
                    logEntity.Status = true;
                    logEntity.Description = "登录成功";
                    logEntity.CreateBy = userEntity.Id;
                    logService.WriteDbLog(logEntity);
                    return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
                }
                else
                {
                    return Content(new AjaxResult { state = ResultType.error.ToString(), message = "用户名或密码错误。" }.ToJson());
                }
            }
            catch (Exception ex)
            {
                logEntity.UserName = username;
                logEntity.RealName = username;
                logEntity.Status = false;
                logEntity.Description = "登录失败，" + ex.Message;
                logService.WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}