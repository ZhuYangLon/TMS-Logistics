using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 货主管理
    /// </summary>
    public interface IOwnerOfCargos:IBase<OwnerOfCargo>
    {
        List<OwnerOfCargo> OwnerOfCargoList(string LicensePlateName,string EmployeePhone, DateTime? DrivingLicenceTime);

        int OwnerOfCargoAdd(OwnerOfCargo obj);

        int OwnerOfCargoDel(string OwnerOfCargoID);

        int OwnerOfCargoUpd(OwnerOfCargo obj);

        OwnerOfCargo OwnerOfCargoDetails(int OwnerOfCargoID);
    }
}
