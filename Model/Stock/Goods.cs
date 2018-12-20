using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Stock
{
    public abstract class Goods: BaseModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsId { get; set; }
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
    }
}
