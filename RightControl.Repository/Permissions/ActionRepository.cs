using Dapper;
using RightControl.Common;
using RightControl.IRepository;
using RightControl.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RightControl.Repository
{
    public class ActionRepository : BaseRepository<ActionModel>, IActionRepository
    {
        public IEnumerable<ActionModel> GetActionListByRoleId(int roleId, int menuId, out IEnumerable<ActionModel> selectList)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT a.Id,a.ActionName from t_action a INNER JOIN t_menu_role_action mra on a.Id=mra.ActionId and mra.RoleId=@RoleId and mra.MenuId=@MenuId;");
                sb.Append("SELECT a.Id,a.ActionName from t_action a INNER JOIN t_menu_action ma on a.Id=ma.ActionId and ma.MenuId=@MenuId ORDER BY a.OrderBy");
                using (var reader = conn.QueryMultiple(sb.ToString(), new { MenuId = menuId, RoleId = roleId }))
                {
                    selectList = reader.Read<ActionModel>();
                    return reader.Read<ActionModel>();
                }
            }
        }
        public IEnumerable<ActionModel> GetActionListByMenuId(int menuId)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                string sql = "select a.* from t_menu_action ma INNER JOIN t_action a on ma.ActionId=a.Id and ma.MenuId=@MenuId ";
                return conn.Query<ActionModel>(sql, new { MenuId = menuId });
            }
        }
        public IEnumerable<ActionModel> GetActionListByMenuIdRoleId(int menuId, int roleId, PositionEnum position)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                string sql = "select a.* from t_menu_role_action mra INNER JOIN t_action a on mra.ActionId=a.Id and mra.MenuId=@MenuId and  mra.RoleId=@RoleId and a.Position=@Position";
                return conn.Query<ActionModel>(sql, new { MenuId = menuId, RoleId = roleId, Position = (int)position });
            }
        }
        public bool DeleteActionAllByActionId(int actionId)
        {
            string sql1 = string.Format("DELETE FROM t_action WHERE id={0}", actionId);
            string sql2 = string.Format("DELETE FROM t_menu_action WHERE ActionId={0}", actionId);
            string sql3 = string.Format("DELETE FROM t_menu_role_action WHERE ActionId={0}", actionId);
            using (var conn = MySqlHelper.GetConnection())
            {
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    conn.Execute(sql1, null, transaction);
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
