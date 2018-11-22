using System;

namespace SG.Interface.Product
{
    public interface IProductionRecord
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