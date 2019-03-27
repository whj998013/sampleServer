﻿using SG.DdApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.SessionState;
using SysBLL;
using System.Threading.Tasks;

namespace SampleApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //钉钉初始化
            DdOperator ddOper = DdOperator.GetDdApi();
            ddOper.CorpId = ConfigurationManager.AppSettings["CorpId"];
            ddOper.CorpSecret = ConfigurationManager.AppSettings["CorpSecret"];
            ddOper.AgentID = ConfigurationManager.AppSettings["AgentID"];
            ddOper.SetDept(new DeptOper().GetDepts());

            Task.Run(async delegate
            {
                await Task.Delay(5000);
                DdCallbackOper dcb = new DdCallbackOper(ddOper);
                dcb.RegisterCallBack();
            });
           

            
        }
        public override void Init()
        {
            this.PostAuthenticateRequest += (sender, e) => HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            base.Init();
        }
    }
}
