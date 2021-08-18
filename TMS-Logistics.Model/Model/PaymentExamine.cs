using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 付款审批
    /// </summary>
    public class PaymentExamine
    {
        public int PaymentExamineID { get; set; } //付款审批ID
        public Nullable<int> PaymentID { get; set; }//付款管理外键
        public Nullable<int> ExamineID { get; set; }//审批表外键ID
        public Nullable<int> PaymentExamineStatus { get; set; } //付款审批状态
    }
}


