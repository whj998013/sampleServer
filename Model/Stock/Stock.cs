using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Stock;
namespace Model.Stock
{
    /// <summary>
    /// 库存记录
    /// </summary>
    public class Stock : BaseModel, IStock
    {
        public int Id { get; set; }
        public string StockId { get; set; }
        public string StyleId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Num { get; set; }

    }
}
