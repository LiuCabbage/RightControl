using RightControl.Model;

namespace RightControl.IRepository
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel GetDetail(int Id);
        UserModel CheckLogin(string username, string password);
        int ModifyPwd(PassWordModel model);
    }
}
