namespace SG.Interface.Sample
{
    public interface ISampleBaseInfo: IBaseModel
    {
        bool CanLendOut { get; set; }
        string Color { get; set; }
        float CostPrice { get; set; }
        string Counts { get; set; }
        string DdId { get; set; }
        float DiscountPrice { get; set; }
        float FactoryPrice { get; set; }
        string Gauge { get; set; }
        bool HaveStock { get; set; }
        int Id { get; set; }
        string Kinds { get; set; }
        string Material { get; set; }
        float SalePrice { get; set; }
        string SeachStr { get; set; }
        string Size { get; set; }
        SampleState State { get; set; }
        string StyleId { get; set; }
        string StyleNo { get; set; }
        string DeptName { get; set; }
        string StyleTag { get; set; }
        int Weight { get; set; }
    }

    public enum SampleState
    {
        草拟 = 1,
        待入库 = 2,
        在库 = 3,
        待借出 = 4,
        借出 = 5,
        待还回 = 6,
        所有 = 0
    }
}