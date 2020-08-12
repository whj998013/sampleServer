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
        public Garment()
        {
            this.GoodsType = GoodsTypeEnum.Garment;
        }

        /// <summary>
        /// 原料成份
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// 款式外链ID(10000000+id).tostring()
        /// </summary>       
        public string StyleId { get; set; }
        /// <summary>
        /// 款号
        /// </summary>
        public string StyleNo { get; set; }

       

      
    }
}
