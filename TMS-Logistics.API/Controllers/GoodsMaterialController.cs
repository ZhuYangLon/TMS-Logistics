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
    /// 物资采购
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class GoodsMaterialController : Controller
    {
        public IGoodsAndMaterial goodsAnd;
        public ILogger<GoodsMaterialController> logger;
        public GoodsMaterialController(IGoodsAndMaterial _goodsAnd, ILogger<GoodsMaterialController> _logger)
        {
            goodsAnd = _goodsAnd;
            logger = _logger;
        }
        /// <summary>
        /// 物资采购显示
        /// </summary>
        /// <param name="GoodsAndMaterialsName">货物名称</param>
        /// <param name="GoodsAndMaterialsTypeName">材质</param>
        /// <param name="PlaceOfOrigin">产地</param>
        /// <param name="Proposer">申请人</param>
        /// <param name="TextureName">审核人</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GoodsAndMaterialsList(string GoodsAndMaterialsName, string GoodsAndMaterialsTypeName, string PlaceOfOrigin, string Proposer, string TextureName)
        {
            try
            {
                return Ok(goodsAnd.GoodsAndMaterialsList(GoodsAndMaterialsName, GoodsAndMaterialsTypeName, PlaceOfOrigin, Proposer, TextureName));

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }
        }
        /// <summary>
        /// 物资采购添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GoodsAndMaterialsAdd(GoodsAndMaterials_V obj)
        {
            try
            {
                int hang = goodsAnd.GoodsAndMaterialsAdd(obj);
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
        /// 物资采购删除
        /// </summary>
        /// <param name="GoodsAndMaterialsID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GoodsAndMaterialsDel(string GoodsAndMaterialsID)
        {
            try
            {
                int hang = goodsAnd.GoodsAndMaterialsDel(GoodsAndMaterialsID);
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
        /// 物资采购反填
        /// </summary>
        /// <param name="GoodsAndMaterialsID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GoodsAndMaterialsDetails(int GoodsAndMaterialsID)
        {
            try
            {
                return Ok(goodsAnd.GoodsAndMaterialsDetails(GoodsAndMaterialsID));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "这里发生了错误");
                throw;
            }

        }
        /// <summary>
        /// 物资采购修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GoodsAndMaterialsUpd(GoodsAndMaterials_V obj)
        {
            try
            {
                int hang = goodsAnd.GoodsAndMaterialsUpd(obj);
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
