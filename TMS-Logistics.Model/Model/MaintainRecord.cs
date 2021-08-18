using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 维修记录
    /// </summary>
    public class MaintainRecord
    {
        public int MaintainRecordID { get; set; }                         //维修ID
        public string MaintainRecordTitle { get; set; }                   //维修标题
        public string MaintainRecordType { get; set; }                    //维修类型
        public string LicensePlateNumber { get; set; }                    //车牌号
        public Nullable<decimal> MaintainRecordPrice { get; set; }        //维修金额
        public string MaintainRecordName { get; set; }                    //维修负责人
        public string MaintainRecordContent { get; set; }                 //维修描述
        public Nullable<System.DateTime> MaintainRecordTime { get; set; } //维修日期
        public string Remark { get; set; }                                //备注
        public Nullable<System.DateTime> CreateTime { get; set; }         //创建时间
        public Nullable<int> MaintainRecordStatus { get; set; }           //维修状态
    }
}


