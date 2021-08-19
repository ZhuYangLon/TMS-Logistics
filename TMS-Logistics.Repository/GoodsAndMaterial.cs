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
    public class GoodsAndMaterial : Base<GoodsAndMaterials>, IGoodsAndMaterial
    {
        public int GoodsAndMaterialsAdd(GoodsAndMaterials obj)
        {
            string sql = $"insert into GoodsAndMaterials values('{obj.GoodsAndMaterialsName}','{obj.TypeID}','{obj.TextureID}','{obj.Specification}','{obj.PlaceOfOrigin}','{obj.GoodsNumber}','{obj.GoodsContent}','{obj.Proposer}','{obj.WashPayTime}','{obj.Remark}','{obj.CreateTime}','{obj.CommonContractStatus}','{obj.CommonContractName}','{obj.GoodsStatus}')";

            return Efec(sql);
        }

        public int GoodsAndMaterialsDel(string GoodsAndMaterialsID)
        {
            string sql = $"delete from GoodsAndMaterials where GoodsAndMaterialsID in({GoodsAndMaterialsID.Trim(',')})";

            return Efec(sql, GoodsAndMaterialsID);
        }

        public GoodsAndMaterials GoodsAndMaterialsDetails(int GoodsAndMaterialsID)
        {
            string sql = $"select * from GoodsAndMaterials where GoodsAndMaterialsID={GoodsAndMaterialsID}";

            return Backfill(sql, GoodsAndMaterialsID);
        }

        public List<GoodsAndMaterials> GoodsAndMaterialsList(string GoodsAndMaterialsName, int TextureID, string PlaceOfOrigin, string Proposer, int CommonContractName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("GoodsAndMaterialsName", GoodsAndMaterialsName);
            parameters.Add("TextureID", TextureID);
            parameters.Add("PlaceOfOrigin", PlaceOfOrigin);
            parameters.Add("Proposer", Proposer);
            parameters.Add("CommonContractName", CommonContractName);

            string sql = $"select * from GoodsAndMaterials where GoodsAndMaterialsName like concat('%',@GoodsAndMaterialsName,'%') and TextureID like concat('%',@TextureID,'%') and PlaceOfOrigin like concat('%',@PlaceOfOrigin,'%') and Proposer like concat('%',@Proposer,'%') and CommonContractName like concat('%',@CommonContractName,'%')";


            return GetList(sql, parameters);
        }

        public int GoodsAndMaterialsUpd(GoodsAndMaterials obj)
        {
            string sql = $"update GoodsAndMaterials set   GoodsAndMaterialsName='{obj.GoodsAndMaterialsName}',TypeID='{obj.TypeID}',TextureID='{obj.TextureID}',Specification='{obj.Specification}',PlaceOfOrigin='{obj.PlaceOfOrigin}',GoodsNumber='{obj.GoodsNumber}',GoodsContent='{obj.GoodsContent}',Proposer='{obj.Proposer}',WashPayTime='{obj.WashPayTime}',Remark='{obj.Remark}',CreateTime='{obj.CreateTime}',CommonContractStatus='{obj.CommonContractStatus}',CommonContractName='{obj.CommonContractName}',GoodsStatus='{obj.GoodsStatus}'  where GoodsAndMaterialsID={obj.GoodsAndMaterialsID}";

            return Efec(sql);
        }
    }
}
