using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.IRepository;
using TMS_Logistics.Model;
using Dapper;
namespace TMS_Logistics.Repository
{
    /// <summary>
    /// 线路管理
    /// </summary>
    public class CircuitAdmins : Base<CircuitAdministration_V>, ICircuitAdmin
    {
        public int CircuitAdministrationsAdd(CircuitAdministration_V obj)
        {
            string sql = $"insert into CircuitAdministration_V values('{obj.CircuitName}','{obj.CircuitStartPlace}','{obj.CircuitEndPlace}','{obj.IsOutsource}','{obj.EmployeeName}','{obj.EmployeePhone}','{obj.OutsourcingUnitName}','{obj.Remark}','{obj.CreateTime}','{obj.CircuitStatus}')";

            return Efec(sql);
        }

        public int CircuitAdministrationsDel(string CircuitAdministrationID)
        {
            string sql = $"delete from CircuitAdministration_V where CircuitAdministrationID in({CircuitAdministrationID.Trim(',')})";

            return Efec(sql, CircuitAdministrationID);
        }

        public CircuitAdministration_V CircuitAdministrationsDetails(int CircuitAdministrationID)
        {
            string sql = $"select * from CircuitAdministration_V where CircuitAdministrationID={CircuitAdministrationID}";

            return Backfill(sql, CircuitAdministrationID);
        }

        public List<CircuitAdministration_V> CircuitAdministrationsList(string CircuitName, string CircuitStartPlace, string CircuitEndPlace, string IsOutsource, string EmployeePhone, string OutsourcingUnitName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CircuitName", CircuitName);
            parameters.Add("CircuitStartPlace", CircuitStartPlace);
            parameters.Add("CircuitEndPlace", CircuitEndPlace);
            parameters.Add("IsOutsource", IsOutsource);
            parameters.Add("EmployeePhone", EmployeePhone);
            parameters.Add("OutsourcingUnitName", OutsourcingUnitName);

            string sql = $"select a.CircuitAdministrationID,a.CircuitName,a.CircuitStartPlace,a.CircuitEndPlace,a.IsOutsource,b.EmployeeName,b.EmployeePhone,c.OutsourcingUnitName,a.Remark,a.CreateTime,a.CircuitStatus   from CircuitAdministration a join EmployeeModel b on a.CircuitAdministrationID = b.EmployeeID join OutsourcingUnit c on a.CircuitAdministrationID = c.OutsourcingUnitID where CircuitName like concat('%',@CircuitName,'%') and CircuitStartPlace like concat('%',@CircuitStartPlace,'%') and CircuitEndPlace like concat('%',@CircuitEndPlace,'%') and IsOutsource like concat('%',@IsOutsource,'%') and EmployeePhone like concat('%',@EmployeePhone,'%') and OutsourcingUnitName like concat('%',@OutsourcingUnitName,'%')";


            return GetList(sql, parameters);
        }

        public int CircuitAdministrationsUpd(CircuitAdministration_V obj)
        {
            string sql = $"update CircuitAdministration_V set   CircuitName='{obj.CircuitName}',CircuitStartPlace='{obj.CircuitStartPlace}',CircuitEndPlace='{obj.CircuitEndPlace}',IsOutsource='{obj.IsOutsource}',EmployeeName='{obj.EmployeeName}',EmployeePhone='{obj.EmployeePhone}',OutsourcingUnitName='{obj.OutsourcingUnitName}',Remark='{obj.Remark}',CreateTime='{obj.CreateTime}',CircuitStatus='{obj.CircuitStatus}'  where CircuitAdministrationID={obj.CircuitAdministrationID}";

            return Efec(sql);
        }
    }
}
