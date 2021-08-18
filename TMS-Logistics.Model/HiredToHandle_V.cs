using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 入职办理表
    /// </summary>
   public class HiredToHandle_V
    {
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string EmployeeParentName { get; set; }
        public DateTime EmployeeEntryTime { get; set; }
        public DateTime DepartmentCreateTime { get; set; }
        public string ExamineStatus { get; set; }
        public string ExamineName { get; set; }
        
    }
}
