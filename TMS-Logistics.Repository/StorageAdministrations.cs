using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
using TMS_Logistics.IRepository;
using Dapper;

namespace TMS_Logistics.Repository
{
    /// <summary>
    /// 入库管理
    /// </summary>
    public class StorageAdministrations : Base<StorageAdministration_V>, IStorageAdministration
    {
        public int StorageAdminissAdd(StorageAdministration_V obj)
        {
            string sql = $"insert into StorageAdministration_V values('{obj.StorageName}','{obj.GoodsAndMaterialsTypeName}','{obj.TextureName}','{obj.Specification}','{obj.PlaceOfOrigin}','{obj.StorageNumber}','{obj.StoragePrice}','{obj.PayType}','{obj.PurchasePrice}','{obj.Proposer}','{obj.Remark}','{obj.CreateTime}','{obj.GoodsStatus}')";

            return Efec(sql);
        }

        public int StorageAdminissDel(string StorageID)
        {
            string sql = $"delete from StorageAdministration_V where StorageID in({StorageID.Trim(',')})";

            return Efec(sql, StorageID);
        }

        public StorageAdministration_V StorageAdminissDetails(int StorageID)
        {
            string sql = $"select * from StorageAdministration_V where StorageID={StorageID}";

            return Backfill(sql, StorageID);
        }

        public List<StorageAdministration_V> StorageAdminissList(string StorageName, string TextureName, string PlaceOfOrigin, string PayType, string Proposer)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("StorageName", StorageName);
            parameters.Add("TextureName", TextureName);
            parameters.Add("PlaceOfOrigin", PlaceOfOrigin);
            parameters.Add("PayType", PayType);
            parameters.Add("Proposer", Proposer);

            string sql = $"select a.StorageID,a.StorageName,b.GoodsAndMaterialsTypeName,c.TextureName,a.Specification,a.PlaceOfOrigin,a.StorageNumber,a.StoragePrice,a.PayType,a.PurchasePrice,a.Proposer,a.Remark,a.CreateTime,a.GoodsStatus from StorageAdministration a join GoodsType b on a.TypeID = b.GoodsAndMaterialsTypeID join Texture c on a.TextureID = c.TextureID where StorageName like concat('%',@StorageName,'%') and TextureName like concat('%',@TextureName,'%') and PlaceOfOrigin like concat('%',@PlaceOfOrigin,'%') and PayType like concat('%',@PayType,'%') and Proposer like concat('%',@Proposer,'%')";


            return GetList(sql, parameters);
        }

        public int StorageAdminissUpd(StorageAdministration_V obj)
        {
            string sql = $"update StorageAdministration_V set   StorageName='{obj.StorageName}',GoodsAndMaterialsTypeName='{obj.GoodsAndMaterialsTypeName}',TextureName='{obj.TextureName}',Specification='{obj.Specification}',PlaceOfOrigin='{obj.PlaceOfOrigin}',StorageNumber='{obj.StorageNumber}',StoragePrice='{obj.StoragePrice}',PayType='{obj.PayType}',PurchasePrice='{obj.PurchasePrice}',Proposer='{obj.Proposer}',Remark='{obj.Remark}',CreateTime='{obj.CreateTime}',GoodsStatus='{obj.GoodsStatus}'  where StorageID={obj.StorageID}";

            return Efec(sql);
        }
    }
}
