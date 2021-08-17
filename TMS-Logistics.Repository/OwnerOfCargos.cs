using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
using TMS_Logistics.IRepository;
using Dapper;
namespace TMS_Logistics.Repository
{
    /// <summary>
    /// 货主管理
    /// </summary>
    public class OwnerOfCargos : Base<OwnerOfCargo>, IOwnerOfCargos
    {
        public int OwnerOfCargoAdd(OwnerOfCargo obj)
        {
            string sql = $"insert into OwnerOfCargo values('{obj.DrivingLicenceTime}',{obj.DrivingLicenceImg},'{obj.Remark}')";

            return Efec(sql);
        }

        public int OwnerOfCargoDel(string OwnerOfCargoID)
        {
            string sql = $"delect * from OwnerOfCargo where OwnerOfCargoID in({OwnerOfCargoID.Trim(',')})";

            return Efec(sql, OwnerOfCargoID);
        }

        public OwnerOfCargo OwnerOfCargoDetails(int OwnerOfCargoID)
        {
            string sql = $"select a.OwnerOfCargoID,b.EmployeeName,b.EmployeePhone,d.OutsourcingUnitName,d.OutsourcingUnitPlace,a.DrivingLicenceTime,a.DrivingLicenceImg,a.Remark,d.OutsourcingUnitCreateTime from OwnerOfCargo a join EmployeeModel b on a.OwnerOfCargoID = b.EmployeeID join RegistrationModel c on a.OwnerOfCargoID = c.RegistrationID join OutsourcingUnit d on a.OwnerOfCargoID = d.OutsourcingUnitID where OwnerOfCargoID={OwnerOfCargoID}";

            return Backfill(sql, OwnerOfCargoID);
        }

        public List<OwnerOfCargo> OwnerOfCargoList(string EmployeeName, string EmployeePhone,DateTime? DrivingLicenceTime)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("EmployeeName", EmployeeName);
            parameters.Add("EmployeePhone", EmployeePhone);
            parameters.Add("DrivingLicenceTime", DrivingLicenceTime);

            string sql = $"select a.OwnerOfCargoID,b.EmployeeName,b.EmployeePhone,d.OutsourcingUnitName,d.OutsourcingUnitPlace,a.DrivingLicenceTime,a.DrivingLicenceImg,a.Remark,d.OutsourcingUnitCreateTime from OwnerOfCargo a join EmployeeModel b on a.OwnerOfCargoID = b.EmployeeID join RegistrationModel c on a.OwnerOfCargoID = c.RegistrationID join OutsourcingUnit d on a.OwnerOfCargoID = d.OutsourcingUnitID where EmployeeName like concat('%',@EmployeeName,'%') and EmployeePhone like concat('%',@EmployeePhone,'%') and DrivingLicenceTime like concat('%',@DrivingLicenceTime,'%')";

            return GetList(sql,parameters);
        }

        public int OwnerOfCargoUpd(OwnerOfCargo obj)
        {
            string sql = $"update OwnerOfCargo DrivingLicenceTime='{obj.DrivingLicenceTime}',DrivingLicenceImg='{obj.DrivingLicenceImg}',Remark='{obj.Remark}' where OwnerOfCargoID={obj.OwnerOfCargoID}";

            return Efec(sql);
        }
    }
}
