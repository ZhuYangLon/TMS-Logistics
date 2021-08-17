using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 车辆管理
    /// </summary>
    public interface IRegistration:IBase<RegistrationModel>
    {
        
        List<RegistrationModel> RegistrationList(string FactoryPlateModel, string LicensePlateNumber,string LicensePlateName,string SubordinateCompanies);

        int RegistrationAdd(RegistrationModel obj);

        int RegistrationDel(string RegistrationID);
    }
}
