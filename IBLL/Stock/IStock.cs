namespace SG.Interface.Stock
{
    public interface IStock
    {
        string Color { get; set; }
        int Num { get; set; }
        string Size { get; set; }
        string GoodsId { get; set; }

        double InStockPrice { get; set; }
    }
}