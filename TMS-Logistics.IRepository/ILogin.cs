using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
   public interface ILogin:IBase<UserModel>
    {
        //登录
        UserModel Loging1(string UserName, string Password);
    }
}
