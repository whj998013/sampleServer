using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleApi.Controllers.Setting
{
    [Author]
    public class YarnSettingController : ApiController
    {
        [HttpGet]
        public IHttpActionResult YarnStockCorrect()
        {
            YarnStockBLL.YarnStockOper.YarnStockCorrect();

            return Ok();
        }

    }
}
