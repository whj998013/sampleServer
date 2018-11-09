using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SampleApi.Controllers
{
    public class FileController : ApiController
    {

        public object UpLoadFile()
        {

            string id = HttpContext.Current.Request["id"];
            string name = HttpContext.Current.Request["name"];
            HttpFileCollection files = HttpContext.Current.Request.Files;
            string filename="" ;
            foreach (string key in files.AllKeys)
            {
                HttpPostedFile file = files[key];//file.ContentLength文件长度
                if (string.IsNullOrEmpty(file.FileName) == false)
                    //file.SaveAs(HttpContext.Current.Server.MapPath("~/App_Data/Image/") + file.FileName);
                    file.SaveAs(@"E:\Web开发\样品管理\pic\" + file.FileName);
                filename = file.FileName;
            }

            return new { url="/pic/" + filename,name=filename };

        }
    }
}
