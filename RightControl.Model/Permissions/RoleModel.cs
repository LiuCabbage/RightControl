using DapperExtensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace RightControl.Model
{
    [Table("t_Role")]
    public class RoleModel:Entity
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        [Display(Name ="角色编码")]
        public string RoleCode { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Display(Name = "角色名称")]
        public string RoleName { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        [Display(Name = "角色描述")]
        public string Remark { get; set; }
    }
}
