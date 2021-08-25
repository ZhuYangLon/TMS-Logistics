using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 维修记录
    /// </summary>
    public interface IMaintainRecord:IBase<MaintainRecord>
    {
        List<MaintainRecord> MaintainRecordsList(string MaintainRecordName,string MaintainRecordTime,string LicensePlateNumber);

        int MaintainRecordsAdd(MaintainRecord obj);

        int MaintainRecordsDel(string MaintainRecordID);

        int MaintainRecordsUpd(MaintainRecord obj);

        MaintainRecord MaintainRecordsDetails(int MaintainRecordID);
    }
}
