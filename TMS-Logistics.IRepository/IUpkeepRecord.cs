using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 保养记录
    /// </summary>
    public interface IUpkeepRecord:IBase<UpkeepRecord>
    {
        List<UpkeepRecord> UpkeepRecordsList(string UpkeepRecordName,string UpkeepRecordNowTime,string LicensePlateNumber);

        int UpkeepRecordsAdd(UpkeepRecord obj);

        int UpkeepRecordsDel(string UpkeepRecordID);

        int UpkeepRecordsUpd(UpkeepRecord obj);

        UpkeepRecord UpkeepRecordsDetails(int UpkeepRecordID);
    }
}
