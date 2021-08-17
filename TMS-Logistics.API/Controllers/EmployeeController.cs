using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Logistics.IRepository;
using TMS_Logistics.Model;
namespace TMS_Logistics.API.Controllers
{
    /// <summary>
    /// 员工管理
    /// </summary>
    [Route("api/[Controller]/[action]")]
    public class EmployeeController : Controller
    {
        public IEmployee employee;
        public EmployeeController(IEmployee _employee)
        {
            employee = _employee;
        }
        /// <summary>
        /// 员工显示
        /// </summary>
        /// <param name="EmployeeName"></param>
        /// <param name="EmployeePhone"></param>
        /// <param name="EmployeeType"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EmployeeList(string EmployeeName, string EmployeePhone, int EmployeeType)
        {
            try
            {
                return Ok(employee.EmployeeList(EmployeeName,EmployeePhone,EmployeeType));
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
