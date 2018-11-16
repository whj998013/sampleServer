namespace IBLL.Sample
{
    public interface ISampleReturn: IBaseModel
    {
        int Id { get; set; }
        string ReturnNo { get; set; }
        ReturnStats Satas { get; set; }
        string UserDept { get; set; }
        int UserId { get; set; }
        string UserName { get; set; }
    }

    public enum ReturnStats
    {
        待审批 = 1,
        已通过 = 2
    }
}