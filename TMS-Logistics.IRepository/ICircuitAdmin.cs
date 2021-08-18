using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 线路管理
    /// </summary>
    public interface ICircuitAdmin:IBase<CircuitAdministration_V>
    {
        List<CircuitAdministration_V> CircuitAdministrationsList(string CircuitName, string CircuitStartPlace,string CircuitEndPlace,string IsOutsource,string EmployeePhone,string OutsourcingUnitName);

        int CircuitAdministrationsAdd(CircuitAdministration_V obj);

        int CircuitAdministrationsDel(string CircuitAdministrationID);

        int CircuitAdministrationsUpd(CircuitAdministration_V obj);

        CircuitAdministration_V CircuitAdministrationsDetails(int CircuitAdministrationID);
    }
}
