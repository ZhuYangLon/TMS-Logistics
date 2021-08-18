using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 员工登记
    /// </summary>
    public interface IEmployee:IBase<EmployeeModel>
    {
        List<EmployeeModel> EmployeeList(string EmployeeName,string EmployeePhone,int EmployeeType);
    }
}
