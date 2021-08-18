using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 物资采购
    /// </summary>
    public partial class GoodsAndMaterials
    {
        public int GoodsAndMaterialsID { get; set; }//物资采购ID
        public string GoodsAndMaterialsName { get; set; }          //货物名称
        public Nullable<int> TypeID { get; set; }                  //类别外键
        public Nullable<int> TextureID { get; set; }               //材质外键
        public string Specification { get; set; }                  //规格
        public string PlaceOfOrigin { get; set; }                  //产地
        public Nullable<int> GoodsNumber { get; set; }             //数量
        public string GoodsContent { get; set; }                   //用途描述
        public string Proposer { get; set; }                       //申请人
        public Nullable<System.DateTime> WashPayTime { get; set; } //期望交付日期
        public string Remark { get; set; }                         //备注
        public Nullable<System.DateTime> CreateTime { get; set; }  //创建时间
        public Nullable<int> CommonContractStatus { get; set; }    //审核状态
        public string CommonContractName { get; set; }             //审核人
        public Nullable<int> GoodsStatus { get; set; }             //物资状态
    }
}


