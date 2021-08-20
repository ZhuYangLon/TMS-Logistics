using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Logistics.Model;
using TMS_Logistics.IRepository;
using Microsoft.Extensions.Logging;

namespace TMS_Logistics.API.Controllers
{
    /// <summary>
    /// 离职办理
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class ResignationController : Controller
    {
        public IResignation registration;
        public ILogger<ResignationController> logger;
        public ResignationController(IResignation _registration, ILogger<ResignationController> _logger)
        {
            registration = _registration;
            logger = _logger;
        }
        /// <summary>
        /// 离职办理显示
        /// </summary>
        /// <param name="EmployeeName">姓名</param>
        /// <param name="DepartmentName">部门</param>
        /// <param name="PositionName">职位</param>
        /// <param name="EmployeeEntryTime">入职日期</param>
        /// <param name="EmployeeEndWorkTime">最后工作日</param>
        /// <param name="ExamineStatus">审批状态</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ResignationsList(string EmployeeName, string DepartmentName, string PositionName, string EmployeeEntryTime, string EmployeeEndWorkTime, string ExamineStatus)
        {
            try
            {
                return Ok(registration.ResignationsList(EmployeeName, DepartmentName, PositionName, EmployeeEntryTime, EmployeeEndWorkTime, ExamineStatus));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里出错了");
                throw;
            }
        }
    }
}
