using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleApi.App_Start;
using SysBLL;


namespace SampleApi.Controllers
{
   
    public class TestController : ApiController
    {
        [HttpGet]
        public object GetTestData()
        {
              return NotFound();
        }
    }
}
