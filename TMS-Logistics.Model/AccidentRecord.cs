using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 事故记录表
    /// </summary>
    public class AccidentRecord
    {
        public int AccidentID { get; set; }                              //事故ID
        public string AccidentTitle { get; set; }                        //事故标题
        public string LicensePlateNumber { get; set; }                   //车牌号
        public string AccidentContent { get; set; }                      //事故描述
        public string AccidentInancialLoss { get; set; }                 //直接经济损失
        public Nullable<decimal> InsuranceCompanyIndemnity { get; set; } //保险公司赔偿
        public Nullable<int> CompanyNetLoss { get; set; }                //公司净损失
        public string AccidentName { get; set; }                         //事发人
        public Nullable<System.DateTime> AccidentTime { get; set; }      //事故日期
        public string Remark { get; set; }                               //备注
        public Nullable<System.DateTime> CreateTime { get; set; }        //创建时间
        public Nullable<int> AccidentStatus { get; set; }                //事故状态
    }
}



