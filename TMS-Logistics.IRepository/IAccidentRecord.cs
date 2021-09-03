using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;

namespace TMS_Logistics.IRepository
{
    public interface IAccidentRecord:IBase<AccidentRecord>
    {
        List<AccidentRecord> AccidentRecordsList(string AccidentRecordsTitle, string LicensePlateNumber, string AccidentRecordsTime);

        int AccidentRecordsAdd(AccidentRecord obj);

        int AccidentRecordsDel(string AccidentID);

        int AccidentRecordsUpd(AccidentRecord obj);

        AccidentRecord AccidentRecordsDetails(int AccidentID);
    }
}
