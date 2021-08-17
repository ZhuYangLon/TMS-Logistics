using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 货主合同审批
    /// </summary>
    public class OwnerOfCargoExamine
    {
        public int OwnerOfCargoExamineID { get; set; }              //货主审批ID
        public Nullable<int> OwnerOfCargoContractID { get; set; }   //货主合同外键ID
        public Nullable<int> ExamineID { get; set; }                //审批表外键ID
        public Nullable<int> OwnerOfCargoExamineStatus { get; set; }//货主合同审批状态
    }
}


