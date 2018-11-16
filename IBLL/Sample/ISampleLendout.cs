﻿namespace IBLL.Sample
{
    public interface ISampleLendout: IBaseModel
    {
        string DdId { get; set; }
        int Id { get; set; }
        string LendOutNo { get; set; }
        LendStats State { get; set; }
        string UserDept { get; set; }
        string UserName { get; set; }
    }

    public enum LendStats
    {
        草拟 = 0,
        待审批 = 1,
        已通过 = 2,
    }
}