using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleAdministration
    {
        public int RoleAdministrationID { get; set; }//角色管理ID
        public string RoleName { get; set; }                      //角色名称
        public Nullable<int> RoleAuthorizationID { get; set; }    //上级角色
        public string AnotherName { get; set; }                   //别名
        public Nullable<System.DateTime> CreateTime { get; set; } //创建时间
    }
}


