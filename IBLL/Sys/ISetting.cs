namespace SG.Interface.Sys
{
    public interface ISetting
    {
       
        string KeyName { get; set; }
        string KeyValue { get; set; }
        string Remark { get; set; }
    }
}