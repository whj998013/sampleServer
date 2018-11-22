namespace SG.Interface.Sample
{
    public interface IMaterial
    {
        string CnName { get; set; }
        string EnName { get; set; }
        int Id { get; set; }
        int UseCount { get; set; }
    }
}