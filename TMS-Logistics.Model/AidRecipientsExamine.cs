using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 受援者审查
    /// </summary>
    public class AidRecipientsExamine
    {
        public int AidRecipientsExamineID { get; set; }              //物资领用审批ID
        public Nullable<int> AidRecipientsID { get; set; }           //物资采购外键ID
        public Nullable<int> ExamineID { get; set; }                 //审批表外键ID
        public Nullable<int> AidRecipientsExamineStatus { get; set; }//物资领用审批状态
    }
}


