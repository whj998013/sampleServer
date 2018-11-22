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


        public static User GetUser(string Ddid)
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

    }
}
