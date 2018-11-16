namespace IBLL.Sys
{
    public interface ICode
    {
        string CodeName { get; set; }
        int Id { get; set; }
        CodeType Type { get; set; }
        int UseCount { get; set; }
        string Value1 { get; set; }
        string Value2 { get; set; }
        string Value3 { get; set; }
    }

    public enum CodeType
    {
        Color = 1,
        Size = 2,
        Gauge = 3,
        Material = 4,
        Tag = 5,
        Kinds = 6,
    }
}