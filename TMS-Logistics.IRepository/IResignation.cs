using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 离职办理
    /// </summary>
    public interface IResignation:IBase<Resignation_V>
    {
        List<Resignation_V> ResignationsList(string EmployeeName, string DepartmentName, string PositionName, string EmployeeEntryTime, string EmployeeEndWorkTime, string ExamineStatus);
    }
}
