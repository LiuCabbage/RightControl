using RightControl.Common;
using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IService
{
    public interface IActionService : IBaseService<ActionModel>
    {
        string GetActionListHtmlByRoleId(int roleId, int menuId);
        IEnumerable<ActionModel> GetActionListByMenuId(int menuId);
        IEnumerable<ActionModel> GetActionListByMenuIdRoleId(int menuId, int roleId, PositionEnum position);
    }
}
