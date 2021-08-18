using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 轮胎使用记录
    /// </summary>
    public class TyreUseRecord
    {
        public int TyreUseRecordID { get; set; }//使用ID
        public string LicensePlateNumber { get; set; }           //车牌号
        public string TyreType { get; set; }                     //轮胎品牌
        public string TyreSpecification { get; set; }            //规格
        public Nullable<int> Number { get; set; }                //数量
        public string UserName { get; set; }                     //使用人
        public Nullable<System.DateTime> UserTime { get; set; }  //使用日期
        public string Remark { get; set; }                       //备注
        public Nullable<System.DateTime> CreateTime { get; set; }//创建时间
        public Nullable<int> TyreUseStatus { get; set; }         //使用状态
    }
}


