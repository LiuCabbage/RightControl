using DapperExtensions;
using System;

namespace RightControl.Model
{
    [Table("t_Log")]
    public class LogModel:Entity
    {
        /// <summary>
		/// LogType
        /// </summary>
        public string LogType { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// ModuleName
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// IPAddress
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// IPAddressName
        /// </summary>
        public string IPAddressName { get; set; }
        [Computed]
        public override DateTime UpdateOn { get; set; }
        [Computed]
        public override int UpdateBy { get; set; }
        [Computed]
        public override int CreateBy { get; set; }
    }
}
