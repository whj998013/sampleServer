using System;

namespace IBLL.Sys
{
    public interface IUser: IBaseModel
    {
        string Avatar { get; set; }
        string DdId { get; set; }
        string DepartName { get; set; }
        int Id { get; set; }
        DateTime? LoginOverTime { get; set; }
        string LoginStr { get; set; }
        string Name { get; set; }
        string PassWord { get; set; }
        string Ticket { get; set; }
        string UserName { get; set; }
    }
    public enum UserRoleU
    {
        一般用户 = 0,
        打样开发 = 1,
        样衣管理员 = 2,
        管理员 = 3
    }
}