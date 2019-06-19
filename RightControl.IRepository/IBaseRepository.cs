using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        #region CRUD
        int Create(T model);
        T Read(int Id);
        int Update(T model);
        int Update(T model, string updateFields);
        int Delete(int Id);
        /// <summary>
        /// 根据条件删除
        /// </summary>
        int DeleteByWhere(string where);
        #endregion
        IEnumerable<T> GetByPage(SearchFilter filter, out long total);
        IEnumerable<T> GetByPageUnite(SearchFilter filter, out long total);
        IEnumerable<T> GetAll(string returnFields = null, string orderby = null);
        IEnumerable<T> GetByWhere(string where = null, object param = null, string returnFields = null, string orderby = null);
        long GetTotal(SearchFilter filter);
    }
}
