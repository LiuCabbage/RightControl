using RightControl.Model;

namespace RightControl.IService
{
    public interface IUserService : IBaseService<UserModel>
    {
        UserModel GetDetail(int Id);
        UserModel CheckLogin(string username, string password);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">密码实体</param>
        /// <returns></returns>
        bool ModifyPwd(PassWordModel model);
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool InitPwd(UserModel model);
    }
}
