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
    /// 保养记录
    /// </summary>
    [Route("api/controller/action")]
    public class UpkeepRecordController : Controller
    {
        public IUpkeepRecord Upkeep;
        public ILogger<CircuitAdminController> logger;
        public UpkeepRecordController(IUpkeepRecord _Upkeep, ILogger<CircuitAdminController> _logger)
        {
            Upkeep = _Upkeep;
            logger = _logger;
        }
        /// <summary>
        /// 保养记录显示
        /// </summary>
        /// <param name="UpkeepRecordName"></param>
        /// <param name="UpkeepRecordNowTime"></param>
        /// <param name="LicensePlateNumber"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpkeepRecordsList(string UpkeepRecordName, string UpkeepRecordNowTime, string LicensePlateNumber)
        {

            try
            {

                return Ok(Upkeep.UpkeepRecordsList(UpkeepRecordName, UpkeepRecordNowTime, LicensePlateNumber));

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }
        /// <summary>
        /// 保养记录添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpkeepRecordsAdd(UpkeepRecord obj)
        {
            try
            {
                int hang = Upkeep.UpkeepRecordsAdd(obj);
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
        /// 保养记录删除
        /// </summary>
        /// <param name="UpkeepRecordID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpkeepRecordsDel(string UpkeepRecordID)
        {
            try
            {
                int hang = Upkeep.UpkeepRecordsDel(UpkeepRecordID);
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
        /// 保养记录反填
        /// </summary>
        /// <param name="UpkeepRecordsDel"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpkeepRecordsDetails(int UpkeepRecordsDel)
        {
            try
            {
                return Ok(Upkeep.UpkeepRecordsDetails(UpkeepRecordsDel));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }

        }
        /// <summary>
        /// 保养记录修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpkeepRecordsUpd(UpkeepRecord obj)
        {
            try
            {
                int hang = Upkeep.UpkeepRecordsUpd(obj);
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
