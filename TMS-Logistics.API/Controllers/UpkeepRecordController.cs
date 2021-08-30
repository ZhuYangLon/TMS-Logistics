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
    }
}
