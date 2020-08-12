using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Stock
{
    /// <summary>
    /// 产品
    /// </summary>
    public abstract class Goods : BaseModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品类别
        /// </summary>
        public string Category { get; set; }

        public GoodsTypeEnum GoodsType { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string GoodsPinYin { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string GoodsPic { get; set; }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string GoodsUnit { get; set; }
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
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string SeachKey { get; set; }
    }
    public enum GoodsTypeEnum
    {
        Yarn,
        Garment
    }
}
