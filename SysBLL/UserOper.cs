using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataOper;
using SG.Interface.Sample;
using SG.Model.Sys;
using SG.Interface.Sys;
using SG.Utilities;
namespace SysBLL
{
    public class UserOper
    {

        /// <summary>
        /// 根据DDid取得用户
        /// </summary>
        /// <param name="Ddid"></param>
        /// <returns></returns>
        public User GetUserByDdId(string Ddid)
        {
            return DataQuery.GetRecords<User>(p => p.DdId == Ddid).SingleOrDefault();
        }
        /// <summary>
        /// 根据登录Str返回用户
        /// </summary>
        /// <param name="loginStr"></param>
        /// <returns></returns>
        public User GetUserByLoginStr(string loginStr)
        {
            using (SampleContext dc = new SampleContext())
            {
                var _user = dc.Users.Where(p => p.LoginStr == loginStr).FirstOrDefault();
                if (_user != null)
                {
                    if (_user.LoginOverTime < DateTime.Now)
                    {
                        _user.LoginOverTime = null;
                        dc.SaveChanges();
                        _user = null;
                    }

                }
                return _user;
            };

        }
        /// <summary>
        /// 根所用户密码返回用户
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public User GetUserByAccout(string uid, string pwd)
        {

            return DataQuery.GetRecords<User>(p => p.Account == uid && pwd == p.PassWord).SingleOrDefault();

        }
        /// <summary>
        /// 更新登录信息
        /// </summary>
        public User UpDateLoginInfo(User _user)
        {
            using (SampleContext sc = new SampleContext())
            {
                var user = sc.Users.SingleOrDefault(p => p.DdId == _user.DdId);
                SetLoginInfo(ref user);
                sc.SaveChanges();
                return user;
            }

        }
        /// <summary>
        ///生成登录唯一码
        /// </summary>
        /// <param name="user"></param>
        private void SetLoginInfo(ref User user)
        {
            user.LoginStr = Guid.NewGuid().ToString(); // 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
            user.LoginOverTime = DateTime.Now.AddDays(1);
        }


        public void AddUser(User user)
        {

            using (SampleContext sc = new SampleContext())
            {
                SetLoginInfo(ref user);
                user.SetCreateUser("system");
                user.Pinyin = PinyinHelper.PinyinString(user.UserName);
                sc.Users.Add(user);
                sc.SaveChanges();
            }
        }

        public void SyncUsers(List<User> users)
        {
            using (SampleContext sc = new SampleContext())
            {
                var ulist = sc.Users.ToList();
                ulist.ForEach(p => p.IsDelete = true);
                users.ForEach(p =>
                {
                    
                    var u = ulist.SingleOrDefault(t => t.DdId == p.DdId);
                    if (u == null)
                    {
                        p.Pinyin = PinyinHelper.PinyinString(p.UserName);
                        sc.Users.Add(p);
                    }
                    else
                    {
                        u.Pinyin = PinyinHelper.PinyinString(u.UserName);
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
