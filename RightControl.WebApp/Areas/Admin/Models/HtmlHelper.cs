using RightControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RightControl.WebApp
{
    public static class MyExtHtmlLabel
    {
        /// <summary>
        /// 菜单管理权限复选框
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="_list"></param>
        /// <returns></returns>
        public static HtmlString ActionCheckBox(this HtmlHelper helper, dynamic _list = null, dynamic _alist = null)
        {
            StringBuilder sb = new StringBuilder();
            var list = _list as List<ActionModel>;
            var alist = _alist as List<ActionModel>;
            if (list != null && list.Count > 0)
            {
                foreach (var v in list)
                {
                    bool isSelect = false;
                    foreach (var item in alist)
                    {
                        if (v.ActionCode == item.ActionCode)
                        {
                            isSelect = true;
                        }
                    }
                    sb.AppendFormat(@"<input type='checkbox' lay-skin='primary' name='{0}' title='{1}' value='{2}' {3}>", v.ActionCode, v.ActionName, v.Id, isSelect ? "checked" : "");
                }
            }
            return new HtmlString(sb.ToString());
        }
        public static HtmlString DisplayStatusHtml(this HtmlHelper helper, bool? value)
        {
            var msg = value.Value ? "启用" : "停用";
            return new HtmlString(string.Format("<span>{0}</span>", msg));
        }
        public static HtmlString StatusRadioHtml(this HtmlHelper helper, bool? value)
        {
            var msg = value.Value ? "启用" : "停用";
            string enabledStatus = value.Value ? "checked" : "";
            string disabledStatus = value.Value ? "" : "checked";

            string result = string.Format(@"<input name = ""Status"" value = ""true"" title = ""启用"" {0} type = ""radio"" >
<div class=""layui-unselect layui-form-radio layui-form-radioed""><i class=""layui-anim layui-icon""></i><div>启用</div></div>
  <input name = ""Status"" value=""false"" title=""停用"" type=""radio"" {1}>
<div class=""layui-unselect layui-form-radio""><i class=""layui-anim layui-icon""></i><div>停用</div></div>", enabledStatus, disabledStatus);

            return new HtmlString(result);
        }
        /// <summary>
        /// 状态下拉框
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="defaultTxt">默认显示文本</param>
        /// <returns></returns>
        public static HtmlString StatusSelectHtml(this HtmlHelper helper, string defaultTxt = "")
        {
            return new HtmlString(string.Format(@"<select name='Status'>
                            <option value = ''>{0}</option >
                            <option value = 'true'> 启用 </option>
                            <option value = 'false'> 停用 </option>
                             </select>", defaultTxt));
        }
        /// <summary>
        /// 性别下拉框
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="defaultTxt">默认显示文本</param>
        /// <returns></returns>
        public static HtmlString GanderRadioHtml(this HtmlHelper helper, int defaultVal = 1)
        {
            var _male = defaultVal == 1 ? "checked" : "";
            var _female = defaultVal == 0 ? "checked" : "";
            return new HtmlString(string.Format(@"<input type='radio' name='Gender' value='1' title='男' {0}>
                     <input type='radio' name='Gender' value='0' title='女' {1}>", _male, _female));
        }
        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString SearchBtnHtml(this HtmlHelper helper, string txt = "搜索", string _class = "")
        {
            return new HtmlString(string.Format("<a href='javascript:;' class='layui-btn{1}' id='btnSearch' data-type='reload'><i class='layui-icon'>&#xe615;</i>{0}</a>", txt, _class));
        }
        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString ResetBtnHtml(this HtmlHelper helper, string txt = "重置", string _class = " layui-btn-primary")
        {
            return new HtmlString(string.Format("<button type='reset' class='layui-btn{1}'>{0}</button>", txt, _class));
        }
        /// <summary>
        /// 表单内工具栏
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString ToolBarHtml(this HtmlHelper helper, dynamic _list = null)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("<script type='text/html' id='bar'>");
            var list = _list as List<ActionModel>;
            if (list != null && list.Count > 0)
            {
                foreach (var v in list)
                {
                    var _icon = string.IsNullOrEmpty(v.Icon) ? "" : string.Format("<i class='layui-icon iconfont {0}'></i>", v.Icon);
                    sb.AppendFormat("<a class='layui-btn layui-btn-xs {0}' lay-event='{1}'>{3}{2}</a>", v.ClassName, v.Method, v.ActionName, _icon);
                }
            }
            //sb.Append("</script>");
            return new HtmlString(sb.ToString());
        }
        /// <summary>
        /// 表单外工具栏
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString TopToolBarHtml(this HtmlHelper helper, dynamic _list = null, string initTxt = null)
        {
            StringBuilder sb = new StringBuilder();
            var list = _list as List<ActionModel>;
            if (list != null && list.Count > 0)
            {
                foreach (var v in list)
                {
                    sb.AppendFormat(@"<a href='javascript:;' class='layui-btn {0}' id='btn{1}'>
                            <i class='layui-icon iconfont {2}'></i> {3}
                        </a>", v.ClassName, v.ActionCode, v.Icon, initTxt == null ? v.ActionName : initTxt);
                }
            }
            return new HtmlString(sb.ToString());
        }
    }
}