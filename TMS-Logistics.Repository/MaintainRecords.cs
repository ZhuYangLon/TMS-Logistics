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
    /// 维护记录
    /// </summary>
    public class MaintainRecords : Base<MaintainRecord>, IMaintainRecord
    {
        public int MaintainRecordsAdd(MaintainRecord obj)
        {
            string sql = $"insert into MaintainRecord values('{obj.MaintainRecordTitle}','{obj.MaintainRecordType}','{obj.LicensePlateNumber}',{obj.MaintainRecordPrice},'{obj.MaintainRecordName}','{obj.MaintainRecordContent}','{obj.MaintainRecordTime}','{obj.Remark}','{obj.CreateTime}',{obj.MaintainRecordStatus})";

            return Efec(sql);
        }

        public int MaintainRecordsDel(string MaintainRecordID)
        {
            string sql = $"delete from MaintainRecord where MaintainRecordID in({MaintainRecordID.Trim(',')})";

            return Efec(sql, MaintainRecordID);
        }

        public MaintainRecord MaintainRecordsDetails(int MaintainRecordID)
        {
            string sql = $"select * from MaintainRecord where MaintainRecordID={MaintainRecordID}";

            return Backfill(sql, MaintainRecordID);
        }

        public List<MaintainRecord> MaintainRecordsList(string MaintainRecordName, string MaintainRecordTime, string LicensePlateNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("MaintainRecordName", MaintainRecordName);
            parameters.Add("MaintainRecordTime", MaintainRecordTime);
            parameters.Add("LicensePlateNumber", LicensePlateNumber);

            string sql = $"select * from MaintainRecord where MaintainRecordName like concat('%',@MaintainRecordName,'%') and MaintainRecordTime like concat('%',@MaintainRecordTime,'%' ) and LicensePlateNumber like concat('%',@LicensePlateNumber,'%')";

            return GetList(sql, parameters);
        }

        public int MaintainRecordsUpd(MaintainRecord obj)
        {
            string sql = $"update MaintainRecord set   MaintainRecordTitle='{obj.MaintainRecordTitle}',MaintainRecordType='{obj.MaintainRecordType}',LicensePlateNumber='{obj.LicensePlateNumber}',MaintainRecordPrice='{obj.MaintainRecordPrice}',MaintainRecordName='{obj.MaintainRecordName}',MaintainRecordContent='{obj.MaintainRecordContent}',MaintainRecordTime='{obj.MaintainRecordTime}',Remark='{obj.Remark}',CreateTime='{obj.CreateTime}',MaintainRecordStatus='{obj.MaintainRecordStatus}'  where MaintainRecordID={obj.MaintainRecordID}";

            return Efec(sql);
        }
    }
}
