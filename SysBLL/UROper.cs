using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
using SG.Model.Sys;
using SampleDataOper;

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
            using (SampleContext sc= new SampleContext())
            {             
                var re = sc.UserRoles.Where(p=>p.RoleId>0).ToList();
                re.ForEach(p => p.IsDelete = true);
                urList.ForEach(u =>
                {
                    var ur = re.SingleOrDefault(p => p.DdId == u.DdId && p.RoleId == u.RoleId);
                    if (ur == null)
                    {
                        sc.UserRoles.Add((UserRole)u);
                    }else
                    {
                        ur.IsDelete = false;
                        ur.UserName = u.UserName;
                        ur.RoleName = u.RoleName;
                    }
                });
                sc.SaveChanges();
            }

        }
    }
}
