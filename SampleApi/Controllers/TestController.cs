using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SysBLL;


namespace SampleApi.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public object GetTestData()
        {
            var re = new DeptOper().GetDepts();
            return Ok(re);
        }
    }
}
