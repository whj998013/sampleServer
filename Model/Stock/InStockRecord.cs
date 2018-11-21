using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Stock;
namespace Model.Stock
{
    /// <summary>
    /// 入库记录
    /// </summary>
    public class InStockRecord : BaseModel, IInStockRecord
    {
        public int Id { get; set; }
        public string StockId { get; set; }
        public string StyleId { get; set; }
        public string Size { get; set; }
        public DateTime? InStockDate { get; set; }
        public double Price { get; set; }
        public int InStockNum { get; set; }
    }
}
