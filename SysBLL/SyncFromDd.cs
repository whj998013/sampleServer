using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
using SG.Model.Sys;
using SunginData;
using SG.DdApi;
using SG.DdApi.Sys;
using EntityFramework.Extensions;
namespace SysBLL
{
    public class SyncFromDd
    {
        /// <summary>
        /// 同步钉钉用户和部门
        /// </summary>
        /// <param name="ddOper"></param>
        public static List<User> SyncUserDept(IDdOper ddOper)
        {

            SunginDataContext sc = new SunginDataContext();
            DeptProvider dProvider = new DeptProvider(ddOper);
            List<User> uList = new List<User>();
            List<Dept> depts = dProvider.GetDepts();
            depts.ForEach(p =>
            {
                var deptUserList = dProvider.GetDeptUserList(p.DeptID);
                deptUserList.ForEach(d =>
                {
                    d.DepartName = p.DeptName;
                    var u = uList.SingleOrDefault(t => t.DdId == d.DdId);
                    if (u == null) uList.Add(d);
                    else u.DepartName = u.DepartName + ',' + d.DepartName;
                    if (d.IsLeader) p.DeptAdminDdId = d.DdId;
                });
            });
            new DeptOper().SyncDepts(depts);
            new UserOper().SyncUsers(uList);
            UrOper uroper = new UrOper();
            uList.ForEach(p =>
            {
                uroper.AddDefalutUR(p);
            });
            ddOper.SetDept(depts);
            return uList;
        }

        /// <summary>
        /// 从钉钉同步角色和用户
        /// </summary>
        /// <param name="DdOper"></param>
        public static void SyncUserRole(IDdOper DdOper)
        {
            SunginDataContext sc = new SunginDataContext();
            UserProvider uProvider = new UserProvider(DdOper);
            RoleProvider rProvider = new RoleProvider(DdOper);
          
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
                                            DdId = u.Userid,
                                            RoleName = role.RoleName,
                                            UserName = user.UserName,
                                         
                                        });
                                    });
                }

            });

            new UrOper().UpdateRoles(urList); //同步UserRole表

        }

    }
}
