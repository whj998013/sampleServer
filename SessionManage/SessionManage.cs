using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using SampleBLL;
using SG.Model.Sys;
using SunginData;
namespace SG.SessionManage
{
    public static class SessionManage
    {

        public static void Login(User u)
        {
            CurrentUser = u;
        }
        public static List<Dept> Depts
        {
            get; set;
        }


        /// <summary>
        /// 返回当前用户是否登录 
        /// </summary>

        public static bool IsLogin
        {
            get
            {
                if (HttpContext.Current.Session["User"] == null) return false;
                else return true;
            }
        }
        /// <summary>
        /// 返回当前用户对象
        /// </summary>
        public static User CurrentUser
        {
            get
            {
                //返回当前用户
                return (User)HttpContext.Current.Session["User"];
            }
            set
            {
                //设置当前用户
                HttpContext.Current.Session["User"] = value;
            }
        }

        /// <summary>
        /// 存储和返回用户请求地址
        /// </summary>
        public static string RequstUrl  //添加文字备注信息
        {
            get
            {
                return (string)HttpContext.Current.Session["RequstUrl"];
            }
            set
            {
                HttpContext.Current.Session["RequstUrl"] = value;
            }
        }

        /// <summary>
        /// 用户备注
        /// </summary>

        public static string Comments  //添加文字备注信息
        {

            get
            {
                return (string)HttpContext.Current.Session["Comments"];
            }
            set
            {
                HttpContext.Current.Session["Comments"] = value;
            }

        }

        /// <summary>
        /// 用户样品
        /// </summary>

        public static SampleInfo CurrentSample  //添加文字备注信息
        {

            get
            {
                return (SampleInfo)HttpContext.Current.Session["Sample"];
            }
            set
            {
                HttpContext.Current.Session["Sample"] = value;
            }

        }

    }
}
