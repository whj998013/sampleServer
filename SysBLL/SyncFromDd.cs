using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
using SG.Model.Sys;
using SampleDataOper;
using SG.DdApi;
using SG.DdApi.Sys;
using EntityFramework.Extensions;
namespace SysBLL
{
    public class SyncFromDd
    {
        public static void SyncUserRole(IDdOper DdOper)
        {
            SampleContext sc = new SampleContext();
            RoleProvider rProvider = new RoleProvider(DdOper);
            UserProvider uProvider = new UserProvider(DdOper);
            RoleOper rOper = new RoleOper();
            UserOper uOper = new UserOper();

            var userList = DataQuery.GetAllRecords<User>();
            var roleList = rProvider.GetRoles("管理系统");
            rOper.UpdateRoles(roleList); //根据返回的roleList更新数据库

            List<IUserRole> urList = new List<IUserRole>();
            roleList.ForEach(role =>
            {
                var ruleUserList = rProvider.GetRoleUserList(role.RoleId);
                if (ruleUserList != null)
                {
                    ruleUserList.ForEach(u =>
                                    {
                                        var user = uProvider.GetUserInfo(u.Userid);
                                        if (userList.Count(c => c.DdId == u.Userid) == 0)
                                        {
                        //没有该用户，添加该用户
                        uOper.AddUser(user);
                                        }
                                        urList.Add(new UserRole
                                        {
                                            RoleId = role.RoleId,
                                            UserId = u.Userid,
                                            RoleName = role.Name,
                                            UserName = user.Name,
                                        });
                                    });
                }

            });

            new UserRoleOper().UpdateRoles(urList); //同步UserRole表

        }

    }
}
