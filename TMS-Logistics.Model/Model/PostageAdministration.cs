using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 油费管理表
    /// </summary>
    public class PostageAdministration
    {
        public int PostageAdministrationID { get; set; }//油费ID
        public Nullable<int> ComeOnCost { get; set; }    //加油费用//元
        public Nullable<int> FuelCharge { get; set; }    //加油量/L
        public Nullable<int> StartKilometre { get; set; }//起始公里数
        public string PayType { get; set; }              //支付方式(1:微信支付2：支付宝支付3：银联支付4：企业转账5：线下支付6：其他)
        public string Remark { get; set; } //备注
        public Nullable<System.DateTime> CreateTime { get; set; }//创建时间
    }
}


