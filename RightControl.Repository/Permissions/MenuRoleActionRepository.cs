using DapperExtensions.MySQLExt;
using RightControl.IRepository;
using RightControl.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RightControl.Repository
{
    public class MenuRoleActionRepository : BaseRepository<MenuRoleActionModel>, IMenuRoleActionRepository
    {
        /// <summary>
        /// 保存菜单角色权限配置
        /// </summary>
        /// <param name="entitys">菜单角色权限列表</param>
        /// <returns></returns>
        public int SavePermission(IEnumerable<MenuRoleActionModel> entitys, int roleId)
        {
            var result = 0;
            using (var conn = MySqlHelper.GetConnection())
            {
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    conn.DeleteByWhere<MenuRoleActionModel>(" where RoleId=@RoleId", new { RoleId = roleId }, transaction);
                    if (entitys != null)
                    {
                        conn.InsertBatch<MenuRoleActionModel>(entitys, transaction);
                    }
                    transaction.Commit();
                    result = 1;
                }
                catch (Exception)
                {
                    result = -1;
                    transaction.Rollback();
                }
            }
            return result;
        }
    }
}
