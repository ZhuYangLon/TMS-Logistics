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
    /// 保养记录
    /// </summary>
    public class UpkeepRecords : Base<UpkeepRecord>, IUpkeepRecord
    {
        public int UpkeepRecordsAdd(UpkeepRecord obj)
        {
            string sql = $"insert into UpkeepRecord values('{obj.UpkeepRecordTitle}','{obj.LicensePlateNumber}','{obj.UpkeepRecordPrice}','{obj.UpkeepRecordName}','{obj.NowMileage}','{obj.LastMileage}','{obj.UpkeepRecordContent}','{obj.UpkeepRecordNowTime}','{obj.UpkeepRecordLastTime}','{obj.Remark}','{obj.CreateTime}','{obj.UpkeepRecordStatus}')";

            return Efec(sql);
        }

        public int UpkeepRecordsDel(string UpkeepRecordID)
        {
            string sql = $"delete from UpkeepRecord where UpkeepRecordID in({UpkeepRecordID.Trim(',')})";

            return Efec(sql, UpkeepRecordID);
        }

        public UpkeepRecord UpkeepRecordsDetails(int UpkeepRecordID)
        {
            string sql = $"select * from UpkeepRecord where UpkeepRecordID={UpkeepRecordID}";

            return Backfill(sql, UpkeepRecordID);
        }

        public List<UpkeepRecord> UpkeepRecordsList(string UpkeepRecordName, string UpkeepRecordNowTime, string LicensePlateNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UpkeepRecordName", UpkeepRecordName);
            parameters.Add("UpkeepRecordNowTime", UpkeepRecordNowTime);
            parameters.Add("LicensePlateNumber", LicensePlateNumber);


            string sql = $"select * from UpkeepRecord where UpkeepRecordName like concat('%',@UpkeepRecordName,'%') and UpkeepRecordNowTime like concat('%',@UpkeepRecordNowTime,'%') and LicensePlateNumber like concat('%',@LicensePlateNumber,'%')";


            return GetList(sql, parameters);
        }

        public int UpkeepRecordsUpd(UpkeepRecord obj)
        {
            string sql = $"update UpkeepRecord set   UpkeepRecordTitle='{obj.UpkeepRecordTitle}',LicensePlateNumber='{obj.LicensePlateNumber}',UpkeepRecordPrice='{obj.UpkeepRecordPrice}',UpkeepRecordName='{obj.UpkeepRecordName}',NowMileage='{obj.NowMileage}',LastMileage='{obj.LastMileage}',UpkeepRecordContent='{obj.UpkeepRecordContent}',UpkeepRecordNowTime='{obj.UpkeepRecordNowTime}',UpkeepRecordLastTime='{obj.UpkeepRecordLastTime}',Remark='{obj.Remark}',CreateTime='{obj.CreateTime}',UpkeepRecordStatus='{obj.UpkeepRecordStatus}'  where UpkeepRecordID={obj.UpkeepRecordID}";

            return Efec(sql);
        }
    }
}
