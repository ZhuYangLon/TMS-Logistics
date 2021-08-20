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
    /// 油费管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class PostageAdminController : Controller
    {
        public IPostageAdministration postage;
        public ILogger<PostageAdminController> logger;
        public PostageAdminController(IPostageAdministration _postage, ILogger<PostageAdminController> _logger)
        {
            postage = _postage;
            logger = _logger;
        }
        /// <summary>
        /// 油费显示
        /// </summary>
        /// <param name="LicensePlateNumber">车牌号</param>
        /// <param name="ExamineName">经办人</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PostageAdminList(string LicensePlateNumber, string ExamineName)
        {
            try
            {
                return Ok(postage.PostageAdministrationsList(LicensePlateNumber, ExamineName));
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
        public IActionResult PostageAdministrationsAdd(PostageAdministration obj)
        {
            try
            {
                int hang = postage.PostageAdministrationsAdd(obj);
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
        /// 油费删除
        /// </summary>
        /// <param name="PostageAdministrationID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostageAdministrationsDel(string PostageAdministrationID)
        {
            try
            {
                int hang = postage.PostageAdministrationsDel(PostageAdministrationID);
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
        /// 油费反填
        /// </summary>
        /// <param name="PostageAdministrationID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PostageAdministrationsDetails(int PostageAdministrationID)
        {
            try
            {
                return Ok(postage.PostageAdministrationsDetails(PostageAdministrationID));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }

        }
        /// <summary>
        /// 油费修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OutsourcingUnitsUpd(PostageAdministration obj)
        {
            try
            {
                int hang = postage.PostageAdministrationsUpd(obj);
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
