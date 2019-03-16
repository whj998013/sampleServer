using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SysBLL;
namespace SampleApi.Controllers.Proof
{
    public class NewProofController : ApiController
    {
        public IHttpActionResult GetProofNo()
        {
            string newProofNo = KeyMange.GetKey("ProofStyle");
            return Ok(newProofNo);
        }
    }
}
