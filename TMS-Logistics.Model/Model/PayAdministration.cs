using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 应付费管理表
    /// </summary>
    public class PayAdministration
    {
        public int PayAdministrationID { get; set; }//应收费用管理ID
        public string ProfessionalNo { get; set; }                     //业务单号
        public string ChargeOwnerOfCargoUnit { get; set; }             //外协单位
        public string PayType { get; set; }                            //支付方式(1:微信支付2：支付宝支付3：银联支付4：企业转账5：线下支付6：其他)                                              / /
        public Nullable<int> Tonnage { get; set; }                     //吨位(立方米)
        public Nullable<decimal> Price { get; set; }                   //单价(元/立方米)
        public Nullable<System.DateTime> ProfessionalTime
        {
            get; set;
        }  //业务日期
        public string CircuitResponsibleName { get; set; }             //经办人
        public Nullable<System.DateTime> CreateTime { get; set; }      //创建时间
        public string Remark { get; set; }                             //备注
        public string CheckType { get; set; }                          //核对状态
        public string CheckName { get; set; }                          //核对人
        public Nullable<int> PayAdministrationStatus { get; set; }     //状态
    }
}


