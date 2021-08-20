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
    /// 转正管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class TransformationController : Controller
    {
        public ITransformation transformation;
        public ILogger<TransformationController> logger;
        public TransformationController(ITransformation _transformation, ILogger<TransformationController> _logger)
        {
            transformation = _transformation;
            logger = _logger;
        }

        /// <summary>
        /// 转正管理显示
        /// </summary>
        /// <param name="EmployeeName">姓名</param>
        /// <param name="DepartmentName">部门</param>
        /// <param name="PositionName">职位</param>
        /// <param name="EmployeeEntryTime">入职日期</param>
        /// <param name="EmployeeProposerTime">申请日期</param>
        /// <param name="ExamineStatus">审批状态</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult TransformationsList(string EmployeeName, string DepartmentName, string PositionName, string EmployeeEntryTime, string EmployeeProposerTime, string ExamineStatus)
        {
            try
            {
                return Ok(transformation.TransformationsList(EmployeeName, DepartmentName, PositionName, EmployeeEntryTime, EmployeeProposerTime, ExamineStatus));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里有错误");
                throw;
            }
        }
    }
}
