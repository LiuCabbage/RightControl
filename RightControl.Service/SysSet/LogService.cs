using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RightControl.Model;
using RightControl.IService;
using RightControl.Common;

namespace RightControl.Service.SysSet
{
    public class LogService : BaseService<LogModel>, ILogService
    {
        public bool WriteDbLog(LogModel model)
        {
            model.Status = true;
            model.CreateOn = DateTime.Now;
            model.IPAddress = Net.Ip;
            model.IPAddressName = Net.GetLocation(model.IPAddress);
            return baseRepository.Create(model) > 0 ? true : false;
        }
        public dynamic GetListByFilter(LogModel filter, PageInfo pageInfo)
        {
            string _where = " where 1=1";
            if (!string.IsNullOrEmpty(filter.RealName))
            {
                _where += " and RealName=@RealName";
            }
            if (!string.IsNullOrEmpty(filter.UserName))
            {
                _where += " and UserName=@UserName";
            }
            _where = CreateWhereStr(filter, _where);
            return GetListByFilter(filter, pageInfo, _where);
        }
    }
}
