using DapperExtensions;

namespace RightControl.Model
{
    [Table("t_menu_role_action")]
    public class MenuRoleActionModel
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 操作ID
        /// </summary>
        public int ActionId { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
    }
}
