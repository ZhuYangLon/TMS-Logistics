using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 通用合同审批
    /// </summary>
    public class CommonContractExamine
    {
        public int CommonContractExamineID { get; set; }              //通用合同审批ID
        public Nullable<int> CommonContractID { get; set; }           //通用合同外键ID
        public Nullable<int> ExamineID { get; set; }                  //审批表外键ID
        public Nullable<int> CommonContractExamineStatus { get; set; }//通用合同审批状态
    }
}


