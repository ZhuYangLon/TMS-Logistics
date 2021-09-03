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
    /// 应收费用管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ChargeController : ControllerBase
    {
        public ICharges charges;
        public ILogger<ChargeController> logger;
        public ChargeController(ICharges _charges, ILogger<ChargeController> _logger)
        {
            charges = _charges;
            logger = _logger;
        }

        /// <summary>
        /// 应收费用显示
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit">线路名称</param>
        /// <param name="PayType">起点</param>
        /// <param name="CheckType">终点</param>
        /// <param name="CircuitResponsibleName">是否外协</param>
        /// <param name="ProfessionalTime">货主手机号</param>
        /// <returns></returns>
        [HttpGet,Route("ChargesList")]
        public IActionResult ChargesList(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, string ProfessionalTime)
        {

            try
            {

                return Ok(charges.ChargesList(ChargeOwnerOfCargoUnit, PayType, CheckType, CircuitResponsibleName, ProfessionalTime));

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }

        /// <summary>
        /// 应收费用添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost,Route("ChargesAdd")]
        public IActionResult ChargesAdd(Charge obj)
        {
            try
            {
                int hang = charges.ChargesAdd(obj);
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
        /// 应收费用删除
        /// </summary>
        /// <param name="ChargeID"></param>
        /// <returns></returns>
        [HttpPost,Route("ChargesDel")]
        public IActionResult ChargesDel(string ChargeID)
        {
            try
            {
                int hang = charges.ChargesDel(ChargeID);
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
        /// 应收费用反填
        /// </summary>
        /// <param name="ChargeID"></param>
        /// <returns></returns>
        [HttpGet,Route("ChargesDetails")]
        public IActionResult ChargesDetails(int ChargeID)
        {
            try
            {
                return Ok(charges.ChargesDetails(ChargeID));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }

        }
        /// <summary>
        /// 应收费用修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost,Route("ChargesUpd")]
        public IActionResult ChargesUpd(Charge obj)
        {
            try
            {
                int hang = charges.ChargesUpd(obj);
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
