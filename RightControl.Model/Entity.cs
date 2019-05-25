using DapperExtensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace RightControl.Model
{
    public class Entity
    {
        [DapperExtensions.Key(true)]
        public virtual int Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "创建时间")]
        public DateTime CreateOn { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public virtual DateTime UpdateOn { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [Display(Name = "创建人")]
        public virtual int CreateBy { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [Display(Name = "修改人")]
        public virtual int UpdateBy { get; set; }
        /// <summary>
        /// 菜单状态(1：启用，0：禁用）
        /// </summary>
        [Display(Name = "状态")]
        public bool ?  Status { get; set; }
        #region 查询条件
        [Computed]
        public string StartEndDate { get; set; }
        #endregion
    }
}
