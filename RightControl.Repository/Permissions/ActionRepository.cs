using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using RightControl.Model;
using RightControl.IRepository;
using RightControl.Common;

namespace RightControl.Repository
{
    public class ActionRepository : BaseRepository<ActionModel>, IActionRepository
    {
        public IEnumerable<ActionModel> GetActionListByRoleId(int roleId, int menuId, out IEnumerable<ActionModel> selectList)
        {
            using (var conn=MySqlHelper.GetConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT a.Id,a.ActionName from t_action a INNER JOIN t_menu_role_action mra on a.Id=mra.ActionId and mra.RoleId=@RoleId and mra.MenuId=@MenuId;");
                sb.Append("SELECT a.Id,a.ActionName from t_action a INNER JOIN t_menu_action ma on a.Id=ma.ActionId and ma.MenuId=@MenuId ORDER BY a.OrderBy");
                using (var reader = conn.QueryMultiple(sb.ToString(),new { MenuId = menuId, RoleId = roleId }))
                {
                    selectList = reader.Read<ActionModel>();
                    return reader.Read<ActionModel>();
                }
            }
        }
        public IEnumerable<ActionModel> GetActionListByMenuId(int menuId)
        {
            using (var conn=MySqlHelper.GetConnection())
            {
                string sql = "select a.* from t_menu_action ma INNER JOIN t_action a on ma.ActionId=a.Id and ma.MenuId=@MenuId ";
                return conn.Query<ActionModel>(sql,new { MenuId = menuId });
            }
        }
        public IEnumerable<ActionModel> GetActionListByMenuIdRoleId(int menuId, int roleId, PositionEnum position)
        {
            using (var conn=MySqlHelper.GetConnection())
            {
                string sql = "select a.* from t_menu_role_action mra INNER JOIN t_action a on mra.ActionId=a.Id and mra.MenuId=@MenuId and  mra.RoleId=@RoleId and a.Position=@Position";
                return conn.Query<ActionModel>(sql,new { MenuId = menuId, RoleId = roleId, Position = (int)position });
            }
        }
    }
}
