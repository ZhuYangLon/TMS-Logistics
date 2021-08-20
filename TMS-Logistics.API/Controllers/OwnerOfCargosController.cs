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
    /// 货主管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class OwnerOfCargosController : Controller
    {
        public IOwnerOfCargos ownerOf;
        public ILogger<OwnerOfCargosController> logger;
        public OwnerOfCargosController(IOwnerOfCargos _ownerOf, ILogger<OwnerOfCargosController> _logger)
        {
            ownerOf = _ownerOf;
            logger = _logger;
        }

        /// <summary>
        /// 货主显示
        /// </summary>
        /// <param name="EmployeeName">货主姓名</param>
        /// <param name="EmployeePhone">手机号</param>
        /// <param name="DrivingLicenceTime">驾驶证有效日期</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OwnerOfCargosList(string EmployeeName, string EmployeePhone, DateTime? DrivingLicenceTime)
        {
            try
            {
                return Ok(ownerOf.OwnerOfCargoList(EmployeeName, EmployeePhone,DrivingLicenceTime));
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"这里发生了错误");
                throw;
            }
            
        }
        /// <summary>
        /// 货主添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OwnerOfCargosAdd(OwnerOfCargo obj)
        {
            try
            {
                int hang = ownerOf.OwnerOfCargoAdd(obj);
                if (hang>0)
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
                logger.LogError(ex,"这里发生了错误");
                throw;
            }
        }
        /// <summary>
        /// 货主删除
        /// </summary>
        /// <param name="OwnerOfCargoID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OwnerOfCargosDel(string OwnerOfCargoID)
        {
            try
            {
                int hang = ownerOf.OwnerOfCargoDel(OwnerOfCargoID);
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
                logger.LogError(ex,"这里发生了错误");
                throw;
            }
        }
        /// <summary>
        /// 货主反填
        /// </summary>
        /// <param name="OwnerOfCargoID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OwnerOfCargoDetails(int OwnerOfCargoID)
        {
            try
            {
                return Ok(ownerOf.OwnerOfCargoDetails(OwnerOfCargoID));
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"这里发生了错误");
                throw;
            }
            
        }
        /// <summary>
        /// 货主修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OutsourcingUnitsUpd(OwnerOfCargo obj)
        {
            try
            {
                int hang = ownerOf.OwnerOfCargoUpd(obj);
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
                logger.LogError(ex,"这里发生了错误");
                throw;
            }
        }
    }
}
