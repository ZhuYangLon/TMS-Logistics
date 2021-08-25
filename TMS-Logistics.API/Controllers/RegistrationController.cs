using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Logistics.Repository;
using TMS_Logistics.IRepository;
using TMS_Logistics.Model;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace TMS_Logistics.API.Controllers
{
    /// <summary>
    /// 车辆管理
    /// </summary>
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class RegistrationController : Controller
    {
        public IRegistration registration;
        public ILogger<RegistrationController> logger;
        public RegistrationController(IRegistration _registration, ILogger<RegistrationController> _logger)
        {
            registration = _registration;
            logger = _logger;
        }
        /// <summary>
        /// 车辆显示
        /// </summary>
        /// <param name="FactoryPlateModel">厂牌型号</param>
        /// <param name="LicensePlateNumber">车牌号</param>
        /// <param name="LicensePlateName">司机姓名</param>
        /// <param name="SubordinateCompanies">所属公司</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RegistrationList(string FactoryPlateModel, string LicensePlateNumber, string LicensePlateName, string SubordinateCompanies)
        {
            try
            {
                return Ok(registration.RegistrationList(FactoryPlateModel, LicensePlateNumber, LicensePlateName, SubordinateCompanies));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
            
        }
        /// <summary>
        /// 车辆添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegistrationAdd(RegistrationModel obj)
        {
            try
            {
                int hang = registration.RegistrationAdd(obj);
                if (hang>0)
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
        /// 车辆删除
        /// </summary>
        /// <param name="RegistrationID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegistrationDel(string RegistrationID)
        {
            try
            {
                int hang = registration.RegistrationDel(RegistrationID);
                if (hang>0)
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
    }
}
