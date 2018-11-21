using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
using SG.Model.Sys;
using SampleDataOper;
using SG.DdApi;
namespace SysBLL
{
    public class SyncFromDd
    {
        public static void SyncUserRole(IDdOper DdOper)
        {
            RoleProvider rp = new RoleProvider(DdOper);
            var userList = DataQuery.GetAllRecords<User>();
            RoleOper rOper = new RoleOper(DdOper);
            var roleList =rOper.GetRoleList("管理系统");
            rOper.UpdateRoles(roleList);

            roleList.ForEach(p =>
            {
                var re = rp.GetRoleUserList(p.RoleId).Result.List;

                re.ForEach(u =>
                {

                });
            });

        }

    }
}
