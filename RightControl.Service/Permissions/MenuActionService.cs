using RightControl.IRepository;
using RightControl.IService;
using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.Service
{
    public class MenuActionService : BaseService<MenuActionModel>, IMenuActionService
    {
        public IMenuActionRepository repository { get; set; }
        /// <summary>
        /// 保存菜单权限配置
        /// </summary>
        /// <param name="entitys">菜单权限列表</param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public int SavePermission(IEnumerable<MenuActionModel> entitys, int menuId)
        {
            return repository.SavePermission(entitys, menuId);
        }
        /// <summary>
        /// 这里这个方法没意义，仅仅实现接口
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public dynamic GetListByFilter(MenuActionModel filter, PageInfo pageInfo)
        {
            return GetListByFilter(filter, pageInfo, "");
        }
    }
}
