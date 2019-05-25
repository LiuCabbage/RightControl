using RightControl.Common;
using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IRepository
{
    public interface IActionRepository : IBaseRepository<ActionModel>
    {
        IEnumerable<ActionModel> GetActionListByRoleId(int roleId, int menuId, out IEnumerable<ActionModel> selectList);
        IEnumerable<ActionModel> GetActionListByMenuId(int menuId);
        IEnumerable<ActionModel> GetActionListByMenuIdRoleId(int menuId, int roleId, PositionEnum position);
    }
}
