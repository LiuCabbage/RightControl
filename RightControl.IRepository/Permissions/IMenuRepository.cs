using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IRepository
{
    public interface IMenuRepository:IBaseRepository<MenuModel>
    {
        MenuModel GetParentMenu(string sql, int Id);
        /// <summary>
        /// 获取有效菜单列表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        IEnumerable<MenuModel> GetAvailableMenuList(string sql);
        /// <summary>
        /// 根据角色ID获取菜单列表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        IEnumerable<MenuModel> GetMenuListByRoleId(string sql, int roleId);
        /// <summary>
        /// 删除菜单时,同时删除t_menu_action和t_menu_role_action记录
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        bool DeleteMenuAllByMenuId(int menuId);
    }
}
