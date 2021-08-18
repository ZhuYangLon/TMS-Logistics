using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.IRepository;
using TMS_Logistics.Model;
using Dapper;
namespace TMS_Logistics.Repository
{
    /// <summary>
    /// 员工登记
    /// </summary>
    public class Employee : Base<EmployeeModel>,IEmployee
    {
        public List<EmployeeModel> EmployeeList(string EmployeeName, string EmployeePhone, int EmployeeType)
        {
            //参数化 防止sql注入
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("EmployeeName",EmployeeName);
            parameters.Add("EmployeePhone", EmployeePhone);
            parameters.Add("EmployeeType", EmployeeType);

            string sql = "select * from EmployeeModel where EmployeeName like concat ('%',@EmployeeName,'%') and  EmployeePhone like concat('%',@EmployeePhone,'%')  and  EmployeeType like concat('%',@EmployeeType,'%')";

            return GetList(sql, parameters).ToList();
        }
    }
}
