using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 油费管理
    /// </summary>
   public interface IPostageAdministration:IBase<PostageAdministration>
    {
        List<PostageAdministration> PostageAdministrationsList(string LicensePlateNumber, string ExamineName);

        int PostageAdministrationsAdd(PostageAdministration obj);

        int PostageAdministrationsDel(string PostageAdministrationID);

        int PostageAdministrationsUpd(PostageAdministration obj);

        PostageAdministration PostageAdministrationsDetails(int PostageAdministrationID);
    }
}
