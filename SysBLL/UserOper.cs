using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataOper;
using SG.Interface.Sample;
using SG.Model.Sys;
using SG.Interface.Sys;

namespace SysBLL
{
    public class UserOper
    {


        public  User GetUser(string Ddid)
        {
            return new SampleContext().Users.SingleOrDefault(p => p.DdId == Ddid);
        }

       
        public void AddUser(User user)
        {
          
            using (SampleContext sc = new SampleContext())
            {
                user.SetCreateUser("system");
                sc.Users.Add(user);
                sc.SaveChanges();
            }
        }

        public void SyncUsers(List<User> users)
        {
            using(SampleContext sc=new SampleContext())
            {
                var ulist = sc.Users.ToList();
                ulist.ForEach(p => p.IsDelete = true);
                users.ForEach(p =>
                {
                    var u = ulist.SingleOrDefault(t => t.DdId == p.DdId);
                    if (u == null)
                    {
                        sc.Users.Add(p);
                    }
                    else
                    {
                        u.UserName = p.UserName;
                        u.IsLeader = p.IsLeader;
                        u.DeptId = p.DeptId;
                        u.DepartName = p.DepartName;
                        u.Avatar = p.Avatar;
                        u.IsDelete = false;
                    };
                });
                sc.SaveChanges();
            }

        }

    }
}
