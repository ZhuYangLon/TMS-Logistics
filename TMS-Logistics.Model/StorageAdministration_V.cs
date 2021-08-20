using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 入库管理
    /// </summary>
    public class StorageAdministration_V
    {
        public int StorageID { get; set; }//入库管理id
        public string StorageName { get; set; }                   //货物名称
        public string GoodsAndMaterialsTypeName { get; set; }     //类别外键
        public string TextureName { get; set; }                   //材质外键
        public string Specification { get; set; }                 //规格
        public string PlaceOfOrigin { get; set; }                 //产地
        public Nullable<int> StorageNumber { get; set; }          //数量
        public Nullable<decimal> StoragePrice { get; set; }       //单价
        public string PayType { get; set; }                       //支付方式
        public Nullable<decimal> PurchasePrice { get; set; }      //采购金额
        public string Proposer { get; set; }                      //登记人
        public string Remark { get; set; }                        //备注
        public Nullable<System.DateTime> CreateTime { get; set; } //创建时间
        public Nullable<int> GoodsStatus { get; set; }            //入库状态
    }
}
