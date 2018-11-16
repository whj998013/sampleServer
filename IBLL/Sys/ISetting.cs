namespace IBLL.Sys
{
    public interface ISetting
    {
        int Id { get; set; }
        string KeyName { get; set; }
        string KeyValue { get; set; }
        string Remark { get; set; }
    }
}