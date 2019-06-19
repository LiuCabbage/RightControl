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
        /// <summary>
        /// 删除按钮时,同时删除t_menu_action和t_menu_role_action记录
        /// </summary>
        /// <param name="actionId"></param>
        /// <returns></returns>
        bool DeleteActionAllByActionId(int actionId);
    }
}
