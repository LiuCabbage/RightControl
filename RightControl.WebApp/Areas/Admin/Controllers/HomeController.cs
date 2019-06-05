using System.Web.Mvc;

namespace RightControl.WebApp.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public override ActionResult Index(int? id)
        {
            ViewBag.RealName= Operator == null ? "" : Operator.RealName;
            ViewBag.HeadShot = Operator == null ? "" : Operator.HeadShot;
            return View(GetWebSiteInfo());
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}