using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SG.Model.Sys;
using SysBLL;
namespace SampleApi.Controllers.Setting
{
    [Author]
    public class WorkerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SyncWorker()
        {
            WorkerOper wo = new WorkerOper();
            wo.SyncWorker();
            return Ok();
        }
    }
}
