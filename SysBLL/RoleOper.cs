using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunginData;
using SG.Interface.Sys;
using SG.Model.Sys;
using SG.DdApi;
using EntityFramework.Extensions;

namespace SysBLL
{
    /// <summary>
    /// 管理用户角色
    /// </summary>
    public class RoleOper
    {


        /// <summary>
        /// 同步数据库角色
        /// </summary>
        /// <param name="roleList"></param>
        public void UpdateRoles(List<IRole> roleList)
        {
            using (SunginDataContext sc = new SunginDataContext())
            {
                var re = sc.Roles.Where(p => p.RoleId > 0).ToList();
                re.ForEach(p => p.IsDelete = true);
                roleList.ForEach(p =>
                {
                    var reobj = re.Where(t => t.RoleId == p.RoleId).SingleOrDefault();
                    if (reobj == null)
                    {
                        sc.Roles.Add(new Role { RoleId = p.RoleId, RoleName = p.RoleName });
                    }
                    else
                    {
                        reobj.IsDelete = false;
                        reobj.RoleName = p.RoleName;
                    }
                });
                sc.SaveChanges();
            };
        }

        public void UpdateRoleRange(Role r)
        {
            using SunginDataContext sc = new SunginDataContext();
            var re = sc.Roles.Where(p => p.RoleId == r.RoleId).SingleOrDefault();
            re.PM = r.PM;
            re.PV = r.PV;
            sc.SaveChanges();
        }

    }
}
