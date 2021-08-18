using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 部门管理
    /// </summary>
    public partial class DepartmentType
    {
        public int DepartmentTypeID { get; set; } //部门分类ID
        public string DepartmentTypeName { get; set; }//部门分类名称
    }
}


