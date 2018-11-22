using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataOper;
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
           using (SampleContext sc=new SampleContext())
            {
                var re = sc.Roles.ToList();
                re.ForEach(p => p.IsDelete = true);
                roleList.ForEach(p =>
                {
                    var reobj = re.Where(t => t.RoleId == p.RoleId).SingleOrDefault();
                    if (reobj == null)
                    {
                        sc.Roles.Add(new Role { RoleId = p.RoleId, Name = p.Name });
                    }
                    else
                    {
                        reobj.IsDelete = false;
                        reobj.Name = p.Name;
                    }
                 });
                sc.SaveChanges();
            };
        }

    }
}
