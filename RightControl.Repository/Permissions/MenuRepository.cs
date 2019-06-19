using Dapper;
using RightControl.IRepository;
using RightControl.Model;
using System.Collections.Generic;
using System.Data;

namespace RightControl.Repository
{
    public class MenuRepository : BaseRepository<MenuModel>, IMenuRepository
    {
        public MenuModel GetParentMenu(string sql, int Id)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.QueryFirstOrDefault<MenuModel>(sql, new { Id = Id });
            }
        }
        /// <summary>
        /// 获取有效菜单列表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public IEnumerable<MenuModel> GetAvailableMenuList(string sql)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                sql += "  GROUP BY mra.MenuId";
                return conn.Query<MenuModel>(sql);
            }
        }
        /// <summary>
        /// 根据角色ID获取菜单列表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public IEnumerable<MenuModel> GetMenuListByRoleId(string sql, int roleId)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                sql += "  where mra.RoleId = @RoleId and m.Status=1 GROUP BY mra.MenuId";
                return conn.Query<MenuModel>(sql, new { RoleId = roleId });
            }
        }

        public bool DeleteMenuAllByMenuId(int menuId)
        {
            string sql1 = string.Format("DELETE FROM t_menu WHERE id={0}",menuId);
            string sql2 = string.Format("DELETE FROM t_menu_action WHERE MenuId={0}", menuId);
            string sql3 = string.Format("DELETE FROM t_menu_role_action WHERE MenuId={0}", menuId);
            using (var conn=MySqlHelper.GetConnection())
            {
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    conn.Execute(sql1,null,transaction);
                    conn.Execute(sql2, null, transaction);
                    conn.Execute(sql3, null, transaction);
                    transaction.Commit();
                    return true;
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
