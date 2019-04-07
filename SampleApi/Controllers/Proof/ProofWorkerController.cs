using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProofBLL;
namespace SampleApi.Controllers.Proof
{
    [Author]
    public class ProofWorkerController : ApiController
    {
        public IHttpActionResult GetWorkerList(int id)
        {
            ProofWorker pw = new ProofWorker();
            var obj = pw.GetWorkList(id);
            
            return Ok(obj);
        }
    }
}
