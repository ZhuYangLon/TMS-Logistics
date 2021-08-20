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
    public interface IGoodsAndMaterial:IBase<GoodsAndMaterials_V>
    {
        List<GoodsAndMaterials_V> GoodsAndMaterialsList(string GoodsAndMaterialsName, string GoodsAndMaterialsTypeName, string PlaceOfOrigin,string Proposer,string TextureName);

        int GoodsAndMaterialsAdd(GoodsAndMaterials_V obj);

        int GoodsAndMaterialsDel(string GoodsAndMaterialsID);

        int GoodsAndMaterialsUpd(GoodsAndMaterials_V obj);

        GoodsAndMaterials_V GoodsAndMaterialsDetails(int GoodsAndMaterialsID);
    }
}
