using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RightControl.Model;

namespace RightControl.IService
{
    public interface ILogService:IBaseService<LogModel>
    {
        bool WriteDbLog(LogModel model);
    }
}
