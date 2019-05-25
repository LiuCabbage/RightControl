using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightControl.Common
{
    public class OperatorModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string UserPwd { get; set; }
        public int RoleId { get; set; }
        public string LoginIPAddress { get; set; }
        public string LoginIPAddressName { get; set; }
        public string LoginToken { get; set; }
        public DateTime LoginTime { get; set; }
        public bool IsSystem { get; set; }
        public string HeadShot { get; set; }
    }
}
