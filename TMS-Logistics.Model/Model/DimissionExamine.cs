using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 离职审批联查
    /// </summary>
    public class DimissionExamine
    {
        public int DimissionExamineID { get; set; } //离职审批ID
        public Nullable<int> EmployeeID { get; set; } //员工表外键ID
        public Nullable<int> DepartmentID { get; set; }//部门表外键ID
        public Nullable<int> PositionID { get; set; }  //职位表外键ID
        public Nullable<int> ExamineID { get; set; }  //审批表ID
        public Nullable<int> DimissionStatus { get; set; } //离职审批状态
    }
}


