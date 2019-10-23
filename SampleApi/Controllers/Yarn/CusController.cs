using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StorageData;
using YarnStockBLL;
using SysBLL;
namespace SampleApi.Controllers.Yarn
{
    [Author]
    public class CusController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCusList()
        {
            using YarnStockContext ysc = new YarnStockContext();
            var curList = ysc.Customer.Select(p => p.CusName).ToArray();
            return Ok(curList);


        }
    }
}
