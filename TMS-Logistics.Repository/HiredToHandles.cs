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
    /// 入职办理
    /// </summary>
    public class HiredToHandles : Base<HiredToHandle_V>, IHiredToHandle
    {
        public List<HiredToHandle_V> HiredToHandlesList(string EmployeeName, string DepartmentName, string PositionName, string EmployeeEntryTime, string DepartmentCreateTime, string ExamineStatus)
        {
            //防止sql注入
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("EmployeeName", EmployeeName);
            parameters.Add("DepartmentName", DepartmentName);
            parameters.Add("PositionName", PositionName);
            parameters.Add("EmployeeEntryTime", EmployeeEntryTime);
            parameters.Add("DepartmentCreateTime", DepartmentCreateTime);
            parameters.Add("ExamineStatus", ExamineStatus);

            string sql = $"select a.EmployeeName,b.DepartmentName,c.PositionName,a.EmployeeParentName,a.EmployeeEntryTime,b.DepartmentCreateTime,d.ExamineStatus,d.ExamineName from EmployeeModel a join DepartmentModel b on a.EmployeeID = b.DepartmentID join PositionModel c on a.EmployeeID = c.PositionID join ExamineModel d on a.EmployeeID = d.ExamineID join UserModel e on a.EmployeeID = e.UserID where EmployeeName like concat('%',@EmployeeName,'%') and DepartmentName like concat('%',@DepartmentName,'%') and PositionName like concat('%',@PositionName,'%') and EmployeeEntryTime like concat('%',@EmployeeEntryTime,'%') and DepartmentCreateTime like concat('%',@DepartmentCreateTime,'%') and ExamineStatus like concat('%',@ExamineStatus,'%')" ;


            return GetList(sql, parameters);
        }
    }
}
