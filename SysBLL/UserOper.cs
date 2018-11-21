using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataOper;
using SG.Interface.Sample;
using Model.Sys;
using SG.Interface.Sys;

namespace SysBLL
{
    public class UserOper
    {

        public UserOper()
        {

        }

        public static User GetUser(string Ddid)
        {
            return new SampleContext().Users.SingleOrDefault(p => p.DdId == Ddid);
        }

     

        public static void AddUser(User u)
        {
            using(SampleContext sc=new SampleContext())
            {
                u.SetCreateUser("system");
                sc.Users.Add(u);
                sc.SaveChanges();
            }
        }
 
    }
}
