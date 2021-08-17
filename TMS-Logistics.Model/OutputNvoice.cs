using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 销项发票管理
    /// </summary>
    public class OutputNvoice
    {
        public int OutputNvoiceeID { get; set; }//应收费用管理ID
        public string OutputNvoiceNo { get; set; }                //发票号
        public string OutputNvoiceName { get; set; }              //客户名称
        public string ReceiptsNvoiceType { get; set; }            //发票类型
        public Nullable<int> InvoicePrice { get; set; }           //发票金额
        public Nullable<double> TaxRate { get; set; }             //税率
        public Nullable<System.DateTime> InvoiceTime { get; set; }//开票日期
        public string Remark { get; set; }                        //备注
        public string PreparedBy { get; set; }                    //制单人
        public Nullable<System.DateTime> CreateTime { get; set; } //创建时间
        public Nullable<int> ReceiptsNvoiceStatus { get; set; }   //状态
    }
}


