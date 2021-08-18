using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.IRepository;
using TMS_Logistics.Model;
namespace TMS_Logistics.Repository
{
    /// <summary>
    /// 油费管理
    /// </summary>
    public class PostageAdministrations : Base<PostageAdministration>, IPostageAdministration
    {
        public int PostageAdministrationsAdd(PostageAdministration obj)
        {
            string sql = $"insert into PostageAdministration values('{obj.ComeOnCost}','{obj.FuelCharge}','{obj.StartKilometre}','{obj.PayType}','{obj.Remark}','{obj.CreateTime}')";

            return Efec(sql);
        }

        public int PostageAdministrationsDel(string PostageAdministrationID)
        {
            string sql = $"delete from PostageAdministration where PostageAdministrationID in({PostageAdministrationID.Trim(',')})";

            return Efec(sql, PostageAdministrationID);
        }

        public PostageAdministration PostageAdministrationsDetails(int PostageAdministrationID)
        {
            string sql = $"select * from PostageAdministration where PostageAdministrationID={PostageAdministrationID}";

            return Backfill(sql, PostageAdministrationID);
        }

        public List<PostageAdministration> PostageAdministrationsList(string LicensePlateNumber, string ExamineName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("LicensePlateNumber", LicensePlateNumber);
            parameters.Add("ExamineName", ExamineName);

            string sql = $"select b.LicensePlateNumber,a.ComeOnCost,a.FuelCharge,a.StartKilometre,a.PayType,c.ExamineName,a.Remark,a.StartKilometre from PostageAdministration a join RegistrationModel b on  a.PostageAdministrationID = b.RegistrationID join ExamineModel c on a.PostageAdministrationID = c.ExamineID where LicensePlateNumber like concat('%',@LicensePlateNumber,'%') and ExamineName like concat('%',@ExamineName,'%')";


            return GetList(sql, parameters);
        }

        public int PostageAdministrationsUpd(PostageAdministration obj)
        {
            string sql = $"update PostageAdministration set ComeOnCost='{obj.ComeOnCost}',FuelCharge='{obj.FuelCharge}',StartKilometre='{obj.StartKilometre}',PayType='{obj.PayType}',Remark='{obj.Remark}',CreateTime='{obj.CreateTime}'  where PostageAdministrationID={obj.PostageAdministrationID}";

            return Efec(sql);
        }
    }
}
