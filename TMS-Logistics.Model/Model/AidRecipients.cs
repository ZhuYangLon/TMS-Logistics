using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 物资领用审批
    /// </summary>
    public class AidRecipients
    {
        public int AidRecipientsID { get; set; }                        //物资领用id
        public string AidRecipientsTitle { get; set; }                  //标题
        public string AidRecipientsContent { get; set; }                //用途描述
        public string Proposer { get; set; }                            //领用人
        public Nullable<System.DateTime> ProposerTime { get; set; }     //领用日期
        public Nullable<int> ProposerNum { get; set; }                  //领用数量
        public string Remark { get; set; }                              //备注
        public Nullable<System.DateTime> CreateTime { get; set; }       //创建时间
        public Nullable<int> CommonContractStatus { get; set; }         //审核状态
        public string CommonContractName { get; set; }                  //审核人
        public Nullable<int> AidRecipientsStatus { get; set; }          //物资领用状态

    }
}


