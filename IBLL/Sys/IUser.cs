using System;
using SG.Interface.Sys;
namespace SG.Interface.Sys
{
    public interface IUser : IUserInfo, IUserLoginInfo
    {
    }
    public enum UserRoleU
    {
        一般用户 = 0,
        打样开发 = 1,
        样衣管理员 = 2,
        管理员 = 3
    }
}