using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 线路管理视图
    /// </summary>
   public class CircuitAdministration_V
    {
        public int CircuitAdministrationID { get; set; }
        public string CircuitName { get; set; }
        public string CircuitStartPlace { get; set; }
        public string CircuitEndPlace { get; set; }
        public string IsOutsource { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string OutsourcingUnitName { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public string CircuitStatus { get; set; }
    }
}
