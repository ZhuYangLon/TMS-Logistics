using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 违章记录管理表
    /// </summary>
    public class BreakRulesRecord
    {
        public int BreakRulesID { get; set; }                        //保养ID
        public string BreakRulesTitle { get; set; }                  //保养标题
        public string LicensePlateNumber { get; set; }               //车牌号
        public string BreakRulesContent { get; set; }                //违章内容
        public string BreakRulesResult { get; set; }                 //处罚结果 
        public string BreakRulesName { get; set; }                   //违章人
        public Nullable<System.DateTime> BreakRulesTime { get; set; }//违章日期
        public string Remark { get; set; }                           //备注
        public Nullable<System.DateTime> CreateTime { get; set; }    //创建时间
        public Nullable<int> BreakRulesStatus { get; set; }         //违章状态
    }
}


