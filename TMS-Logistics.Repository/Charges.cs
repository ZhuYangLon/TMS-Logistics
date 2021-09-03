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
    /// 应收费用管理
    /// </summary>
    public class Charges : Base<Charge>, ICharges
    {
        public int ChargesAdd(Charge obj)
        {
            string sql = $"insert into Charge values('{obj.ProfessionalNo}','{obj.ChargeOwnerOfCargoUnit}','{obj.PayType}','{obj.Tonnage}','{obj.Price}','{obj.ProfessionalTime}','{obj.CircuitResponsibleName}','{obj.CreateTime}','{obj.Remark}','{obj.CheckType}','{obj.CheckName}','{obj.ChargeStatus}')";

            return Efec(sql);
        }

        public int ChargesDel(string ChargeID)
        {
            string sql = $"delete from Charge where ChargeID in({ChargeID.Trim(',')})";

            return Efec(sql, ChargeID);
        }

        public Charge ChargesDetails(int ChargeID)
        {
            string sql = $"select * from Charge where ChargeID={ChargeID}";

            return Backfill(sql, ChargeID);
        }

        public List<Charge> ChargesList(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, string ProfessionalTime)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ChargeOwnerOfCargoUnit", ChargeOwnerOfCargoUnit);
            parameters.Add("PayType", PayType);
            parameters.Add("CheckType", CheckType);
            parameters.Add("CircuitResponsibleName", CircuitResponsibleName);
            parameters.Add("ProfessionalTime", ProfessionalTime);

            string sql = $"select * from Charge where ChargeOwnerOfCargoUnit like concat('%',@ChargeOwnerOfCargoUnit,'%') and PayType like concat('%',@PayType,'%') and CheckType like concat('%',@CheckType,'%') and CircuitResponsibleName like concat('%',@CircuitResponsibleName,'%') and ProfessionalTime like concat('%',@ProfessionalTime,'%')";


            return GetList(sql, parameters);
        }

        public int ChargesUpd(Charge obj)
        {
            string sql = $"update Charge set   ProfessionalNo='{obj.ProfessionalNo}',ChargeOwnerOfCargoUnit='{obj.ChargeOwnerOfCargoUnit}',PayType='{obj.PayType}',Tonnage='{obj.Tonnage}',Price='{obj.Price}',ProfessionalTime='{obj.ProfessionalTime}',CircuitResponsibleName='{obj.CircuitResponsibleName}',CreateTime='{obj.CreateTime}',Remark='{obj.Remark}',CheckType='{obj.CheckType}',CheckName='{obj.CheckName}',ChargeStatus='{obj.ChargeStatus}'  where ChargeID={obj.ChargeID}";

            return Efec(sql);
        }
    }
}
