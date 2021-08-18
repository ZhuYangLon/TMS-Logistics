using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class DepartmentModel
    {
        public int DepartmentID { get; set; }                               //部门主键自增不为空
        public string DepartmentName { get; set; }                          //部门名称
        public Nullable<int> DepartmentParentID { get; set; }               //上级ID
        public Nullable<System.DateTime> DepartmentCreateTime { get; set; } //部门创建时间
        public Nullable<int> DepartmentStatus { get; set; }                 //状态
    }
}


