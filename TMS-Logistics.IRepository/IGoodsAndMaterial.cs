using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 物资管理
    /// </summary>
    public interface IGoodsAndMaterial:IBase<GoodsAndMaterials>
    {
        List<GoodsAndMaterials> GoodsAndMaterialsList(string GoodsAndMaterialsName, int TextureID,string PlaceOfOrigin,string Proposer,int CommonContractName);

        int GoodsAndMaterialsAdd(GoodsAndMaterials obj);

        int GoodsAndMaterialsDel(string GoodsAndMaterialsID);

        int GoodsAndMaterialsUpd(GoodsAndMaterials obj);

        GoodsAndMaterials GoodsAndMaterialsDetails(int GoodsAndMaterialsID);
    }
}
