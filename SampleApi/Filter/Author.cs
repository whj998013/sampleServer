using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SG.SessionManage;
namespace SampleApi
{
    public class Author : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var u = SessionManage.CurrentUser;
            if (u == null)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                HttpContext.Current.Response.Write("{code:0,msg:'身份验证过期或未登录，需重新验证。'}");
            }

        }

    }
}