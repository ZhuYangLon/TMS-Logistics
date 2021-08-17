using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    using System;
    using System.Collections.Generic;

    public class OwnerOfCargoContract
    {
        public int OwnerOfCargoContractID { get; set; }//合同ID
        public string OwnerOfCargoContractNo { get; set; }               //合同编号
        public string OwnerOfCargoContractTitle { get; set; }            //合同标题
        public string OwnerOfCargoContractUnit { get; set; }             //承运单位
        public string OwnerOfCargoContractName { get; set; }             //货主负责人
        public string CommonContractCircuit { get; set; }                //路线
        public Nullable<decimal> TonRunPrice { get; set; }               //吨运价
        public Nullable<int> CharteredBusConditionTonNum { get; set; }   //包车条件吨位
        public Nullable<int> CharteredBusPrice { get; set; }             //包车金额
        public Nullable<System.DateTime> DateOfSigningTime { get; set; } //签订日期
        public string OwnerOfCargoContractRemark { get; set; }           //合同标的或项目说明
        public string OwnerOfCargoContractPrice { get; set; }            //合同主要条款/变更条款
        public string OwnerOfCargoContractFile { get; set; }             //合同文本（附件）
        public string CircuitResponsibleName { get; set; }               //经办人
        public Nullable<System.DateTime> CreateTime { get; set; }        //创建时间
        public Nullable<int> CommonContractStatus { get; set; }          //审核状态
        public string CommonContractName { get; set; }                   //审核人
        public Nullable<int> OwnerOfCargoContractStatus { get; set; }    //状态
    }
}


