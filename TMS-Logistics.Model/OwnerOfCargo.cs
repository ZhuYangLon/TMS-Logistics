using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 基础信息—货主管理表
    /// </summary>
    public class OwnerOfCargo
    {
        public int OwnerOfCargoID { get; set; }
        public Nullable<System.DateTime> DrivingLicenceTime { get; set; }
        public string DrivingLicenceImg { get; set; }
        public string Remark { get; set; }
    }
}


