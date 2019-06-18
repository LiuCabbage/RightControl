using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IRepository
{
    public interface IMenuActionRepository : IBaseRepository<MenuActionModel>
    {
        /// <summary>
        /// 保存菜单权限配置
        /// </summary>
        /// <param name="entitys">菜单权限列表</param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        int SavePermission(IEnumerable<MenuActionModel> entitys, int menuId);
    }
}
