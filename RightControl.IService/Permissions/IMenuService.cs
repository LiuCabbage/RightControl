using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IService
{
    public interface IMenuService : IBaseService<MenuModel>
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="isIndex">是否是首页</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        dynamic GetMenusList(bool isIndex, int roleId);
        string GetParentMenuName(int Id);
        /// <summary>
        /// 获取可用菜单列表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        IEnumerable<MenuModel> GetAvailableMenuList(int roleId);
        /// <summary>
        /// 删除菜单时,同时删除t_menu_action和t_menu_role_action记录
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        bool DeleteMenuAllByMenuId(int menuId);
    }
}
