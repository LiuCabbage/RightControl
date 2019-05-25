namespace RightControl.Model
{
    public class PassWordModel
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string Repassword { get; set; }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }
    }
}
