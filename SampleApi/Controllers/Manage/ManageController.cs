using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleDataOper;
using SampleBLL;
namespace SampleApi.Controllers
{
    public class ManageController : ApiController
    {
        /// <summary>
        /// 取得有入库申请的用户名单
        /// </summary>
        /// <returns></returns>
        public object GetInputUserList()
        {            
            return Ok(Manage.GetInputUserList());
        }

    }
}
