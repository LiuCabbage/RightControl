using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RightControl.Model;
using RightControl.IRepository;
using RightControl.IService;

namespace RightControl.Service
{
    public class MenuService : BaseService<MenuModel>, IMenuService
    {
        public IMenuRepository repository { get; set; }
        public IActionService actionService { get; set; }
        public IMenuRoleActionService menuRoleActionService { get; set; }
        private void SetTree(tree _tree, string menuUrl, bool isIndex)
        {
            if (isIndex)
            {
                _tree.href = menuUrl;
            }
        }
        public string GetIconHtmlString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='site-doc-icon'>");
            return sb.ToString();
        }
        public string GetParentMenuName(int Id)
        {
            var sql = "select m.MenuName from t_menu m where m.Id=(SELECT ParentId as Id from t_menu where Id=@Id)";
            var result = repository.GetParentMenu(sql, Id);
            return result == null ? "" : result.MenuName;
        }
        public dynamic GetMenusList(bool isIndex, int roleId)
        {
            IEnumerable<MenuModel> allMenus = GetMenuListByRoleId(roleId);
            List<tree> treeList = new List<tree>();
            var rootMenus = allMenus.Where(x => x.ParentId == 0).OrderBy(x => x.OrderNo);
            int index = 0;
            foreach (var r in rootMenus)
            {
                var _tree = new tree { id = r.Id, name = r.MenuName, title = r.MenuName, icon = r.MenuIcon };
                if (isIndex == true && index == 0) //首页菜单默认第一项展开
                {
                    _tree.spread = true;
                }
                index++;
                GetMenusByRootMenuId(treeList, allMenus, _tree, r.Id, isIndex);
                treeList.Add(_tree);
            }
            var result = treeList;
            return treeList;
        }
        /// <summary>
        /// 根据一级菜单加载子菜单列表
        /// </summary>
        /// <returns></returns>
        private void GetMenusByRootMenuId(List<tree> treeList, IEnumerable<MenuModel> allMenus, tree tree, int menuId, bool isIndex)
        {
            var childMenus = allMenus.Where(x => x.ParentId == menuId).OrderBy(x => x.OrderNo);
            if (childMenus != null && childMenus.Count() > 0)
            {
                List<tree> _children = new List<tree>();
                foreach (var m in childMenus)
                {
                    var _tree = new tree { id = m.Id, name = m.MenuName, title = m.MenuName, icon = m.MenuIcon };
                    SetTree(_tree, m.MenuUrl, isIndex);
                    _children.Add(_tree);
                    tree.children = _children;
                    GetMenusByRootMenuId(treeList, allMenus, _tree, m.Id, isIndex);
                }
            }
        }
        /// <summary>
        /// 根据角色ID获取菜单列表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        private IEnumerable<MenuModel> GetMenuListByRoleId(int roleId)
        {
            string sql = @"SELECT
	m.Id,m.MenuName,m.MenuIcon,m.OrderNo,m.ParentId,m.MenuUrl
FROM
	t_menu_role_action mra
INNER JOIN t_menu m ON mra.MenuId = m.Id";
            var list = repository.GetMenuListByRoleId(sql, roleId);

            return list;
        }
        public dynamic GetListByFilter(MenuModel filter, PageInfo pageInfo)
        {
            string _where = " where 1=1";
            if (!string.IsNullOrEmpty(filter.MenuName))
            {
                _where += " and MenuName=@MenuName";
            }
            pageInfo.field = "ParentId asc,OrderNo asc";
            return GetListByFilter(filter, pageInfo, _where);
        }
        /// <summary>
        /// 获取可用菜单列表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public IEnumerable<MenuModel> GetAvailableMenuList(int roleId)
        {
            string sql = @"SELECT
	m.Id,m.MenuName,m.MenuIcon,m.OrderNo,m.ParentId
FROM
	t_menu_role_action mra
INNER JOIN t_menu m ON mra.MenuId = m.Id";
            var list = repository.GetAvailableMenuList(sql);
            foreach (var v in list)
            {
                v.MenuActionHtml = actionService.GetActionListHtmlByRoleId(roleId, v.Id);
                v.IsChecked = menuRoleActionService.GetListByRoleIdMenuId(roleId, v.Id).Count() > 0 ? true : false;
            }
            return list;
        }

        public bool DeleteMenuAllByMenuId(int menuId)
        {
            return repository.DeleteMenuAllByMenuId(menuId);
        }
    }
}
