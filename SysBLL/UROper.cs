using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
using SG.Model.Sys;
using SunginData;

namespace SysBLL
{
    public class UrOper
    {
        /// <summary>
        /// 更新usrRole表
        /// </summary>
        /// <param name="urList"></param>
        public void UpdateRoles(List<IUserRole> urList)
        {
            using SunginDataContext sc = new SunginDataContext();
            var re = sc.UserRoles.Where(p => p.RoleId > 0).ToList();
            re.ForEach(p => p.IsDelete = true);
            urList.ForEach(u =>
            {
                var ur = re.SingleOrDefault(p => p.DdId == u.DdId && p.RoleId == u.RoleId);
                if (ur == null)
                {
                    sc.UserRoles.Add((UserRole)u);
                }
                else
                {
                    ur.IsDelete = false;
                    ur.UserName = u.UserName;
                    ur.RoleName = u.RoleName;

                }
            });
            sc.SaveChanges();

        }

        public void AddDefalutUR(User user)
        {

            using SunginDataContext sc = new SunginDataContext();
            var userobj = sc.UserRoles.SingleOrDefault(p => p.RoleId == 0 && p.DdId == user.DdId);
            if (userobj == null)
            {
                UserRole ur = new UserRole
                {
                    DdId = user.DdId,
                    UserName = user.UserName,
                    RoleId = 0,
                    RoleName = "默认用户",

                };
                sc.UserRoles.Add(ur);
            }
            else
            {
                userobj.IsDelete = false;
            }
            sc.SaveChanges();
        }
    }
}
