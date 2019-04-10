using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SampleApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.EnableCors(new EnableCorsAttribute("http://app.sungingroup.com:8080,http://app.sungingroup.com:8081,http://api.sungingroup.com:8080,http://api.sungingroup.com:8081", "*", "*"));
            // config.EnableCors(new EnableCorsAttribute("http://app.sungingroup.com:8080,http://app.sungingroup.com:8081", "*", "*"));

            // Web API 路由
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
