using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SG.DdApi;
using SampleDataOper;
using SysBLL;
using SG.Utilities;
using SG.SessionManage;
using SG.Model.Sys;
using SG.Interface.Sys;
using SG.DdApi.Sys;

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
            UserProvider uProvider = new UserProvider(ddoper);
            UserOper uOper = new UserOper();

            var uDdId = uProvider.GetDdIdByCode((string)code.code);
            User _user = uOper.GetUserByDdId(uDdId);

            if (_user != null)
            {
                ///再次登录更新cookie信息
                _user = uOper.UpDateLoginInfo(_user);
            }
            ///首次登录 
            else
            {
                //取得用户信息
                _user = uProvider.GetUserInfo(uDdId);
                ///首次登录，在数据库登录新用户
                uOper.AddUser(_user);
                //将用户加入默认用户组
                new UrOper().AddDefalutUR(_user);
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
                else
                {
                    string LoginStr = DESEncrypt.Decrypt(cookiestr, "998013");
                    UserOper uOpser = new UserOper();
                    User _user= uOpser.GetUserByLoginStr(LoginStr);
                    if (_user == null) return NotFound();
                    else
                    {
                        SessionManage.CurrentUser = _user;
                        return Ok(LoginHelp.ReturnUser(_user));
                    }
                    
                }
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
            UserOper uoper = new UserOper();
            if (name != "" && pwd != "")
            {
                _user = uoper.GetUserByAccout(name, pwd);
                if (_user != null)
                {
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
            User _user = SessionManage.CurrentUser;
            if (_user == null) return NotFound();
            else return Ok(LoginHelp.ReturnUser(_user));
        }

    }

    public class LoginHelp
    {
        public static object ReturnUser(User _user)
        {
            bool enableLimtView = SampleConfig.GetSampleConfig().EnableLimtView;
            _user.Ticket = DESEncrypt.Encrypt((_user.UserName + DateTime.Now.ToLongTimeString()).GetHashCode().ToString());
            bool allSampleCanLend = SampleConfig.GetSampleConfig().AllSampleCanLend;
            var plist = new UrpOper().GetPermissionsKeys(_user.DdId);
            var setting = new { enableLimtView, allSampleCanLend };
            return new { _user.UserName, _user.Avatar, LoginCookie = DESEncrypt.Encrypt(_user.LoginStr, "998013"), _user.LoginOverTime, _user.Ticket, _user.Role, setting, plist };
        }

    }
}
