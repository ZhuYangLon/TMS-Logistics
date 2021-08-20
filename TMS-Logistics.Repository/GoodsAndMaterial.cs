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
    /// 物资管理
    /// </summary>
    public class GoodsAndMaterial : Base<GoodsAndMaterials_V>, IGoodsAndMaterial
    {
        public int GoodsAndMaterialsAdd(GoodsAndMaterials_V obj)
        {
            string sql = $"insert into GoodsAndMaterials_V values('{obj.GoodsAndMaterialsName}','{obj.GoodsAndMaterialsTypeName}','{obj.TextureName}','{obj.Specification}','{obj.PlaceOfOrigin}','{obj.GoodsNumber}','{obj.GoodsContent}','{obj.Proposer}','{obj.WashPayTime}','{obj.Remark}','{obj.CreateTime}','{obj.CommonContractStatus}','{obj.CommonContractName}','{obj.GoodsStatus}')";

            return Efec(sql);
        }

        public int GoodsAndMaterialsDel(string GoodsAndMaterialsID)
        {
            string sql = $"delete from GoodsAndMaterials_V where GoodsAndMaterialsID in({GoodsAndMaterialsID.Trim(',')})";

            return Efec(sql, GoodsAndMaterialsID);
        }

        public GoodsAndMaterials_V GoodsAndMaterialsDetails(int GoodsAndMaterialsID)
        {
            string sql = $"select * from GoodsAndMaterials_V where GoodsAndMaterialsID={GoodsAndMaterialsID}";

            return Backfill(sql, GoodsAndMaterialsID);
        }

        public List<GoodsAndMaterials_V> GoodsAndMaterialsList(string GoodsAndMaterialsName, string GoodsAndMaterialsTypeName, string PlaceOfOrigin, string Proposer, string TextureName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("GoodsAndMaterialsName", GoodsAndMaterialsName);
            parameters.Add("GoodsAndMaterialsTypeName", GoodsAndMaterialsTypeName);
            parameters.Add("PlaceOfOrigin", PlaceOfOrigin);
            parameters.Add("Proposer", Proposer);
            parameters.Add("TextureName", TextureName);

            string sql = $"select a.GoodsAndMaterialsID,a.GoodsAndMaterialsName,b.GoodsAndMaterialsTypeName,c.TextureName,a.Specification,a.PlaceOfOrigin,a.GoodsNumber,a.GoodsContent,a.Proposer,a.WashPayTime,a.Remark,a.CreateTime,a.CommonContractStatus,a.CommonContractName,a.GoodsStatus from GoodsAndMaterials a join GoodsType b on a.TypeID = b.GoodsAndMaterialsTypeID join Texture c on a.TextureID = c.TextureID where GoodsAndMaterialsName like concat('%',@GoodsAndMaterialsName,'%') and GoodsAndMaterialsTypeName like concat('%',@GoodsAndMaterialsTypeName,'%') and PlaceOfOrigin like concat('%',@PlaceOfOrigin,'%') and Proposer like concat('%',@Proposer,'%') and TextureName like concat('%',@TextureName,'%')";


            return GetList(sql, parameters);
        }

        public int GoodsAndMaterialsUpd(GoodsAndMaterials_V obj)
        {
            string sql = $"update GoodsAndMaterials_V set   GoodsAndMaterialsName='{obj.GoodsAndMaterialsName}',GoodsAndMaterialsTypeName='{obj.GoodsAndMaterialsTypeName}',TextureName='{obj.TextureName}',Specification='{obj.Specification}',PlaceOfOrigin='{obj.PlaceOfOrigin}',GoodsNumber='{obj.GoodsNumber}',GoodsContent='{obj.GoodsContent}',Proposer='{obj.Proposer}',WashPayTime='{obj.WashPayTime}',Remark='{obj.Remark}',CreateTime='{obj.CreateTime}',CommonContractStatus='{obj.CommonContractStatus}',CommonContractName='{obj.CommonContractName}',GoodsStatus='{obj.GoodsStatus}'  where GoodsAndMaterialsID={obj.GoodsAndMaterialsID}";

            return Efec(sql);
        }
    }
}
