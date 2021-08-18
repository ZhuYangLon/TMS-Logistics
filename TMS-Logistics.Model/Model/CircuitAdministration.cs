using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 线路管理表
    /// </summary>
    public class CircuitAdministration
    {
        public int CircuitAdministrationID { get; set; } //线路ID
        public string CircuitName { get; set; }        //线路名称
        public string CircuitStartPlace { get; set; }  //起点
        public string CircuitEndPlace { get; set; }    //终点
        public string IsOutsource { get; set; }        //是否外协
        public string Remark { get; set; }                        //备注
        public Nullable<System.DateTime> CreateTime { get; set; } //创建时间
        public Nullable<int> CircuitStatus { get; set; }  //状态（1：开启2：禁用）
    }
}


