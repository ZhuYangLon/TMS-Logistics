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
    /// 入库管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class StorageAdminisController : Controller
    {
        public IStorageAdministration storage;
        public ILogger<StorageAdminisController> logger;
        public StorageAdminisController(IStorageAdministration _storage, ILogger<StorageAdminisController> _logger)
        {
            storage = _storage;
            logger = _logger;
        }

        /// <summary>
        /// 入库管理显示
        /// </summary>
        /// <param name="StorageName"></param>
        /// <param name="TextureName"></param>
        /// <param name="PlaceOfOrigin"></param>
        /// <param name="PayType"></param>
        /// <param name="Proposer"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult StorageAdminissList(string StorageName, string TextureName, string PlaceOfOrigin, string PayType, string Proposer)
        {
            try
            {
                return Ok(storage.StorageAdminissList(StorageName, TextureName, PlaceOfOrigin, PayType, Proposer));

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }
    }
}
