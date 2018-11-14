using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SG.DdApi;
using SampleDataOper;
using SampleDataOper.Model;
using SG.Utilities;
using SG.SessionManage;

namespace SampleApi.Controllers
{
    public class LoginController : ApiController
    {
        /// <summary>
        /// 钉钉登录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IHttpActionResult DdLogin([FromBody]dynamic code)
        {
            //try
            //{
            DdOperator ddoper = DdOperator.GetDdApi();
            var ddUser = ddoper.GetUserInfoByCode((string)code.code);
            User _user;
            using (SampleContext dc = new SampleContext())
            {
                _user = dc.Users.Where(p => p.DdId == ddUser.Userid).SingleOrDefault();
                if (_user == null)
                {
                    User nuser = new User()
                    {
                        DdId = ddUser.Userid,
                        Name = ddUser.Name,
                        DepartName = ddoper.GetDeptName(ddUser.Department[0]),
                        LoginStr = LoginHelp.GetLoginHashStr(ddUser),
                        Avatar = ddUser.Avatar,
                        LoginOverTime = DateTime.Now.AddDays(1)
                    };
                    nuser.SetCreateUser("system");
                    ///首次登录，在数据库登录新用户
                    dc.Users.Add(nuser);

                    dc.SaveChanges();
                    _user = dc.Users.Where(p => p.DdId == ddUser.Userid).FirstOrDefault();
                }
                else
                {
                    ///再次登录更新cookie信息
                    _user.LoginStr = LoginHelp.GetLoginHashStr(ddUser);
                    _user.LoginOverTime = DateTime.Now.AddDays(1);
                    ///比较是否有信息更新
                    if (_user.Name != ddUser.Name || _user.DepartName != ddoper.GetDeptName(ddUser.Department[0]) || _user.Avatar != ddUser.Avatar)
                    {
                        _user.Name = ddUser.Name;
                        _user.DepartName = ddoper.GetDeptName(ddUser.Department[0]);
                        _user.Avatar = ddUser.Avatar;
                    }
                    dc.SaveChanges();
                }
            }
            SessionManage.CurrentUser = _user;
            return Ok(LoginHelp.ReturnUser(_user));
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.Message);
            //}

        }
        /// <summary>
        /// cookie登录
        /// </summary>
        /// <param name="Cookie"></param>
        /// <returns></returns>

        public IHttpActionResult CookieLogin([FromBody]dynamic Cookie)
        {
            try
            {
                string cookiestr = (string)Cookie.cookie;
                if (cookiestr == null || cookiestr == "") return null;
                string LoginStr = DESEncrypt.Decrypt(cookiestr, "998013");
                User _user;
                using (SampleContext dc = new SampleContext())
                {
                    _user = dc.Users.Where(p => p.LoginStr == LoginStr).FirstOrDefault();
                    if (_user != null)
                    {
                        if (_user.LoginOverTime < DateTime.Now)
                        {
                            _user.LoginOverTime = null;
                            dc.SaveChanges();
                            return NotFound();
                        }
                    }
                    else return NotFound();
                }
                SessionManage.CurrentUser = _user;
                return Ok(LoginHelp.ReturnUser(_user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        /// <summary>
        /// 浏览器登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public IHttpActionResult WebLogin([FromBody]dynamic data)
        {
            string name = data.name;
            string pwd = data.pwd;
            User _user = null;
            if (name != "" && pwd != "")
            {
                using (SampleContext dc = new SampleContext())
                {
                    _user = dc.Users.Where(p => p.UserName == name && p.PassWord == pwd).FirstOrDefault();

                }
                if (_user != null)
                {
                    //_user.LoginStr = LoginHelp.GetLoginHashStr(_user);
                    SessionManage.CurrentUser = _user;
                    return Ok(LoginHelp.ReturnUser(_user));
                }
            }
            return BadRequest("用户名或密码错误，请重新输入。");

        }
        /// <summary>
        /// 验证是否登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetLogin()
        {
            var _user = SessionManage.CurrentUser;
            if (_user == null) return NotFound();
            else return Ok(LoginHelp.ReturnUser(_user));
        }


    }

    public class LoginHelp
    {
        public static string GetLoginHashStr(object obj)
        {
            return obj.GetHashCode().ToString() + DateTime.Now.GetHashCode().ToString();
        }

        public static object ReturnUser(User _user)
        {
            bool isLimt = !SampleConfig.GetSampleConfig().EnableLimtView || _user.Role != UserRoleU.一般用户;
            _user.Ticket = DESEncrypt.Encrypt((_user.Name + DateTime.Now.ToLongTimeString()).GetHashCode().ToString());
            bool allSampleCanLend = SampleConfig.GetSampleConfig().AllSampleCanLend;
            return new { _user.Name, _user.Avatar, LoginCookie = DESEncrypt.Encrypt(_user.LoginStr, "998013"), _user.LoginOverTime, _user.Ticket, _user.Role, isLimt, allSampleCanLend };
        }


    }
}
