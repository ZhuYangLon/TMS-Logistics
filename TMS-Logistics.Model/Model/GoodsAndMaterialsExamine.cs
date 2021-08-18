using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 物资采购审批
    /// </summary>
    public class GoodsAndMaterialsExamine
    {
        public int GoodsAndMaterialsExamineID { get; set; }               //物资采购审批ID
        public Nullable<int> GoodsAndMaterialsID { get; set; }            //物资采购外键ID
        public Nullable<int> TypeID { get; set; }                         //物资类别外键ID
        public Nullable<int> TextureID { get; set; }                      //物资材质外键ID
        public Nullable<int> ExamineID { get; set; }                      //审批表外键ID
        public Nullable<int> GoodsAndMaterialsExamineStatus { get; set; } //物资合同审批状态
    }
}


