using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IService
{
    public interface IMenuRoleActionService : IBaseService<MenuRoleActionModel>
    {
        /// <summary>
        /// 保存菜单角色权限配置
        /// </summary>
        /// <param name="entitys">菜单角色权限列表</param>
        /// <returns></returns>
        int SavePermission(IEnumerable<MenuRoleActionModel> entitys, int roleId);
        IEnumerable<MenuRoleActionModel> GetListByRoleIdMenuId(int roleId, int menuId);
    }
}