using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 入库管理
    /// </summary>
    public interface IStorageAdministration:IBase<StorageAdministration_V>
    {
        List<StorageAdministration_V> StorageAdminissList(string StorageName, string TextureName, string PlaceOfOrigin, string PayType, string Proposer);

        int StorageAdminissAdd(StorageAdministration_V obj);

        int StorageAdminissDel(string StorageID);

        int StorageAdminissUpd(StorageAdministration_V obj);

        StorageAdministration_V StorageAdminissDetails(int StorageID);
    }
}
