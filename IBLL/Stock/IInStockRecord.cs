using System;

namespace SG.Interface.Stock
{
    public interface IInStockRecord
    {
        int Id { get; set; }
        DateTime? InStockDate { get; set; }
        int InStockNum { get; set; }
        double Price { get; set; }
        string Size { get; set; }
        string StockId { get; set; }
        string StyleId { get; set; }
    }
}