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
            var roles = DataQuery.GetRecords<Role>().OrderBy(p=>p.RoleId).ToList();
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

        public void UrpUpData(long roleId,List<string> KeyList)
        {
            using(SampleContext sc=new SampleContext())
            {
                var urpList = sc.UserRolePermissions.Where(p => p.RoleId == roleId).ToList();
                urpList.ForEach(p => p.IsDelete=true);
                KeyList.ForEach(p =>
                {
                    var urp = urpList.SingleOrDefault(u => u.RoleId == roleId && u.Key == p);
                    if (urp != null) urp.IsDelete = false;
                    else sc.UserRolePermissions.Add(new UserRolePermission { RoleId = roleId, Key = p });
                });
                sc.SaveChanges();
            }

        }

        public List<string> GetPermissionsKeys(string DdId)
        {
            var urList = DataQuery.GetRecords<UserRole>(p => p.DdId == DdId).Select(t=>t.RoleId).ToArray();
            //var urplist = new SampleContext().UserRolePermissions.Where(p=>p.IsDelete==false).Where(p => urList.Contains(p.RoleId)).Select(r=>r.Key).Distinct().ToList();
            SampleContext sc = new SampleContext();
            var re = sc.UserRolePermissions.Join(sc.Permissions, e => e.Key, o => o.Key, (e, o) => new {e.RoleId,e.IsDelete, e.Key, o.Name, o.CnName }).Where(p=>!p.IsDelete).Where(p => urList.Contains(p.RoleId)).Select(p=>p.Name).Distinct().ToList();


            return re;
        }


    }

}
