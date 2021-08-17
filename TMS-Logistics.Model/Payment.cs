using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 付款管理
    /// </summary>
    public class Payment
    {
        public int PaymentID { get; set; }//付款管理ID
        public string PaymentTitle { get; set; }                  //标题
        public string PaymentContent { get; set; }                //用途描述
        public Nullable<int> PayPrice { get; set; }               //付款金额
        public string PayType { get; set; }                       //付款方式
        public string PayName { get; set; }                       //支付对象
        public string OpeningBank { get; set; }                   //开户行
        public string BankCard { get; set; }                      //银行账号
        public string Proposer { get; set; }                      //申请人
        public Nullable<System.DateTime> PayTime { get; set; }    //付款日期
        public string Remark { get; set; }                        //备注
        public Nullable<System.DateTime> CreateTime { get; set; } //创建时间
        public Nullable<int> CommonContractStatus { get; set; }   //审核状态
        public string CommonContractName { get; set; }            //审核人
        public Nullable<int> PaymentStatus { get; set; }          //付款状态
    }
}


