using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Logistics.Model;
using TMS_Logistics.IRepository;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace TMS_Logistics.API.Controllers
{
    /// <summary>
    /// 线路管理
    /// </summary>
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class CircuitAdminController : Controller
    {
        public ICircuitAdmin circuit;
        public ILogger<CircuitAdminController> logger;
        public CircuitAdminController(ICircuitAdmin _circuit, ILogger<CircuitAdminController> _logger)
        {
            circuit = _circuit;
            logger = _logger;
        }

        /// <summary>
        /// 线路显示
        /// </summary>
        /// <param name="CircuitName">线路名称</param>
        /// <param name="CircuitStartPlace">起点</param>
        /// <param name="CircuitEndPlace">终点</param>
        /// <param name="IsOutsource">是否外协</param>
        /// <param name="EmployeePhone">货主手机号</param>
        /// <param name="OutsourcingUnitName">货主单位</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CircuitAdministrationsList(string CircuitName, string CircuitStartPlace, string CircuitEndPlace, string IsOutsource, string EmployeePhone, string OutsourcingUnitName)
        {

            try
            {
                
                return Ok(circuit.CircuitAdministrationsList(CircuitName, CircuitStartPlace, CircuitEndPlace, IsOutsource, EmployeePhone, OutsourcingUnitName));

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }

        /// <summary>
        /// 线路管理添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CircuitAdministrationsAdd(CircuitAdministration_V obj)
        {
            try
            {
                int hang = circuit.CircuitAdministrationsAdd(obj);
                if (hang > 0)
                {
                    return Ok("添加成功");
                }
                else
                {
                    return Ok("添加失败");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }
        /// <summary>
        /// 线路管理删除
        /// </summary>
        /// <param name="CircuitAdministrationID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CircuitAdministrationsDel(string CircuitAdministrationID)
        {
            try
            {
                int hang = circuit.CircuitAdministrationsDel(CircuitAdministrationID);
                if (hang > 0)
                {
                    return Ok("删除成功");
                }
                else
                {
                    return Ok("删除失败");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }
        /// <summary>
        /// 线路管理反填
        /// </summary>
        /// <param name="CircuitAdministrationID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CircuitAdministrationsDetails(int CircuitAdministrationID)
        {
            try
            {
                return Ok(circuit.CircuitAdministrationsDetails(CircuitAdministrationID));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }

        }
        /// <summary>
        /// 线路管理修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CircuitAdministrationsUpd(CircuitAdministration_V obj)
        {
            try
            {
                int hang = circuit.CircuitAdministrationsUpd(obj);
                if (hang > 0)
                {
                    return Ok("修改成功");
                }
                else
                {
                    return Ok("修改失败");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }
    }
}
