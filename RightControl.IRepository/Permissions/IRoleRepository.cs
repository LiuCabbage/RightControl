using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IRepository
{
    public interface IRoleRepository : IBaseRepository<RoleModel>
    {
        IEnumerable<RoleModel> GetRoleList();
    }
}
