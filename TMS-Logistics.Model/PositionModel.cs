using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 职位表
    /// </summary>
    public class PositionModel
    {
        public int PositionID { get; set; }//职位主键自增不为空
        public string PositionName { get; set; }//职位名称
        public Nullable<int> PositionStatus { get; set; }//状态
    }
}


