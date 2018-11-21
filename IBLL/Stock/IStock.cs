namespace SG.Interface.Stock
{
    public interface IStock:IBaseModel
    {
        string Color { get; set; }
        int Id { get; set; }
        int Num { get; set; }
        string Size { get; set; }
        string StockId { get; set; }
        string StyleId { get; set; }
    }
}