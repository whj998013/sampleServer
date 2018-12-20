using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Stock;
namespace SG.Model.Stock
{
    /// <summary>
    /// 库存记录
    /// </summary>
    public class GarmentStock : BaseModel, IStock
    {
        public int Id { get; set; }
        /// <summary>
        /// 库存ID
        /// </summary>
        public string StockId { get; set; }
        /// <summary>
        /// 款式ID
        /// </summary>
        public string StyleId { get; set; }
        /// <summary>
        /// 尺码
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 库位
        /// </summary>
        public string Location { get; set; }

    }
}
