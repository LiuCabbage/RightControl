namespace RightControl.Service
{
    public class DefaultPaging<T> where T : class, new()
    {
        //public static dynamic GetPageData(IBaseRepository<T> repository, PageInfo pageInfo,string where,object filter)
        //{
        //    string _orderBy = string.Empty;
        //    if (!string.IsNullOrEmpty(pageInfo.field))
        //    {
        //        _orderBy = string.Format(" ORDER BY {0} {1}", pageInfo.field, pageInfo.order);
        //    }
        //    else
        //    {
        //        _orderBy = " ORDER BY CreateOn desc";
        //    }
        //    long total = 0;
        //    var list = repository.GetByPage(new SearchFilter { pageIndex = pageInfo.page, pageSize = pageInfo.limit, param = filter, where = where, orderBy = _orderBy }, out total);

        //    return Pager.Paging(list, total);
        //}
    }
}
