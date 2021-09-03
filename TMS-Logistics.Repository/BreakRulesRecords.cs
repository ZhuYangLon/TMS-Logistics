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
    /// 违章记录
    /// </summary>
    public class BreakRulesRecords:Base<BreakRulesRecord>,IBreakRulesRecord
    {
        public int BreakRulesAdd(BreakRulesRecord obj)
        {
            string sql = $"insert into BreakRulesRecord values('{obj.BreakRulesTitle}','{obj.LicensePlateNumber}','{obj.BreakRulesContent}','{obj.BreakRulesResult}','{obj.BreakRulesName}','{obj.BreakRulesTime}','{obj.Remark}','{obj.CreateTime}','{obj.BreakRulesStatus}')";

            return Efec(sql);
        }

        public int BreakRulesDel(string BreakRulesID)
        {
            string sql = $"delete from BreakRulesRecord where BreakRulesID in({BreakRulesID.Trim(',')})";

            return Efec(sql, BreakRulesID);
        }

        public BreakRulesRecord BreakRulesDetails(int BreakRulesID)
        {
            string sql = $"select * from BreakRulesRecord where BreakRulesID={BreakRulesID}";

            return Backfill(sql, BreakRulesID);
        }

        public List<BreakRulesRecord> BreakRulesList(string BreakRulesTitle, string LicensePlateNumber, string BreakRulesTime)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("BreakRulesTitle", BreakRulesTitle);
            parameters.Add("LicensePlateNumber", LicensePlateNumber);
            parameters.Add("BreakRulesTime", BreakRulesTime);

            string sql = $"select * from BreakRulesRecord where BreakRulesTitle like concat('%',@BreakRulesTitle,'%') and LicensePlateNumber like concat('%',@LicensePlateNumber,'%') and BreakRulesTime like concat('%',@BreakRulesTime,'%')";


            return GetList(sql, parameters);
        }

        public int BreakRulesUpd(BreakRulesRecord obj)
        {
            string sql = $"update BreakRulesRecord set   BreakRulesTitle='{obj.BreakRulesTitle}',LicensePlateNumber='{obj.LicensePlateNumber}',BreakRulesContent='{obj.BreakRulesContent}',BreakRulesResult='{obj.BreakRulesResult}',BreakRulesName='{obj.BreakRulesName}',BreakRulesTime='{obj.BreakRulesTime}',Remark='{obj.Remark}',CreateTime='{obj.CreateTime}',BreakRulesStatus='{obj.BreakRulesStatus}' where BreakRulesID={obj.BreakRulesID}";

            return Efec(sql);
        }
    }
}
