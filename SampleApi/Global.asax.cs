using SG.DdApi;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using SampleApi.App_Start;

namespace SampleApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            bool NeedRegister = true;
#if DEBUG
            NeedRegister = false;
#endif

            if (NeedRegister) GlobalConfiguration.Configuration.Filters.Add(new WebApiExceptionFilterAttribute());

            DdConfig.Init();

        }
        public override void Init()
        {
            this.PostAuthenticateRequest += (sender, e) => HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            base.Init();
        }



    }
}
