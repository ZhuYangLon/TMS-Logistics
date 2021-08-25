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
    /// 维护记录
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class MaintainRecordController : Controller
    {
        public IMaintainRecord maintain;
        public ILogger<MaintainRecordController> logger;
        public MaintainRecordController(IMaintainRecord _maintain, ILogger<MaintainRecordController> _logger)
        {
            maintain = _maintain;
            logger = _logger;
        }
        /// <summary>
        /// 维护记录显示
        /// </summary>
        /// <param name="MaintainRecordName"></param>
        /// <param name="MaintainRecordTime"></param>
        /// <param name="LicensePlateNumber"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult MaintainRecordsList(string MaintainRecordName, string MaintainRecordTime, string LicensePlateNumber)
        {
            try
            {

                return Ok(maintain.MaintainRecordsList(MaintainRecordName, MaintainRecordTime, LicensePlateNumber));

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }

        /// <summary>
        /// 维护记录添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult MaintainRecordsAdd(MaintainRecord obj)
        {
            try
            {
                int hang = maintain.MaintainRecordsAdd(obj);
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
        /// 维护记录删除
        /// </summary>
        /// <param name="MaintainRecordID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult MaintainRecordsDel(string MaintainRecordID)
        {
            try
            {
                int hang = maintain.MaintainRecordsDel(MaintainRecordID);
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
        /// 维护记录反填
        /// </summary>
        /// <param name="MaintainRecordID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CircuitAdministrationsDetails(int MaintainRecordID)
        {
            try
            {
                return Ok(maintain.MaintainRecordsDetails(MaintainRecordID));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }

        }
        /// <summary>
        /// 维护记录修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult MaintainRecordsUpd(MaintainRecord obj)
        {
            try
            {
                int hang = maintain.MaintainRecordsUpd(obj);
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
