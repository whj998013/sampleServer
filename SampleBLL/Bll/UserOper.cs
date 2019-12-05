using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunginData;
using SG.Interface.Sys;
using SG.Model.Sys;
using SG.Interface.Sample;


namespace SampleBLL
{
    public class SampleUserOper
    {
        public static User GetUser(string Ddid)
        {
            using SunginDataContext sdc = new SunginDataContext();
            return sdc.Users.SingleOrDefault(p => p.DdId == Ddid);
        }

        public static bool SetUserRole(string Ddid, UserRoleU ur)
        {
            using SunginDataContext sc = new SunginDataContext();
            var u = GetUser(Ddid);
            if (u != null)
            {
                u.Role = ur;
                u.SetEditUser("system");
                sc.Entry(u).State = System.Data.Entity.EntityState.Modified;
                sc.SaveChanges();
                return true;
            }
            else return false;
        }

        public static void ClearRoleBeforDate()
        {
            using SunginDataContext sc = new SunginDataContext();
            var list = sc.Users.Where(p => p.Role != UserRoleU.一般用户).ToList();
            list.ForEach(p =>
            {
                p.Role = UserRoleU.一般用户;
                sc.Entry(p).State = System.Data.Entity.EntityState.Modified;
            });
            sc.SaveChanges();

        }

        public static void AddUser(User u)
        {
            using SunginDataContext sc = new SunginDataContext();
            u.SetCreateUser("system");
            sc.Users.Add(u);
            sc.SaveChanges();
        }
        /// <summary>
        /// 取得有待入库样品的用户清单,返回ddid和name
        /// </summary>
        /// <returns></returns>
        public static object GetInStorageUserList()
        {
            using SunginDataContext sc = new SunginDataContext();
            var ubase = sc.SampleBaseInfos.Where(p => !p.IsDelete && p.State == SampleState.待入库).Select(p => new { p.DdId, Name = p.CreateUser }).Distinct().ToList();

            return ubase;
        }
    }
}
