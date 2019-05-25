/*******************************
** 作者：zouqj
** 时间：2018/4/21 17:51:49
** 版本: V1.0.0
** CLR:  4.0.30319.42000
** GUID: c99b7723-9bc5-4dc8-9a01-462f5ffa9061
** 描述： 
*******************************/
using RightControl.Common;
using System.Web.Mvc;

namespace RightControl.WebApp
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;
        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                WebHelper.WriteCookie("nfine_login_error", "overdue");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
                return;
            }
        }
    }
}