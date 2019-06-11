using RightControl.Common;
using RightControl.WebApp.Areas.Admin.Controllers;
using System;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.SysSet.Controllers
{
    public class WebSiteController : BaseController
    {
        // GET: SysSet/WebSite
        public override ActionResult Index(int? id)
        {
            return View(GetWebSiteInfo());
        }
        [HttpPost]
        public ActionResult Index(WebSiteModel model)
        {
            try
            {
                Configs.SetValue("SiteName", model.SiteName);
                Configs.SetValue("SiteDomain", model.SiteDomain);
                Configs.SetValue("MetaKey", model.MetaKey);
                Configs.SetValue("MetaDescribe", model.MetaDescribe);
                Configs.SetValue("MaxFileUpload", model.MaxFileUpload);
                Configs.SetValue("CacheTime", model.HomeTitle);
                Configs.SetValue("CacheTime", model.CacheTime);
                Configs.SetValue("CopyRight", model.CopyRight);
                Configs.SetValue("UploadFileType", model.UploadFileType);
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error:"+ex.Message;
                return View(GetWebSiteInfo());
            }
            ViewBag.Msg = "修改成功！";
            return View(GetWebSiteInfo());
        }
    }
}