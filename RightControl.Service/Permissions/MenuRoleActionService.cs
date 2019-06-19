using RightControl.IRepository;
using RightControl.IService;
using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.Service
{
    public class MenuRoleActionService :BaseService<MenuRoleActionModel>, IMenuRoleActionService
    {
        public IMenuRoleActionRepository repository { get; set; }
        /// <summary>
        /// 保存菜单角色权限配置
        /// </summary>
        /// <param name="entitys">菜单角色权限列表</param>
        /// <returns></returns>
        public int SavePermission(IEnumerable<MenuRoleActionModel> entitys, int roleId)
        {
            return repository.SavePermission(entitys, roleId);
        }
        public IEnumerable<MenuRoleActionModel> GetListByRoleIdMenuId(int roleId, int menuId)
        {
            string sql = " where RoleId=@RoleId and MenuId=@MenuId";
            return repository.GetByWhere(sql, new { RoleId = roleId, MenuId = menuId });
        }

        public dynamic GetListByFilter(MenuRoleActionModel filter, PageInfo pageInfo)
        {
            return GetListByFilter(filter, pageInfo);
        }
    }
}
