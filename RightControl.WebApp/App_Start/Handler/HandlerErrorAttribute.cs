/*******************************
** 作者：zouqj
** 时间：2018/5/13 16:34:24
** 版本: V1.0.0
** CLR:  4.0.30319.42000
** GUID: 7f325096-faba-4728-b829-ace3bb7f5eeb
** 描述： 
*******************************/
using RightControl.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RightControl.WebApp
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new ContentResult { Content = new AjaxResult { state = ResultType.error.ToString(), message = context.Exception.Message }.ToJson() };
        }
        //private void WriteLog(ExceptionContext context)
        //{
        //    if (context == null)
        //        return;
        //    var log = LogFactory.GetLogger(context.Controller.ToString());
        //    log.Error(context.Exception);
        //}
    }
}