using System;

namespace SG.Interface.Sample
{
    public interface ILendRecord: IBaseModel
    {
        string DdId { get; set; }
        int Id { get; set; }
        DateTime? LendOutDate { get; set; }
        string LendOutNo { get; set; }
        DateTime? ReturnDate { get; set; }
        string ReturnNo { get; set; }
        LendRecordStats State { get; set; }
        string StyleId { get; set; }
        string UserDept { get; set; }
        string UserName { get; set; }
    }
    public enum LendRecordStats
    {
        草拟 = 0,
        借出审批 = 1,
        已借出 = 2,
        还回审批 = 3,
        已还回 = 4
    }
}