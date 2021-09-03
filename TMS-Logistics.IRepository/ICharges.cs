using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;

namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 应收费用管理
    /// </summary>
   public interface ICharges:IBase<Charge>
    {
        List<Charge> ChargesList(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, string ProfessionalTime);

        int ChargesAdd(Charge obj);

        int ChargesDel(string ChargeID);

        int ChargesUpd(Charge obj);

        Charge ChargesDetails(int ChargeID);
    }
}
