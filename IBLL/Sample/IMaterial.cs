namespace IBLL.Sample
{
    public interface IMaterial: IBaseModel
    {
        string CnName { get; set; }
        string EnName { get; set; }
        int Id { get; set; }
        int UseCount { get; set; }
    }
}