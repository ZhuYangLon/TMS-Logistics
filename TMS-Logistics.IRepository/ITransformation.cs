using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 转正办理
    /// </summary>
    public interface ITransformation:IBase<Transformation_V>
    {
        List<Transformation_V> TransformationsList(string EmployeeName, string DepartmentName, string PositionName, string EmployeeEntryTime, string EmployeeProposerTime, string ExamineStatus);
    }
}
