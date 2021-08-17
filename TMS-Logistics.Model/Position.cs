using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 职位管理
    /// </summary>
    public class Position
    {
        public int PositionID { get; set; } //职位管理ID
        public string PositionName { get; set; }//职位名称
        public string AnotherName { get; set; }//别名
        public string SuoDepartment { get; set; }//所属部门
        public Nullable<System.DateTime> CreateTime { get; set; } //创建时间
    }
}


