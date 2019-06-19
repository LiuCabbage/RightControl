using RightControl.IRepository;
using RightControl.IService;
using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.Service
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseRepository<T> baseRepository { get; set; }
        #region 接口实现
        #region CRUD
        public bool CreateModel(T model)
        {
            return baseRepository.Create(model) > 0 ? true : false;
        }
        public T ReadModel(int Id)
        {
            return baseRepository.Read(Id);
        }
        public bool UpdateModel(T model)
        {
            return baseRepository.Update(model) > 0 ? true : false;
        }
        public bool UpdateModel(T model, string updateFields)
        {
            return baseRepository.Update(model, updateFields) > 0 ? true : false;
        }
        public bool DeleteModel(int Id)
        {
            return baseRepository.Delete(Id) > 0 ? true : false;
        }
        public bool DeleteByWhere(string where)
        {
            return baseRepository.DeleteByWhere(where) > 0 ? true : false;
        }
        #endregion
        public IEnumerable<T> GetAll(string returnFields = null, string orderby = null)
        {
            return baseRepository.GetAll(returnFields, orderby);
        }
        public dynamic GetListByFilter(T filter, PageInfo pageInfo, string where = null)
        {
            string _orderBy = string.Empty;
            if (!string.IsNullOrEmpty(pageInfo.field))
            {
                _orderBy = string.Format(" ORDER BY {0} {1}", pageInfo.field, pageInfo.order);
            }
            else
            {
                _orderBy = " ORDER BY CreateOn desc";
            }
            long total = 0;
            var list = baseRepository.GetByPage(new SearchFilter { pageIndex = pageInfo.page, pageSize = pageInfo.limit, returnFields = pageInfo.returnFields, param = filter, where = where, orderBy = _orderBy }, out total);

            return Pager.Paging(list, total);
        }
        #endregion
        public dynamic GetPageUnite(IBaseRepository<T> repository, PageInfo pageInfo, string where, object filter)
        {
            string _orderBy = string.Empty;
            if (!string.IsNullOrEmpty(pageInfo.field))
            {
                _orderBy = string.Format(" ORDER BY {0} {1}", pageInfo.field, pageInfo.order);
            }
            else
            {
                _orderBy = string.Format(" ORDER BY {0}CreateOn desc", pageInfo.prefix);
            }
            long total = 0;
            var list = repository.GetByPageUnite(new SearchFilter { pageIndex = pageInfo.page, pageSize = pageInfo.limit, returnFields = pageInfo.returnFields, param = filter, where = where, orderBy = _orderBy }, out total);
            return Pager.Paging(list, total);
        }
        protected string CreateWhereStr(Entity filter, string _where)
        {
            if (!string.IsNullOrEmpty(filter.StartEndDate) && filter.StartEndDate != " ~ ")
            {
                if (filter.StartEndDate.Contains("+"))
                {
                    filter.StartEndDate = filter.StartEndDate.Replace("+", "");
                }
                var dts = filter.StartEndDate.Trim().Split('~');
                var start = dts[0].Trim();
                var end = dts[1].Trim();
                if (!string.IsNullOrEmpty(start))
                {
                    _where += string.Format(" and CreateOn>='{0}'", start + " 00:00");
                }
                if (!string.IsNullOrEmpty(end))
                {
                    _where += string.Format(" and CreateOn<='{0}'", end + " 59:59");
                }
            }
            return _where;
        }
        public IEnumerable<T> GetByWhere(string where = null, object param = null, string returnFields = null, string orderby = null)
        {
            return baseRepository.GetByWhere(where, param, returnFields, orderby);
        }
    }
}
