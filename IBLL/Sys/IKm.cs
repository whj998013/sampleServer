namespace SG.Interface.Sys
{
    public interface IKm
    {
        string BeginKey { get; set; }
        string Comment { get; set; }
        int Id { get; set; }
        string KeyName { get; set; }
        int KeyValue { get; set; }
    }
}