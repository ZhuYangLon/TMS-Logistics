using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 转正审批联查
    /// </summary>
    public class BecomeExamine
    {
        public int BecomeExamineID { get; set; }          //转正审批ID
        public Nullable<int> EmployeeID { get; set; }     //员工表外键ID
        public Nullable<int> DepartmentID { get; set; }   //部门表外键ID
        public Nullable<int> PositionID { get; set; }     //职位表外键ID
        public Nullable<int> ExamineID { get; set; }      //审批表外键ID
        public Nullable<int> BecomeStatus { get; set; }  // 转正审批状态
    }
}


