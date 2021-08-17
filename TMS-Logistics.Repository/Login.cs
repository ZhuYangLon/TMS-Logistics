using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.IRepository;
using TMS_Logistics.Model;
using Dapper;

namespace TMS_Logistics.Repository
{
   public class Login:Base<UserModel>,ILogin
    {
        public UserModel Loging1(string UserName, string Password)
        {
            //参数化
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserName", UserName);
            parameters.Add("UserPwd", Password);

            string sql = $"select * from UserModel where UserName=@UserName and UserPwd=@UserPwd";

            return GetList(sql, parameters).ToList().FirstOrDefault();
        }
    }
}
