using DapperExtensions.MySQLExt;
using RightControl.IRepository;
using RightControl.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RightControl.Repository
{
    public class MenuActionRepository : BaseRepository<MenuActionModel>, IMenuActionRepository
    {
        /// <summary>
        /// 保存菜单权限配置
        /// </summary>
        /// <param name="entitys">菜单权限列表</param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public int SavePermission(IEnumerable<MenuActionModel> entitys, int menuId)
        {
            var result = 0;
            using (var conn = MySqlHelper.GetConnection())
            {
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    conn.DeleteByWhere<MenuActionModel>(" where MenuId=@MenuId", new { MenuId = menuId }, transaction);
                    if (entitys!=null)
                    {
                        conn.InsertBatch<MenuActionModel>(entitys, transaction);
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
