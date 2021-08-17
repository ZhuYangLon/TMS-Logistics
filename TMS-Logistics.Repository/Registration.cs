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
    /// 车辆管理
    /// </summary>
    public class Registration : Base<RegistrationModel>, IRegistration
    {
        public int RegistrationAdd(RegistrationModel obj)
        {
            string sql = $"insert into RegistrationModel values('{obj.FactoryPlateModel}','{obj.LicensePlateNumber}','{obj.LicensePlateName}','{obj.LicensePlateLWH}','{obj.LicensePlateColour}','{obj.RegistrationImg}','{obj.SubordinateCompanies}','{obj.BuyTime}','{obj.ServiceCertificateNumber}','{obj.InsuranceExpireTime}','{obj.AnnualExpireTime}','{obj.MaintainKilometreSetting}','{obj.MaintainCardImg}')";

            return Efec(sql);
        }

        public int RegistrationDel(string RegistrationID)
        {
            string sql = $"delete from RegistrationModel where RegistrationID in({RegistrationID.Trim(',')})";

            return Efec(sql, RegistrationID);
        }

        public List<RegistrationModel> RegistrationList(string FactoryPlateModel, string LicensePlateNumber, string LicensePlateName, string SubordinateCompanies)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("FactoryPlateModel", FactoryPlateModel);
            parameters.Add("LicensePlateNumber", LicensePlateNumber);
            parameters.Add("LicensePlateName", LicensePlateName);
            parameters.Add("SubordinateCompanies", SubordinateCompanies);

            string sql = "select RegistrationID,FactoryPlateModel,LicensePlateNumber,LicensePlateName,LicensePlateLWH,LicensePlateColour,RegistrationImg,SubordinateCompanies,BuyTime,ServiceCertificateNumber,InsuranceExpireTime,AnnualExpireTime,MaintainKilometreSetting,MaintainCardImg from RegistrationModel where FactoryPlateModel like concat('%',@FactoryPlateModel,'%') and LicensePlateNumber like concat('%',@LicensePlateNumber,'%') and LicensePlateName like concat('%',@LicensePlateName,'%') and SubordinateCompanies like concat('%',@SubordinateCompanies,'%')";

            return GetList(sql, parameters);
            
        }
    }
}
