using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interface.Stock
{
   public interface IPrice
    {

        /// <summary>
        /// 成本价
        /// </summary>
         float CostPrice { get; set; }
        /// <summary>
        /// 出厂价
        /// </summary>
         float FactoryPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
         float SalePrice { get; set; }

        /// <summary>
        /// 处理价
        /// </summary>
         float DiscountPrice { get; set; }
    }
}
