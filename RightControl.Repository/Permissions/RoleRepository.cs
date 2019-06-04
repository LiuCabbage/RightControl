using Dapper;
using RightControl.IRepository;
using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.Repository
{
    public class RoleRepository : BaseRepository<RoleModel>, IRoleRepository
    {
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleModel> GetRoleList()
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "SELECT Id,RoleName from t_role";
                return conn.Query<RoleModel>(sql);
            }
        }
    }
}
