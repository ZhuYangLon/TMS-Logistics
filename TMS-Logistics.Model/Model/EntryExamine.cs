using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 入职审批
    /// </summary>
    public class EntryExamine
    {
        public int EntryExamineID { get; set; }            //入职审批ID
        public Nullable<int> EmployeeID { get; set; }      //员工表外键ID
        public Nullable<int> DepartmentID { get; set; }    //部门表外键ID
        public Nullable<int> PositionID { get; set; }      //职位表外键ID
        public Nullable<int> ExamineID { get; set; }       //审批表外键ID
        public Nullable<int> EntryExamineStatus { get; set; }// 入职审批状态 }
    }
}


