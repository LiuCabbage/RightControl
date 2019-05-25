using DapperExtensions;

namespace RightControl.Model
{
    [Table("t_menu_action")]
    public class MenuActionModel
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 操作ID
        /// </summary>
        public int ActionId { get; set; }
    }
}
