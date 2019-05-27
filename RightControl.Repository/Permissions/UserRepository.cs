using Dapper;
using RightControl.IRepository;
using RightControl.Model;
using System.Linq;

namespace RightControl.Repository
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        /// <summary>
        /// 用户详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserModel GetDetail(int Id)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "select u.*,r.RoleName from t_User u INNER JOIN t_role r on u.RoleId=r.Id AND u.Id=@Id";
                return conn.Query<UserModel>(sql, new { Id }).FirstOrDefault();
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public UserModel CheckLogin(string username, string password)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "Select Id,UserName,RealName,CreateOn,PassWord,Status,RoleId,HeadShot from t_User where 1=1 ";
                if (!string.IsNullOrEmpty(username))
                {
                    sql += " and UserName=@UserName";
                }
                if (!string.IsNullOrEmpty(password))
                {
                    sql += " and PassWord=@PassWord";
                }
                return conn.Query<UserModel>(sql, new { UserName = username, PassWord = password }).FirstOrDefault();
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">密码实体</param>
        /// <returns></returns>
        public int ModifyPwd(PassWordModel model)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "update t_User set PassWord=@Password where UserName=@UserName and Password=@OldPassword";
                return conn.Execute(sql, model);
            }
        }

    }
}
