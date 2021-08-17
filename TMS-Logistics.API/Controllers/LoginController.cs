using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Logistics.Repository;
using TMS_Logistics.IRepository;
using Microsoft.Extensions.Logging;

namespace TMS_Logistics.API.Controllers
{
    /// <summary>
    /// 用户登录
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        public ILogin day1;
        public  ILogger<LoginController> logger;
        public LoginController(ILogin _day1, ILogger<LoginController> _logger)
        {
            day1= _day1;
            logger = _logger;
        }

        
        
        [HttpGet]
        public IActionResult Login(string UserName,string Password)
        {
            try
            {
                logger.LogInformation($"{UserName},登录成功");
                return Ok(day1.Loging1(UserName,Password));
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"登录失败");
                throw;
            }
            
        }
    }
}
