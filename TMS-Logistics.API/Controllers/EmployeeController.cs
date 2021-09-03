using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Logistics.IRepository;
using TMS_Logistics.Model;
namespace TMS_Logistics.API.Controllers
{
    /// <summary>
    /// 员工登记
    /// </summary>
    [Route("Employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public IEmployee employee;
        public ILogger<EmployeeController> logger;
        public EmployeeController(IEmployee _employee, ILogger<EmployeeController> _logger)
        {
            employee = _employee;
            logger = _logger;
        }
        /// <summary>
        /// 员工显示
        /// </summary>
        /// <param name="EmployeeName"></param>
        /// <param name="EmployeePhone"></param>
        /// <param name="EmployeeType"></param>
        /// <returns></returns>
        [HttpGet,Route("EmployeeList")]
        public IActionResult EmployeeList(string EmployeeName, string EmployeePhone, int EmployeeType)
        {
            try
            {
                return Ok(employee.EmployeeList(EmployeeName,EmployeePhone,EmployeeType));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
            
        }
    }
}
