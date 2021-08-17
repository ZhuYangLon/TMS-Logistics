using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Logistics.Model
{
    /// <summary>
    /// 基础信息—车辆管理表
    /// </summary>
    public class RegistrationModel
    {
        public int RegistrationID { get; set; } //车辆管理ID
        public string FactoryPlateModel { get; set; }                     //厂牌型号
        public string LicensePlateNumber { get; set; }                    //车牌号
        public string LicensePlateName { get; set; }                      //司机
        public string LicensePlateLWH { get; set; }                       //车型(长*宽*高)
        public string LicensePlateColour { get; set; }                    //车型颜色
        public string RegistrationImg { get; set; }                       //车辆照片
        public string SubordinateCompanies { get; set; }                  //所属公司
        public Nullable<System.DateTime> BuyTime { get; set; }            //购置日期
        public string ServiceCertificateNumber { get; set; }              //营运证号
        public Nullable<System.DateTime> InsuranceExpireTime { get; set; }//保险到期时间
        public Nullable<System.DateTime> AnnualExpireTime { get; set; }   //年检到期时间
        public string MaintainKilometreSetting { get; set; }              //保养公里设置
        public string MaintainCardImg { get; set; }                       //保险卡照片
    }
}


