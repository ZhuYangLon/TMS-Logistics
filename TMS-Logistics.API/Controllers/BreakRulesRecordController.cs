using Microsoft.AspNetCore.Http;
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
    /// 违章记录
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BreakRulesRecordController : ControllerBase
    {
        public IBreakRulesRecord record;
        public ILogger<ChargeController> logger;
        public BreakRulesRecordController(IBreakRulesRecord _record, ILogger<ChargeController> _logger)
        {
            record = _record;
            logger = _logger;
        }

        /// <summary>
        /// 违章记录显示
        /// </summary>
        /// <param name="BreakRulesTitle">线路名称</param>
        /// <param name="LicensePlateNumber">起点</param>
        /// <param name="BreakRulesTime">终点</param>
        /// <returns></returns>
        [HttpGet, Route("BreakRulesRecordList")]
        public IActionResult BreakRulesRecordList(string BreakRulesTitle, string LicensePlateNumber, string BreakRulesTime)
        {

            try
            {

                return Ok(record.BreakRulesList(BreakRulesTitle, LicensePlateNumber, BreakRulesTime));

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }

        /// <summary>
        /// 违章记录添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost, Route("BreakRulesRecordAdd")]
        public IActionResult BreakRulesRecordAdd(BreakRulesRecord obj)
        {
            try
            {
                int hang = record.BreakRulesAdd(obj);
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
        /// 违章记录删除
        /// </summary>
        /// <param name="BreakRulesID"></param>
        /// <returns></returns>
        [HttpPost, Route("BreakRulesRecordDel")]
        public IActionResult BreakRulesRecordDel(string BreakRulesID)
        {
            try
            {
                int hang = record.BreakRulesDel(BreakRulesID);
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
        /// 违章记录反填
        /// </summary>
        /// <param name="BreakRulesID"></param>
        /// <returns></returns>
        [HttpGet, Route("BreakRulesRecordDetails")]
        public IActionResult BreakRulesRecordDetails(int BreakRulesID)
        {
            try
            {
                return Ok(record.BreakRulesDetails(BreakRulesID));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }

        }
        /// <summary>
        /// 违章记录修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost, Route("BreakRulesRecordUpd")]
        public IActionResult BreakRulesRecordUpd(BreakRulesRecord obj)
        {
            try
            {
                int hang = record.BreakRulesUpd(obj);
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
