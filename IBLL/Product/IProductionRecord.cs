using System;

namespace IBLL.Product
{
    public interface IProductionRecord:IBaseModel
    {
        string ClientName { get; set; }
        int Id { get; set; }
        float Price { get; set; }
        DateTime? ProductDate { get; set; }
        string ProductFactory { get; set; }
        int ProductNum { get; set; }
        string StyleId { get; set; }
    }
}