using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class RoleModel
    {
        public int RoleID { get; set; } //角色主键ID
        public string RoleName { get; set; }                         //角色名称
        public string RoleMsg { get; set; }                          //角色描述
        public Nullable<int> RoleStatus { get; set; }                //状态
        public string RoleCreateName { get; set; }                   //创建人
        public Nullable<System.DateTime> RoleCreateTime { get; set; }//创建时间
        public Nullable<int> RoleParentID { get; set; }              //角色上级ID
    }
}


