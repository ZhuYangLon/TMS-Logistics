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
    /// 外协单位
    /// </summary>
    public class OutsourcingUnits : Base<OutsourcingUnit>, IOutsourcingUnits
    {
        public int OutsourcingUnitsAdd(OutsourcingUnit obj)
        {
            string sql = $"insert into OutsourcingUnit values('{obj.OutsourcingUnitName}','{obj.OutsourcingUnitEmail}','{obj.OutsourcingUnitTelephone}','{obj.OutsourcingUnitPlace}','{obj.OutsourcingUnitResponsibleName}','{obj.OutsourcingUnitCreateTime}')";

            return Efec(sql);
        }

        public int OutsourcingUnitsDel(string OutsourcingUnitID)
        {
            string sql = $"delect * from OutsourcingUnit where OutsourcingUnitID in({OutsourcingUnitID.Trim(',')})";

            return Efec(sql, OutsourcingUnitID);
        }

        public OutsourcingUnit OutsourcingUnitsDetails(int OutsourcingUnitID)
        {
            string sql = $"select * from OutsourcingUnit where OutsourcingUnitID={OutsourcingUnitID}";

            return Backfill(sql, OutsourcingUnitID);
        }

        public List<OutsourcingUnit> OutsourcingUnitsList(string OutsourcingUnitName, string OutsourcingUnitTelephone)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("OutsourcingUnitName", OutsourcingUnitName);
            parameters.Add("OutsourcingUnitTelephone", OutsourcingUnitTelephone);

            string sql = $"select * from OutsourcingUnit where OutsourcingUnitName like concat('%',@OutsourcingUnitName,'%') and OutsourcingUnitTelephone like concat('%',@OutsourcingUnitTelephone,'%')";


            return GetList(sql, parameters);
        }

        public int OutsourcingUnitsUpd(OutsourcingUnit obj)
        {
            string sql = $"update OutsourcingUnit set   OutsourcingUnitName='{obj.OutsourcingUnitName}',OutsourcingUnitEmail='{obj.OutsourcingUnitEmail}',OutsourcingUnitTelephone='{obj.OutsourcingUnitTelephone}',OutsourcingUnitPlace='{obj.OutsourcingUnitPlace}',OutsourcingUnitResponsibleName='{obj.OutsourcingUnitResponsibleName}',OutsourcingUnitCreateTime='{obj.OutsourcingUnitCreateTime}'  where OutsourcingUnitID={obj.OutsourcingUnitID}";

            return Efec(sql);
        }
    }
}
