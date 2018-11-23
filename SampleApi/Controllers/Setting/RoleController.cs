using SG.DdApi;
using SysBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleApi.Controllers.Setting
{
    public class RoleSettingController : ApiController
    {
        //从钉钉同步用户及管理员
        [HttpGet]
        public object UpUserDataByDd()
        {
            var ddoper = DdOperator.GetDdApi();
            SyncFromDd.SyncUserRole(ddoper);

            return Ok();
        }
    }
}
