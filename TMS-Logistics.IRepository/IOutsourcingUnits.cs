using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 外协单位管理
    /// </summary>
    public interface IOutsourcingUnits:IBase<OutsourcingUnit>
    {
        List<OutsourcingUnit> OutsourcingUnitsList(string OutsourcingUnitName, string OutsourcingUnitTelephone);

        int OutsourcingUnitsAdd(OutsourcingUnit obj);

        int OutsourcingUnitsDel(string OutsourcingUnitID);

        int OutsourcingUnitsUpd(OutsourcingUnit obj);

        OutsourcingUnit OutsourcingUnitsDetails(int OutsourcingUnitID);
    }
}
