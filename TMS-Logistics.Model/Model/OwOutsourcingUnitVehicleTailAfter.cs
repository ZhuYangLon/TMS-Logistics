using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 承运合同跟踪表
    /// </summary>
    public class OwOutsourcingUnitVehicleTailAfter
    {
        public int VehicleTailAfterID { get; set; }//跟踪管理ID
        public Nullable<int> AcceptContractID { get; set; }       //外协合同外键ID
        public Nullable<int> CircuitAdministrationID { get; set; }//线路管理外键ID
        public Nullable<int> AbnormalAlarm { get; set; }          //异常警报
        public Nullable<int> OwnerOfCargoRunStatus { get; set; }  //运输状态（运输中、未起运、已完成）
        public Nullable<int> VehicleTailAfterStatus { get; set; } //跟踪状态
    }
}


