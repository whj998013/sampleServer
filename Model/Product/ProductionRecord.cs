using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Product;

namespace SG.Model.Product
{
    /// <summary>
    /// 样衣的大货生产记录
    /// </summary>
    public class ProductionRecord : BaseModel, IProductionRecord
    {
        public int Id { get; set; }

        public string StyleId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 生产数量
        /// </summary>
        public int ProductNum { get; set; }

        /// <summary>
        /// 生产工厂
        /// </summary>
        public string ProductFactory { get; set; }
        /// <summary>
        /// 成衣价格
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? ProductDate { get; set; }
    }
}
