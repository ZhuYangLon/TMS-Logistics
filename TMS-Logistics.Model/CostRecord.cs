using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 费用记录
    /// </summary>
    public class CostRecord
    {
        public int CostID { get; set; }                           //费用ID
        public string CostTitle { get; set; }                     //费用标题
        public string CostType { get; set; }                      //费用类型
        public string LicensePlateNumber { get; set; }            //车牌号
        public Nullable<decimal> CostPrice { get; set; }          //金额
        public string CostName { get; set; }                      //负责人
        public string CostContent { get; set; }                   //描述
        public Nullable<System.DateTime> UseTime { get; set; }    //使用时间
        public string Remark { get; set; }                        //备注
        public Nullable<System.DateTime> CreateTime { get; set; } //创建时间
        public Nullable<int> AccidentStatus { get; set; }         //使用状态
    }
}


