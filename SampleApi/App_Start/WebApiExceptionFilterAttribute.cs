using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using SG.Utilities;
using log4net;
namespace SampleApi.App_Start
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            //1.异常日志记录（正式项目里面一般是用log4net记录异常日志）
            log4net.ILog log = log4net.LogManager.GetLogger("sungin.Error");//获取一个日志记录器
            log.Fatal(actionExecutedContext.Exception);
                                 
            //2.返回调用方具体的异常信息

            var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(actionExecutedContext.Exception.Message),
                ReasonPhrase = "Server Error"
            };
            actionExecutedContext.Response = resp;
            base.OnException(actionExecutedContext);


        }

    }
}