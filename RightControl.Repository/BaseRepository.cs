using DapperExtensions.MySQLExt;
using RightControl.IRepository;
using RightControl.Model;
using System.Collections.Generic;
using System.Data;

namespace RightControl.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        #region CRUD
        public T Read(int Id)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.GetById<T>(Id);
            }
        }
        public int Create(T model)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.Insert<T>(model);
            }
        }
        public int Update(T model)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.UpdateById<T>(model);
            }
        }
        public int Update(T model, string updateFields)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.UpdateById<T>(model, updateFields);
            }
        }
        public int Delete(int Id)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.DeleteById<T>(Id);
            }
        }
        /// <summary>
        /// 根据条件删除
        /// </summary>
        public int DeleteByWhere(string where)
        {
            using (var conn=MySqlHelper.GetConnection())
            {
                return conn.DeleteByWhere<T>(where);
            }
        }
        #endregion
        public IEnumerable<T> GetByPage(SearchFilter filter, out long total)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.GetByPage<T>(filter.pageIndex, filter.pageSize, out total, filter.returnFields, filter.where, filter.param, filter.orderBy, filter.transaction, filter.commandTimeout);
            }
        }
        public IEnumerable<T> GetByPageUnite(SearchFilter filter, out long total)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.GetByPageUnite<T>(filter.pageIndex, filter.pageSize, out total, filter.returnFields, filter.where, filter.param, filter.orderBy, filter.transaction, filter.commandTimeout);
            }
        }
        public IEnumerable<T> GetAll(string returnFields = null, string orderby = null)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.GetAll<T>(returnFields, orderby);
            }
        }
        public IEnumerable<T> GetByWhere(string where = null, object param = null, string returnFields = null, string orderby = null)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.GetByWhere<T>(where, param, returnFields, orderby);
            }
        }
        public long GetTotal(SearchFilter filter)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.GetTotal<T>(filter.where, filter.param);
            }
        }
    }
}
