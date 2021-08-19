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
    /// 离职办理
    /// </summary>
    public class Resignations : Base<Resignation_V>, IResignation
    {
        public List<Resignation_V> ResignationsList(string EmployeeName, string DepartmentName, string PositionName, string EmployeeEntryTime, string EmployeeEndWorkTime, string ExamineStatus)
        {
            //防止sql注入
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("EmployeeName", EmployeeName);
            parameters.Add("DepartmentName", DepartmentName);
            parameters.Add("PositionName", PositionName);
            parameters.Add("EmployeeEntryTime", EmployeeEntryTime);
            parameters.Add("EmployeeEndWorkTime", EmployeeEndWorkTime);
            parameters.Add("ExamineStatus", ExamineStatus);

            string sql = $"select  a.EmployeeName,b.DepartmentName,c.PositionName,a.EmployeeParentName,a.EmployeeEntryTime,a.EmployeeEndWorkTime,a.EmployeeLeaveSession,d.ExamineStatus,b.DepartmentCreateTime,d.ExamineName from EmployeeModel a join DepartmentModel b on a.EmployeeID = b.DepartmentID join PositionModel c on a.EmployeeID = c.PositionID join ExamineModel d on a.EmployeeID = d.ExamineID join UserModel e on a.EmployeeID = e.UserID where EmployeeName like concat('%',@EmployeeName,'%') and DepartmentName like concat('%',@DepartmentName,'%') and PositionName like concat('%',@PositionName,'%') and EmployeeEntryTime like concat('%',@EmployeeEntryTime,'%') and EmployeeEndWorkTime like concat('%',@EmployeeEndWorkTime,'%') and ExamineStatus like concat('%',@ExamineStatus,'%')";


            return GetList(sql, parameters);
        }
    }
}
