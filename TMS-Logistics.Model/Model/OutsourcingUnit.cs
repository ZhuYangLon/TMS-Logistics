using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 外协单位表
    /// </summary>
    public class OutsourcingUnit
    {
        public int OutsourcingUnitID { get; set; }//外协单位主键ID
        public string OutsourcingUnitName { get; set; }                            //外协单位名称
        public string OutsourcingUnitEmail { get; set; }                           //外协单位邮箱
        public string OutsourcingUnitTelephone { get; set; }                       //外协单位固话
        public string OutsourcingUnitPlace { get; set; }                           //外协单位地址
        public string OutsourcingUnitResponsibleName { get; set; }                 //外协单位负责人
        public Nullable<System.DateTime> OutsourcingUnitCreateTime { get; set; }   //创建时间
    }
}


