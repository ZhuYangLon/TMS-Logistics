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
    /// 入职办理
    /// </summary>
    [Route("HiredToHandle")]
    [ApiController]
    public class HiredToHandleController : Controller
    {
        public IHiredToHandle hiredTo;
        public ILogger<HiredToHandleController> logger;
        public HiredToHandleController(IHiredToHandle _hiredTo, ILogger<HiredToHandleController> _logger)
        {
            hiredTo = _hiredTo;
            logger = _logger;
        }
        /// <summary>
        /// 入职办理显示
        /// </summary>
        /// <param name="EmployeeName">姓名</param>
        /// <param name="DepartmentName">部门</param>
        /// <param name="PositionName">职位</param>
        /// <param name="EmployeeEntryTime">到岗日期</param>
        /// <param name="DepartmentCreateTime">合同签署日期</param>
        /// <param name="ExamineStatus">审批状态</param>
        /// <returns></returns>
        [HttpGet,Route(nameof(HiredToHandlesList))]
        public IActionResult HiredToHandlesList(string EmployeeName, string DepartmentName, string PositionName, string EmployeeEntryTime, string DepartmentCreateTime, string ExamineStatus)
        {
            try
            {
                return Ok(hiredTo.HiredToHandlesList(EmployeeName, DepartmentName, PositionName, EmployeeEntryTime, DepartmentCreateTime, ExamineStatus));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }
    }
}
