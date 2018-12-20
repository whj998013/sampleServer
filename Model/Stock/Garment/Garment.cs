using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Stock;
namespace SG.Model.Stock
{
    public class Garment :Goods, IPrice
    {
        /// <summary>
        /// 原料成份
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public string GoodsType { get; set; }
        /// <summary>
        /// 款式外链ID(10000000+id).tostring()
        /// </summary>       
        public string StyleId { get; set; }
        /// <summary>
        /// 款号
        /// </summary>
        public string StyleNo { get; set; }
        /// <summary>
        /// 产品品牌
        /// </summary>
        public string GoodsBrand { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public float CostPrice { get; set; }
        /// <summary>
        /// 出厂价
        /// </summary>
        public float FactoryPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public float SalePrice { get; set; }
        /// <summary>
        /// 处理价
        /// </summary>
        public float DiscountPrice { get; set; }
    }
}
