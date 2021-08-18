using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class MenuModel
    {
        public int MenuID { get; set; }                 //菜单主键自增不为空
        public string MenuName { get; set; }            //菜单名称
        public Nullable<int> MenuParentID { get; set; } //上级ID
        public string MenuLink { get; set; }            //菜单路径
        public Nullable<int> MenuStatus { get; set; }   //状态
    }
}


