using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Logistics.Repository;
using TMS_Logistics.IRepository;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;

namespace TMS_Logistics.API.Controllers
{
    /// <summary>
    /// 用户登录
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        public ILogin day1;
        public ILogger<LoginController> logger;
        public LoginController(ILogin _day1, ILogger<LoginController> _logger)
        {
            day1 = _day1;
            logger = _logger;
        }



        [HttpGet]
        public IActionResult Login(string UserName, string Password)
        {
            try
            {
                logger.LogInformation($"{UserName},登录成功");
                return Ok(day1.Loging1(UserName, Password));

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "登录失败");
                throw;
            }

        }

        //[HttpPost, Route("auth")]
        //public IActionResult Authenticate()
        //{
        //    var jwtConfig = Configuration.GetSection("Jwt"); //秘钥，就是标头，这里用Hmacsha256算法，需要256bit的密钥
        //    var securityKey = new SigningCredentials( new SymmetricSecurityKey( Encoding.ASCII.GetBytes(jwtConfig.GetValue<string>("Secret"))), SecurityAlgorithms.HmacSha256); 
        //    //Claim，JwtRegisteredClaimNames中预定义了好多种默认的参数名，也可以像下面的Guid一样 自己定义键名. 
        //    //ClaimTypes也预定义了好多类型如role、email、name。Role用于赋予权限，不同的角色可以访 问不同的接口 
        //    //相当于有效载荷
        //    var claims = new Claim[] {
        //        new Claim(JwtRegisteredClaimNames.Iss,jwtConfig.GetValue<string> ("Iss")),
        //        new Claim(JwtRegisteredClaimNames.Aud,jwtConfig.GetValue<string> ("Aud")),
        //        new Claim("Guid",Guid.NewGuid().ToString("D")), 
        //        new Claim(ClaimTypes.Role,"system"),
        //        new Claim(ClaimTypes.Role,"admin"), 
        //     };
        //    SecurityToken securityToken = new JwtSecurityToken( 
        //        signingCredentials: securityKey, 
        //        expires: DateTime.Now.AddMinutes(2),//过期时间
        //        claims: claims );
        //    //生成jwt令牌
        //      return Content(new JwtSecurityTokenHandler().WriteToken(securityToken));
        //    }
        //


        }
}
