using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 违章记录
    /// </summary>
    public interface IBreakRulesRecord:IBase<BreakRulesRecord>
    {
        List<BreakRulesRecord> BreakRulesList(string BreakRulesTitle,string LicensePlateNumber,string BreakRulesTime);

        int BreakRulesAdd(BreakRulesRecord obj);

        int BreakRulesDel(string BreakRulesID);

        int BreakRulesUpd(BreakRulesRecord obj);

        BreakRulesRecord BreakRulesDetails(int BreakRulesID);
    }
}
