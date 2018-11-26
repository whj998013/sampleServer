using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysBLL.Model;
using SampleDataOper;
using SG.Model.Sys;
namespace SysBLL
{
    public class UrpOper
    {
        public  List<UrpModel> GetList()
        {
            List<UrpModel> list = new List<UrpModel>();
            var roles = DataQuery.GetRecords<Role>();
            var roleUsers = DataQuery.GetRecords<UserRole>();
            var urps = DataQuery.GetRecords<UserRolePermission>();
            roles.ForEach(p =>
            {
                UrpModel nurp = new UrpModel
                {
                    Role = p
                };
                var rlist = roleUsers.Where(t => t.RoleId == p.RoleId).ToArray();
                nurp.UserList.AddRange(rlist);
                nurp.PermissionList.AddRange(urps.Where(t => t.RoleId == p.RoleId).ToArray());
                list.Add(nurp);
            });

            return list;

        }

    }

}
