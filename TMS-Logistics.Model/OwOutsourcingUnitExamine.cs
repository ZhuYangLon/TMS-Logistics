using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 外协(承运)合同审批
    /// </summary>
    public class OwOutsourcingUnitExamine
    {
        public int OwOutsourcingUnitExamineID { get; set; }              //承运外协合同审批ID
        public Nullable<int> AcceptContractID { get; set; }              //承运外协合同外键ID
        public Nullable<int> ExamineID { get; set; }                     //审批表外键ID
        public Nullable<int> OwOutsourcingUnitExamineStatus { get; set; }//承运合同审批状态
    }
}


