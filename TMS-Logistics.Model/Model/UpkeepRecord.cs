using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 保养记录表
    /// </summary>
    public class UpkeepRecord
    {
        public int UpkeepRecordID { get; set; }//保养ID
        public string UpkeepRecordTitle { get; set; }                    //保养标题
        public string LicensePlateNumber { get; set; }                   //车牌号
        public Nullable<decimal> UpkeepRecordPrice { get; set; }         //保养金额
        public string UpkeepRecordName { get; set; }                     //保养负责人
        public Nullable<int> NowMileage { get; set; }                    //当前里程数
        public Nullable<int> LastMileage { get; set; }                   //上次里程数
        public string UpkeepRecordContent { get; set; }                  //保养项目
        public Nullable<System.DateTime> UpkeepRecordNowTime { get; set; } //保养日期
        public Nullable<System.DateTime> UpkeepRecordLastTime { get; set; }//上次保养日期}
        public string Remark { get; set; }                               //备注
        public Nullable<System.DateTime> CreateTime { get; set; }        //创建时间
        public Nullable<int> UpkeepRecordStatus { get; set; }            //保养状态
    }
}


