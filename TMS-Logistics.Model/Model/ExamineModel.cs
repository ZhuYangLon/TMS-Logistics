using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 审批表
    /// </summary>
    public class ExamineModel
    {
        public int ExamineID { get; set; } //审批ID
        public string ExamineName { get; set; }//审批人
        public Nullable<int> ExamineStatus { get; set; } //审批状态
    }
}


