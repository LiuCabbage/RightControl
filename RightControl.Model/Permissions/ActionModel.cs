using DapperExtensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace RightControl.Model
{
    [Table("t_Action")]
    public class ActionModel : Entity
    {
        /// <summary>
        /// 操作编码
        /// </summary>
        [Display(Name = "操作编码")]
        public string ActionCode { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
        [Display(Name = "操作名称")]
        public string ActionName { get; set; }
        /// <summary>
        /// 显示位置
        /// </summary>
        [Display(Name = "显示位置")]
        public int Position { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        [Display(Name ="操作方法")]
        public string Method { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [Display(Name = "排序号")]
        public int OrderBy { get; set; }
        /// <summary>
        /// 样式名称
        /// </summary>
        [Display(Name = "样式名称")]
        public string ClassName { get; set; }
    }
}
