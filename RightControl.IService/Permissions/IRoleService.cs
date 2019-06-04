using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IService
{
    public interface IRoleService:IBaseService<RoleModel>
    {
        IEnumerable<RoleModel> GetRoleList();
    }
}
