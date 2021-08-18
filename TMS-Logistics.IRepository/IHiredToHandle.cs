using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 入职办理
    /// </summary>
    public interface IHiredToHandle:IBase<HiredToHandle_V>
    {
        List<HiredToHandle_V> HiredToHandlesList(string EmployeeName, string DepartmentName,string PositionName,string EmployeeEntryTime,string DepartmentCreateTime,string ExamineStatus);

    }
}
