using RightControl.Common;
using RightControl.IRepository;
using RightControl.IService;
using RightControl.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightControl.Service
{
    public class ActionService : BaseService<ActionModel>, IActionService
    {
        public IActionRepository repository { get; set; }
        public dynamic GetListByFilter(ActionModel filter, PageInfo pageInfo)
        {
            string _where = " where 1=1";
            if (!string.IsNullOrEmpty(filter.ActionName))
            {
                _where += " and ActionName=@ActionName";
            }
            if (filter.Status != null)
            {
                _where += " and Status=@Status";
            }
            return GetListByFilter(filter, pageInfo, _where);
        }
        public string GetActionListHtmlByRoleId(int roleId, int menuId)
        {
            IEnumerable<ActionModel> selectList = null;
            var allList = repository.GetActionListByRoleId(roleId, menuId, out selectList);
            StringBuilder sb = new StringBuilder();
            if (allList != null && allList.Count() > 0)
            {
                foreach (var a in allList)
                {
                    var checkedStr = selectList.FirstOrDefault(x => x.Id == a.Id) == null ? "" : "checked= ''";
                    sb.AppendFormat("<input name='cbx_{0}' lay-skin='primary' value='{1}' title='{2}' type='checkbox' {3}>", menuId, a.Id, a.ActionName, checkedStr);
                }
            }
            return sb.ToString();
        }
        public IEnumerable<ActionModel> GetActionListByMenuId(int menuId)
        {
            return repository.GetActionListByMenuId(menuId);
        }
        public IEnumerable<ActionModel> GetActionListByMenuIdRoleId(int menuId, int roleId, PositionEnum position)
        {
            return repository.GetActionListByMenuIdRoleId(menuId, roleId, position);
        }

        public bool DeleteActionAllByActionId(int actionId)
        {
            return repository.DeleteActionAllByActionId(actionId);
        }
    }
}
