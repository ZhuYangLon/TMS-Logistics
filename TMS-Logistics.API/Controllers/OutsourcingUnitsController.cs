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
    /// 外协单位
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class OutsourcingUnitsController : Controller
    {
        public IOutsourcingUnits outsourcing;
        public ILogger<OutsourcingUnitsController> logger;
        public OutsourcingUnitsController(IOutsourcingUnits _outsourcing, ILogger<OutsourcingUnitsController> _logger)
        {
            outsourcing = _outsourcing;
            logger = _logger;
        }
        /// <summary>
        /// 外协单位显示
        /// </summary>
        /// <param name="OutsourcingUnitName">单位名称</param>
        /// <param name="OutsourcingUnitTelephone">电话</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OutsourcingUnitsList(string OutsourcingUnitName, string OutsourcingUnitTelephone)
        {
            try
            {
                return Ok(outsourcing.OutsourcingUnitsList(OutsourcingUnitName, OutsourcingUnitTelephone));

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }

        /// <summary>
        /// 外协单位添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OutsourcingUnitsAdd(OutsourcingUnit obj)
        {
            try
            {
                int hang = outsourcing.OutsourcingUnitsAdd(obj);
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
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }
        /// <summary>
        /// 外协单位删除
        /// </summary>
        /// <param name="OutsourcingUnitID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OutsourcingUnitsDel(string OutsourcingUnitID)
        {
            try
            {
                int hang = outsourcing.OutsourcingUnitsDel(OutsourcingUnitID);
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
        /// 外协单位反填
        /// </summary>
        /// <param name="OutsourcingUnitID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OutsourcingUnitsDetails(int OutsourcingUnitID)
        {
            try
            {
                return Ok(outsourcing.OutsourcingUnitsDetails(OutsourcingUnitID));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
            
        }
        /// <summary>
        /// 外协单位修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OutsourcingUnitsUpd(OutsourcingUnit obj)
        {
            try
            {
                int hang = outsourcing.OutsourcingUnitsUpd(obj);
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
